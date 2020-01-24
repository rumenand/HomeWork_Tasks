function solve() {
  const handlerMap = {
    Generate : addFrn,
    Buy : chOut
  };
[...document.querySelectorAll('button')]
.map(x=>x.addEventListener('click',(e) => handlerMap[e.target.innerHTML]()));

const txtAreas = document.querySelectorAll('textarea');
txtAreas[0].value = '[{"name": "Sofa", "img": "https://res.cloudinary.com/maisonsdumonde/image/upload/q_auto,f_auto/w_200/img/grey-3-seater-sofa-bed-200-13-0-175521_9.jpg", "price": 150, "decFactor": 1.2}]';
let tableBody = document.querySelector("#exercise > div > div > div > div > table > tbody");

function addFrn(){  
  let obj = JSON.parse(txtAreas[0].value);
 let rows = obj.map(x=>{  
  let newRow = document.createElement("tr");
   newRow.appendChild(crElem(x.img,'img'));
   newRow.appendChild(crElem(x.name,'p'));
   newRow.appendChild(crElem(x.price,'p'));
   newRow.appendChild(crElem(x.decFactor,'p'));
   newRow.appendChild(crElem(null,'input'));
   return newRow;
 });
 const tBody = document.querySelector("tbody");
 rows.map(x=>tBody.appendChild(x));
}
function crElem(x,y){
  let el = document.createElement("td");
  let p = document.createElement(y);
  if (y === 'img') p.src = x;
  else if (y==='input')  p.type= "checkbox";
  else p.textContent = x;
  el.appendChild(p);
  return el;
}
function chOut() {
  let output = document.querySelector("#exercise > textarea:nth-child(5)");
  let bought = [...document.querySelectorAll('input')].reduce((a,b,i)=> {
    if (b.checked === true) a.push(tableBody.children[i]);
    return a;
  },[]);
  let names = bought.map(x=>x.children[1].textContent);
  let totalPrice = bought.reduce((a,b) =>{
    a += Number(b.children[2].textContent);
    return a;
  },0)
  let decFactor = bought.reduce((a,b) => {
    a += Number(b.children[3].textContent);
    return a;
  },0)/bought.length; 
  output.value += `Bought furniture: ${names.join(", ")}\n`;
  output.value += `Total price: ${totalPrice.toFixed(2)}\n`;
  output.value += `Average decoration factor: ${decFactor}`;
  }
}