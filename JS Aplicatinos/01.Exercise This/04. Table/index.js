function solve(){

  const tRows = [...document.querySelectorAll('tbody >tr')];
  tRows.map(x=>x.addEventListener('click',handler));

  function handler(){
     const curColor = this.style.backgroundColor;
     if (curColor === '') this.style.backgroundColor = '#413f5e';
     else this.style.backgroundColor = '';
     tRows.map(x=>{
        if (x !== this) x.style.backgroundColor = '';
     })
  }
}
