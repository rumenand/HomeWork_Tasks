function solve(e) {
  let tg = document.getElementsByClassName('middled')[0];
  if (!e) {
   tg.addEventListener('click', solve);
   var siteVists = {
    Google:2,
    Wikipedia:4,
    stackoverflow:6,
    YouTube:4,
    SoftUni:1,
    Gmail:7
   };
   tg._visits = siteVists;
   return;
  }
  let siteMap = {
    A: (x)=> x.target,
    SPAN: (x) => x.target.parentElement
  };
  let visit = siteMap[e.target.nodeName];
  if (visit !== undefined){
    let site = visit(e).textContent.trim();
    let visitMap = tg._visits;
    if (visitMap[site] !== undefined){
      visitMap[site]++;
      let counter = visit(e).nextElementSibling;
      counter.innerHTML = `visited ${visitMap[site]} times`; 
    }
  }
}