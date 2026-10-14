from pathlib import Path
from urllib.request import urlopen
import hashlib
root = Path(__file__).resolve().parents[1]
p = root / 'src/Mise/Assets/coffee.png'
if not p.exists():
 p.parent.mkdir(parents=True, exist_ok=True)
 data = urlopen('https://raw.githubusercontent.com/scikit-image/scikit-image/v0.25.2/skimage/data/coffee.png', timeout=30).read()
 if hashlib.sha256(data).hexdigest() != 'cc02f8ca188b167c775a7101b5d767d1e71792cf762c33d6fa15a4599b5a8de7': raise RuntimeError('Asset checksum mismatch')
 p.write_bytes(data)
print('Coffee image:', hashlib.sha256(p.read_bytes()).hexdigest())
