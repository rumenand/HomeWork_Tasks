
const html = {
    list: ()=> document.getElementById('root'),
    input: ()=> document.getElementById('towns'),
    btnLoad: () => document.getElementById('btnLoadTowns')
}

async function printTowns(e){
    e.preventDefault();
    const hbs = await fetch('./template.hbs').then(x=>x.text());
    const template = Handlebars.compile(hbs);
    const obj = html.input().value.split(', ')
              .filter(x=>x!=='');
  html.list().innerHTML = template({town:obj});
  }
  function attacheEvents(){
    html.btnLoad().addEventListener('click',printTowns);
  }
  attacheEvents();
