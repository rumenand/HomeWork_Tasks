function solve() {
  [...document.querySelectorAll('img')]
  .map(x=>x.addEventListener('click',handler));
  const pl = {
    player1Div: {
        card :null,
        log: document.getElementById('result').children[0]
    },
    player2Div : {
        card :null,
        log: document.getElementById('result').children[2]
    }
  };
  const getPlCPow = (x) => Number(x.card.name);

  function handler(e){
      const cPl = e.target.parentElement.id;
     if(pl[cPl].card === null){
        pl[cPl].card = e.target;
        pl[cPl].log.textContent = e.target.name;
        pl[cPl].card.src = 'images/whiteCard.jpg'
     }
     if (pl.player1Div.card && pl.player2Div.card) fight();
  }
  function fight(){
      const p1res = getPlCPow(pl.player1Div);
      const p2res = getPlCPow(pl.player2Div);
      (p1res>p2res) ?borderCards(pl.player1Div,pl.player2Div)
      :borderCards(pl.player2Div,pl.player1Div);
    
      document.getElementById('history').innerHTML += `[${p1res} vs ${p2res}] `;
      for (const player of Object.keys(pl)){
          pl[player].card = null;
          pl[player].log.textContent ='';
      }

  }
  function borderCards(x,y){
      x.card.style.border = "2px solid green";
      y.card.style.border = "2px solid red";
  }
}