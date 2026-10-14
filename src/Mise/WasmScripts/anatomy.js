(() => {
  'use strict';
  const channel = 'app-anatomy', version = 1;
  let nonce = null, dispatch = null, latest = null;
  const origin = location.origin;
  function send(payload) {
    if (!nonce || window.parent === window) return;
    window.parent.postMessage({ channel, version, nonce, ...payload }, origin);
  }
  async function attach() {
    try {
      const exports = await globalThis.Module.getAssemblyExports('Mise');
      dispatch = exports.Mise.BrowserBridge.Dispatch;
      if (typeof dispatch !== 'function') throw new Error('Missing .NET bridge export.');
      send({ type: 'ready', runtime: 'uno-wasm', app: 'mise' });
      dispatch(JSON.stringify({ action: 'snapshot' }));
      if (window.parent === window) dispatch(JSON.stringify({ action: 'mode', value: 'use' }));
    } catch (error) { send({ type: 'error', message: String(error.message || error) }); }
  }
  function emit(json) { const payload = JSON.parse(json); if (payload.type === 'state') latest = payload; send(payload); }
  window.addEventListener('message', event => {
    if (event.source !== window.parent || event.origin !== origin) return;
    const m = event.data;
    if (!m || m.channel !== channel || m.version !== version || typeof m.nonce !== 'string') return;
    if (m.type === 'hello') {
      if (nonce && nonce !== m.nonce) return;
      nonce = m.nonce;
      if (dispatch) { send({ type: 'ready', runtime: 'uno-wasm', app: 'mise' }); if (latest) send(latest); }
      return;
    }
    if (m.nonce !== nonce || m.type !== 'command' || typeof m.action !== 'string' || !dispatch) return;
    dispatch(JSON.stringify({ action: m.action, value: m.value, id: m.id }));
  });
  globalThis.AnatomyBridge = Object.freeze({ attach, emit });
})();
