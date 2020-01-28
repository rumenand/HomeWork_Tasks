function lockedProfile() {
    [...document.querySelectorAll('button')]
    .map(x=>x.addEventListener('click',handler));
    
    function handler(e){       
        const lock = e.target.parentNode.querySelector('input[type="radio"]:checked').value;
        if (lock === 'unlock'){
        const hidData =  e.target.parentNode.getElementsByTagName('div')[0];
       if (hidData.style.display === 'block') {
           hidData.style.display = 'none';
           e.target.textContent = 'Show more';
       }
       else {
           hidData.style.display = 'block';
           e.target.textContent = 'Hide it';
        }
    }
    }
}