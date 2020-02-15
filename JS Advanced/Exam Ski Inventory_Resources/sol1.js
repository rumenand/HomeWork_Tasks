function solve() {
   document.querySelector('#add-new button').addEventListener('click',addHandler);
   let avlProd = [];
   let boughtProd = [];

function addHandler(e){     
      const input = document.querySelectorAll('#add-new input[type=text]');
       avlProd.push([input[0].value,
                         Number(input[1].value),
                         Number(input[2].value)]);   
         populateList();
       e.preventDefault();
   }

   function populateList(){
      const availblProd = document.querySelector('#products > ul');
      availblProd.innerHTML = '';
      for (const prod of avlProd){
         const newLi = document.createElement('li');
         const newSpan = document.createElement('span');
         newSpan.textContent = prod[0];
         const newStrong = document.createElement('strong');
         newStrong.textContent ='Available: '+ prod[1];
         const newDiv = document.createElement('div');
         const divStrong = document.createElement('strong');
         divStrong.textContent = prod[2].toFixed(2);
         const newBtn = document.createElement('button');
         newBtn.addEventListener('click',buyHandler);
         newBtn.textContent = "Add to Client's List";
         newDiv.appendChild(divStrong);
         newDiv.appendChild(newBtn);
         newLi.appendChild(newSpan);
         newLi.appendChild(newStrong);
         newLi.appendChild(newDiv);
         availblProd.appendChild(newLi);   
      }
   }

   function buyHandler(e){
      const elementName = e.target.parentElement.parentElement.querySelector('span');
      const selProd = avlProd.findIndex((x=>x[0]===elementName.textContent));
      boughtProd.push([avlProd[selProd][0],avlProd[selProd][2]]);
      avlProd[selProd][1]--;
      if(avlProd[selProd][1]===0) avlProd.splice(selProd,1);
      updateBought();
      populateList();
   }

   function updateBought(){
      const list = document.querySelector('#myProducts > ul');
      list.innerHTML = '';
      for (const item of boughtProd) {
         const newLi = document.createElement('li');
         newLi.textContent = item[0];
         const newStrong = document.createElement('strong');
         newStrong.textContent =item[1];
         newLi.appendChild(newStrong);
         list.appendChild(newLi);
      }
   }
}