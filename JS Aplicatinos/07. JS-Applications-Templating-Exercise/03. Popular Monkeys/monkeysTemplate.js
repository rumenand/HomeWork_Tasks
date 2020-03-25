import {monkeys} from './monkeys.js';
const html = {
    list: ()=> document.querySelector('.monkeys'),
    hbs:() => document.getElementById('monkey-template').innerHTML,
    btns: () => [...html.list().querySelectorAll('button')]
}	

function renderTemplate() {
    const template = Handlebars.compile(html.hbs());
    html.list().innerHTML = template({monkeys});        
 }
 
 function attachEvents(){
   html.btns().forEach(btn=>{
    btn.addEventListener('click',(e)=>{
        const pSect = e.target.nextElementSibling;
        if (pSect.style.display === 'none')
        {
            e.target.innerHTML = 'Hide Info';
            pSect.style.display = 'block';
        }
        else {
            pSect.style.display = 'none';
            e.target.innerHTML = 'Info';
        }
    })
   })
 } 
 renderTemplate();
 attachEvents();