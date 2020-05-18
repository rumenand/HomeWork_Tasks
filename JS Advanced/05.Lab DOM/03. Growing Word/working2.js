function growingWord() {
    var btn = document.querySelector("button"); 
  if (cont.querySelector('counter') === null){
    let newC =  document.createElement('counter');
    newC.setAttribute('c',1);
    cont.appendChild(newC);
  }
  const counter = cont.querySelector('counter');
  let curCount = Number(counter.getAttribute('c'));
        const colors = [...document.querySelectorAll('#colors div')]
                        .map(x=>x.textContent.toLowerCase());
        const word = document.querySelector('#exercise p');
        word.style.color = colors[(curCount+2)%3];
        word.style.fontSize = `${2**curCount}px`;
        curCount++;
        counter.setAttribute('c', curCount);
  }