(() => {
    const html = {
        list: ()=> document.querySelector('.monkeys'),
        hbs:() => document.getElementById('monkey-template').innerHTML,
        btns: () => [...html.list().querySelectorAll('button')]
    }
     renderTemplate();

     function renderTemplate() {
        const template = Handlebars.compile(html.hbs());
        html.list().innerHTML = template({monkeys:window.monkeys});
       attachEvents(window.monkeys);
     }
     function attachEvents(data){
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
})()