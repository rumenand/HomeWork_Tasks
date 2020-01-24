function solve() {
   const addBtns = [...document.querySelectorAll('.add-product')];
   addBtns.map(x=> x.addEventListener('click',addProduct));
   const chOutBtn = document.querySelector('.checkout');
   chOutBtn.addEventListener('click',checkOut);

   const tField = document.querySelector('textarea');
   let totPrice = 0;
   let products = new Set();

   function addProduct(e){
      const name = e.target.parentNode.parentNode.children[1].children[0].textContent;
      const money = e.target.parentNode.parentNode.children[3].textContent;
      tField.value += `Added ${name} for ${money} to the cart.\n`;
      totPrice += Number(money);
      products.add(name);
   }
   function checkOut(){
      tField.value += `You bought ${[...products].join(", ")} for ${totPrice.toFixed(2)}.`
      addBtns.map(x=>x.disabled = true);
      chOutBtn.disabled = true;
   }
}