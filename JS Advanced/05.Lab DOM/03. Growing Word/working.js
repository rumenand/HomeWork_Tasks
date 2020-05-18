function growingWord() {
  const x = document.getElementById("exercise"); 
  if (!x.querySelector('counter')){
    const newC =  document.createElement('counter');
    newC.setAttribute('c',0);
    x.appendChild(newC);
  }  
  let counter = x.querySelector('counter');
  let curCount = Number(counter.getAttribute('c'));
  
  x.querySelector("p").style.fontSize = `${2*curCount+2}px`;
  let colors = ['#5B88BD','#8FF897','#A40014'];
  let curCol = (curCount+2)%3;
  x.querySelector("p").style.color = colors[curCol];
  
  curCount++;
  counter.setAttribute('c', curCount); 
}