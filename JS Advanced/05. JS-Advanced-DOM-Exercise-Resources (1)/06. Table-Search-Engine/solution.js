function solve() {
   const tBodyEl = document.querySelectorAll('tbody tr');
   const table = [...tBodyEl]
                .reduce((a,b,i) => {
                a.push(b.innerText);
                return a},[]);
   document.getElementById('searchBtn').addEventListener('click',handler);
   const sText = document.getElementById('searchField');     

   function handler(e){    
   [...tBodyEl].map(x=>x.classList ='');
   [...tBodyEl].forEach(e => {
        const text = e.textContent;
        if (text.includes(sText.value) && sText.value !== '') {
          e.className = 'select';
    }
   });
   sText.value = '';
   }
}