"""Assemble the static host, actual WASM app, and matching source manifest."""
from pathlib import Path
import base64, json, os, shutil, subprocess, zipfile

ROOT = Path(__file__).resolve().parents[1]
DIST = ROOT / 'dist'
WASM = ROOT / 'publish/wwwroot'
if not (WASM / 'index.html').is_file():
    raise SystemExit('Publish the Uno WebAssembly app before packaging the site.')
if DIST.exists():
    shutil.rmtree(DIST)
shutil.copytree(ROOT / 'site', DIST)
shutil.copytree(WASM, DIST / 'apps/mise')
(DIST / 'assets').mkdir(exist_ok=True)
shutil.copy2(ROOT / 'src/Mise/Assets/coffee.png', DIST / 'assets/coffee.png')
(DIST / '.nojekyll').touch()
commit = os.environ.get('GITHUB_SHA')
if not commit:
    try:
        commit = subprocess.check_output(['git', 'rev-parse', 'HEAD'], cwd=ROOT, text=True).strip()
    except (OSError, subprocess.CalledProcessError):
        commit = 'app-anatomy-mvp'

excluded = {'bin', 'obj', '.git', '__pycache__', 'node_modules'}
def clean_files(folder):
    return [p for p in folder.rglob('*') if p.is_file() and not excluded.intersection(p.relative_to(ROOT).parts)]

project = {}
paths = clean_files(ROOT / 'src') + [ROOT / name for name in ('global.json', 'NuGet.Config')]
for p in paths:
    key = p.relative_to(ROOT).as_posix()
    if p.suffix.lower() in {'.png', '.jpg', '.jpeg', '.woff2'}:
        project[key] = {'base64': base64.b64encode(p.read_bytes()).decode('ascii')}
    else:
        project[key] = {'text': p.read_text(encoding='utf-8')}
project['README.md'] = {'text': '''# mise. — an Uno App Anatomy sample

A real Uno WebAssembly recipe app, built with C# and XAML.

## Run
Install .NET 10, then:

```sh
dotnet workload install wasm-tools
dotnet run --project src/Mise/Mise.csproj -f net10.0-browserwasm
```

## Publish
```sh
dotnet publish src/Mise/Mise.csproj -f net10.0-browserwasm -c Release -o publish
python -m http.server 4173 --directory publish/wwwroot
```

Open http://localhost:4173. WebAssembly needs HTTP(S), not a file:// URL.

The app initially opens in inspection mode when embedded. The App Anatomy host controls its learning bridge. When run standalone, it should open in normal app-use mode.

Your exported title, binding, type size, spacing, fit mode, and servings are written into the source. The anatomy-session.json file records the lesson snapshot. Save/checklist state is local session state, not a cloud account.

Photo: Rachel Michetti, CC0, via the scikit-image coffee sample.
'''}
manifest = {'version': 1, 'commit': commit, 'sdk': 'Uno.Sdk 6.7.30', 'files': project}
(DIST / 'source.js').write_text('window.ANATOMY_SOURCE = ' + json.dumps(manifest, ensure_ascii=True) + ';\n', encoding='utf-8')
(DIST / 'downloads').mkdir(exist_ok=True)
with zipfile.ZipFile(DIST / 'downloads/mise-uno-project.zip', 'w', zipfile.ZIP_DEFLATED) as z:
    for name, item in project.items():
        z.writestr(name, base64.b64decode(item['base64']) if 'base64' in item else item['text'])
with zipfile.ZipFile(DIST / 'downloads/app-anatomy-source.zip', 'w', zipfile.ZIP_DEFLATED) as z:
    for folder in ('src', 'site', 'scripts', 'tests', '.github'):
        for p in clean_files(ROOT / folder):
            z.write(p, p.relative_to(ROOT).as_posix())
    for name in ('global.json', 'NuGet.Config', 'README.md', '.gitignore'):
        if (ROOT / name).exists(): z.write(ROOT / name, name)
(DIST / 'build.json').write_text(json.dumps({'commit': commit, 'runtime': 'uno-wasm', 'sdk': '6.7.30', 'target': 'net10.0-browserwasm'}, indent=2))
shutil.copy2(ROOT / 'scripts/serve.py', DIST / 'serve.py')
(DIST / 'README.txt').write_text('APP ANATOMY — COMPILED MVP\n\nRun: python serve.py\nOpen: http://localhost:4173\n\nThe marketing page, gallery, and real Uno WebAssembly app are included.\nDo not double-click index.html: the .NET runtime requires HTTP(S).\nSource projects are in downloads/. No server-side app or account is needed.\n')
print(f'Packaged {len(project)} source files and compiled WASM into {DIST}')
