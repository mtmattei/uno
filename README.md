# App Anatomy — Uno learning MVP

Marketing page → gallery → a real embedded Uno WebAssembly app → inspect, experiment, repair, and export.

This standalone project lives on the `app-anatomy-mvp` branch of `mtmattei/uno`. The fork's `master` branch is unchanged. Do not merge this standalone tree into the Uno framework fork.

## What is implemented

- Responsive marketing page and searchable gallery.
- One complete sample, **mise.**, with six instrumented UI components and three learning paths.
- Real C# and XAML compiled using Uno.Sdk 6.7.30, targeting .NET 10 WebAssembly.
- A same-origin, nonce-checked postMessage bridge with acknowledgements and command timeouts.
- Inspect, use-app, source, experiment, curated guidance, and a binding-repair challenge.
- A challenge evaluator that changes the source twice and checks the real TextBlock.Text value.
- Local progress and settings, source permalinks, shareable routes, and edited Uno project ZIP export.
- C# model checks and Playwright browser checks, including screenshots and exported-project inspection.

This is not a generic visual-tree debugger or a live LLM tutor. Instrumentation and hints are authored for these components. The save operation is local; the 450 ms delay demonstrates busy state, not a backend request. Browser viewport controls do not claim native-device verification. No sign-in, payment, API key, or analytics service is required.

## Build and run

Install .NET 10 and Python 3. Then:

```sh
python scripts/fetch-assets.py
dotnet workload install wasm-tools
dotnet run --project tests/ModelTests/ModelTests.csproj
dotnet publish src/Mise/Mise.csproj -f net10.0-browserwasm -c Release -o publish
python scripts/package_site.py
python scripts/serve.py
```

Open `http://localhost:4173`. WebAssembly must be served over HTTP(S); do not double-click index.html.

The build pins Uno.Sdk in global.json. Interpreter mode, disabled threading, and disabled trimming favor dependable runtime inspection and ordinary static hosting over the smallest possible download. A production follow-up should move the bridge to source-generated JSON metadata, enable trimming, measure the complete payload, and test AOT separately.

## Browser acceptance checks

```sh
python -m pip install playwright==1.56.0
python -m playwright install chromium
python tests/test_web.py
```

`qa/results.json` records outcomes; `qa/*.png` contains desktop and mobile screenshots. Set `CHROMIUM_EXECUTABLE` to use an existing browser. These checks use the compiled app, not mocked postMessage events.

## GitHub Pages

The workflow builds, tests, packages, and attempts to deploy the static site through GitHub Pages. GitHub Pages must be enabled for this repository. In **Settings → Pages**, choose **GitHub Actions** as the source. The `github-pages` environment must allow the `app-anatomy-mvp` branch if deployment branch rules are enabled. Re-run the deployment job after making that one-time repository setting.

The expected URL after a successful deployment is `https://mtmattei.github.io/uno/`. Do not treat this as live until the deploy job succeeds. The full compiled site is also uploaded as the `app-anatomy-site` workflow artifact, independent of Pages configuration.

## Add another teaching app

Add a new Uno project, publish it under `dist/apps/<id>`, and use the versioned bridge protocol in `src/Mise/WasmScripts/anatomy.js`. Author its component metadata, lessons, and checks. Restrict accepted actions and validate their values in the app. Match source excerpts to the exact build revision. Do not mark a runtime connected based only on an iframe load event.

## Data and security boundaries

The host accepts messages only from the expected iframe, origin, protocol version, and session nonce. Commands are allowlisted in C# and processed serially. No arbitrary C# execution, credentials, or external requests are exposed through the bridge. A same-origin nonce is routing protection, not a security sandbox for untrusted code. The sample and host are trusted assets from the same build. Future user-generated experiments need separate origins and stronger isolation.

Learning progress is stored in this browser's localStorage; the event log is capped at 150 events. A reset/export UI is included. Hosting still receives ordinary HTTP requests. A future live tutor requires a separate server-side service; never put model API credentials in static JavaScript.

## Assets

Coffee image: Rachel Michetti, CC0, via scikit-image v0.25.2. `scripts/fetch-assets.py` verifies its pinned SHA-256. No image or font CDN is required at runtime.
