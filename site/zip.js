// Small dependency-free ZIP writer (stored entries, UTF-8 names, CRC-32).
// Project paths come only from our build-generated source manifest.
(() => {
 const enc = new TextEncoder();
 const table = Array.from({length:256},(_,i)=>{let c=i;for(let j=0;j<8;j++)c=c&1?0xedb88320^(c>>>1):c>>>1;return c>>>0;});
 const crc = bytes => {let c=0xffffffff;for(const b of bytes)c=table[(c^b)&255]^(c>>>8);return(c^0xffffffff)>>>0;};
 const header=(size,values)=>{const a=new Uint8Array(size),v=new DataView(a.buffer);for(const [at,value,width] of values)width===2?v.setUint16(at,value,true):v.setUint32(at,value,true);return a;};
 window.makeProjectZip = files => {
  const chunks=[],central=[];let offset=0;
  for(const [path,value] of Object.entries(files)){
   if(path.startsWith('/')||path.split('/').includes('..'))throw new Error('Invalid project path.');
   const name=enc.encode(path),data=value instanceof Uint8Array?value:enc.encode(value),c=crc(data);
   const local=header(30,[[0,0x04034b50,4],[4,20,2],[6,0x800,2],[14,c,4],[18,data.length,4],[22,data.length,4],[26,name.length,2]]);
   const index=header(46,[[0,0x02014b50,4],[4,20,2],[6,20,2],[8,0x800,2],[16,c,4],[20,data.length,4],[24,data.length,4],[28,name.length,2],[42,offset,4]]);
   chunks.push(local,name,data);central.push(index,name);offset+=30+name.length+data.length;
  }
  const length=central.reduce((n,a)=>n+a.length,0),count=Object.keys(files).length;
  const end=header(22,[[0,0x06054b50,4],[8,count,2],[10,count,2],[12,length,4],[16,offset,4]]);
  return new Blob([...chunks,...central,end],{type:'application/zip'});
 };
})();
