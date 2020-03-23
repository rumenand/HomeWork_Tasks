(() => {
    const html = {
        list: ()=> document.getElementById('allCats'),
        hbs:() => document.getElementById('cat-template').innerHTML,
        btns: () => [...html.list().querySelectorAll('.showBtn')]
    }
     renderCatTemplate();

     function renderCatTemplate() {
        const template = Handlebars.compile(html.hbs());
        html.list().innerHTML = template({cats:window.cats});
        attachEvents(window.cats);
     }
     function attachEvents(data){
       html.btns().forEach(btn=>{
        btn.addEventListener('click',(e)=>{
            const divSect = e.target.nextElementSibling;
            if (divSect.style.display === 'none')
            {
                e.target.innerHTML = 'Hide status code';
                divSect.style.display = 'block';
            }
            else {
                divSect.style.display = 'none';
                e.target.innerHTML = 'Show status code';
            }
        })
       })
     } 
})()
