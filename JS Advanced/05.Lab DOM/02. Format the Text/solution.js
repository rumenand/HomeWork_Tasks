function solve() {
  const title = document.getElementById('input');
  const output = document.getElementById('output');
  let arr = title.innerHTML
          .split('.').
          filter(i => i.length>1);
  while (arr.length){
    let newP =  document.createElement('p');
    if (arr.length>=3){
      newP.innerHTML = arr.splice(0,3).join(".");
    }
    else newP.innerHTML = arr.splice(0,arr.length);
    newP.innerHTML +='.';
    output.appendChild(newP);
  }
}