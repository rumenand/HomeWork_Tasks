function solve() {
  let tg = document.getElementsByClassName('middled')[0];
   tg.addEventListener('click', addClick);
   var siteVists = {
    Google:2,
    Wikipedia:4,
    stackoverflow:6,
    YouTube:4,
    SoftUni:1,
    Gmail:7
   };
   let siteMap = {
    A: (x)=> x.target,
    SPAN: (x) => x.target.parentElement
  };  
  
  function addClick(e){  
  let visit = siteMap[e.target.nodeName];
  if (visit !== undefined){
    let site = visit(e).textContent.trim();
    if (siteVists[site] !== undefined){
      siteVists[site]++;
      let counter = visit(e).nextElementSibling;
      counter.innerHTML = `visited ${siteVists[site]} times`; 
    }
  }
}
}