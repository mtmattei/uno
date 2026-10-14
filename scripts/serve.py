"""Serve the compiled static site locally, without external dependencies."""
from functools import partial
from http.server import SimpleHTTPRequestHandler, ThreadingHTTPServer
from pathlib import Path
import argparse

parser = argparse.ArgumentParser()
parser.add_argument('--port', type=int, default=4173)
parser.add_argument('--directory', default=None)
args = parser.parse_args()
here = Path(__file__).resolve().parent
root = Path(args.directory).resolve() if args.directory else (here.parent / 'dist' if here.name == 'scripts' else here)
if not (root / 'index.html').exists():
    raise SystemExit(f'No compiled site at {root}. Build and package it first.')
class Handler(SimpleHTTPRequestHandler):
    extensions_map = {**SimpleHTTPRequestHandler.extensions_map, '.wasm': 'application/wasm', '.js': 'text/javascript'}
    def end_headers(self):
        self.send_header('Cache-Control', 'no-cache')
        super().end_headers()
server = ThreadingHTTPServer(('127.0.0.1', args.port), partial(Handler, directory=str(root)))
print(f'App Anatomy: http://localhost:{args.port}', flush=True)
try:
    server.serve_forever()
except KeyboardInterrupt:
    pass
finally:
    server.server_close()
