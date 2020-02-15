function solve() {
    const availableProducts = document.querySelector('#products ul');
    const bProd = document.querySelector('#myProducts ul');
    document.querySelector('#add-new button').addEventListener('click',addHandler);    
    document.querySelector('.filter button').addEventListener('click',filter);
    document.querySelector('#myProducts button').addEventListener('click',checkOutHdr); 
    let totPrice =0;

 function addHandler(e){ 
    e.preventDefault();    
       const input = document.querySelectorAll('#add-new input[type=text]');
        const name = input[0].value;
        let qty = Number(input[1].value);
        const price = Number(input[2].value);
        
            const newLi = document.createElement('li');
            const newSpan = document.createElement('span');
            newSpan.textContent = name;
            const newStrong = document.createElement('strong');
            newStrong.textContent ='Available: '+ qty.toFixed();
            const newDiv = document.createElement('div');
            const divStrong = document.createElement('strong');
            divStrong.textContent = price.toFixed(2);
            const newBtn = document.createElement('button');
            newBtn.addEventListener('click',buyHandler);
            newBtn.textContent = "Add to Client's List";
            newDiv.appendChild(divStrong);
            newDiv.appendChild(newBtn);
            newLi.appendChild(newSpan);
            newLi.appendChild(newStrong);
            newLi.appendChild(newDiv);
               
            availableProducts.appendChild(newLi);  
        
        function buyHandler(){            
            const bLi = document.createElement('li');         
            const bStrong = document.createElement('strong');
            bLi.innerHTML = name;
            bStrong.textContent = price.toFixed(2);
            bLi.appendChild(bStrong);
            bProd.appendChild(bLi);
            qty -= 1;
            newStrong.textContent ='Available: '+ qty.toFixed();
            if (qty ===0) newLi.remove();
            updatePrice(price);
        }
    }

    function updatePrice(x){
        const totPrLabel = document.querySelector('body > h1:nth-child(4)');
        totPrice +=x
        totPrLabel.textContent = `Total Price: ${totPrice.toFixed(2)}`;
    }
    function filter(){
        const ftWord = document.querySelector('#filter').value.toLowerCase();
        [...availableProducts.querySelectorAll('li')].map(x=>{
            const liName = x.querySelector('span').textContent.toLowerCase();
            if (!liName.includes(ftWord)) x.style.display = 'none';
        });        
    }
    function checkOutHdr(e){
        e.preventDefault();
        totPrice = 0;
        updatePrice(0);      
        bProd.innerHTML = '';        
    }
 }