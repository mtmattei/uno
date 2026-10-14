"""Focused runtime diagnostics, useful when the full acceptance run cannot connect."""
import functools, http.server, json, os, shutil, threading
from pathlib import Path
from playwright.sync_api import sync_playwright
root=Path(__file__).resolve().parents[1]
out=root/'qa'; out.mkdir(exist_ok=True)
class Handler(http.server.SimpleHTTPRequestHandler):
 def log_message(self,*args): pass
server=http.server.ThreadingHTTPServer(('127.0.0.1',4183),functools.partial(Handler,directory=str(root/'dist')))
threading.Thread(target=server.serve_forever,daemon=True).start()
logs=[]
with sync_playwright() as p:
 browser=p.chromium.launch(executable_path=os.environ.get('CHROMIUM_EXECUTABLE') or shutil.which('google-chrome') or shutil.which('chromium'),args=['--no-sandbox'])
 page=browser.new_page()
 page.on('console',lambda m:logs.append(f'{m.type}: {m.text}'))
 page.on('pageerror',lambda e:logs.append('PAGE ERROR: '+str(e)))
 page.on('response',lambda r:logs.append(f'HTTP {r.status}: {r.url}') if r.status>=400 else None)
 page.on('requestfailed',lambda r:logs.append(f'FAILED {r.url}: {r.failure}'))
 page.goto('http://127.0.0.1:4183/#/lab/mise',wait_until='domcontentloaded')
 try: page.wait_for_selector('#runtime-status[data-status="live"]',timeout=30000)
 except Exception: pass
 for i,frame in enumerate(page.frames):
  try:
   data=frame.evaluate('''async () => ({url:location.href, module:typeof Module, dotnet:typeof getDotnetRuntime, bridge:typeof AnatomyBridge, manifest:typeof UnoAppManifest, body:document.body.innerText, exports:globalThis.Module?.getAssemblyExports ? Object.keys(await Module.getAssemblyExports('Mise')) : []})''')
   logs.append('FRAME '+str(i)+': '+json.dumps(data))
  except Exception as e: logs.append('FRAME '+str(i)+' ERROR: '+str(e))
 page.screenshot(path=str(out/'startup.png'),full_page=True)
 browser.close()
(out/'startup.log').write_text('\n'.join(logs),encoding='utf-8')
print('\n'.join(logs),flush=True)
server.shutdown()
