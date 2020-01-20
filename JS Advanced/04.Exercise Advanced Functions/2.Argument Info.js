function solve(){
   [...arguments].map(x=>console.log(`${typeof(x)}: ${x}`));
   let obj = [...arguments].reduce((a,b) => {
        if (!a[typeof(b)]) a[typeof(b)] =0;
        a[typeof(b)]++;
        return a;
   },{});
   Object.keys(obj).sort(function(a,b){return obj[b]-obj[a]})
  .map(x => console.log(`${x} = ${obj[x]}`));
}
solve ('cat', 42, function () { console.log('Hello world!'); });