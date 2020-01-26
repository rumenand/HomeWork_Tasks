function create(words) {
   let ctr = document.querySelector('#content');
   words.map(x =>{
      const p = document.createElement('p');
      p.textContent = x;
      p.style.display = 'none';
      const a = document.createElement('div');      
      a.appendChild(p);      
      a.addEventListener('click', () => p.style.display = 'block');
      ctr.appendChild(a);
   })
}