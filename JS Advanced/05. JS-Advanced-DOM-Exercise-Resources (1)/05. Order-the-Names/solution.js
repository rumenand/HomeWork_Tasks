function solve() {
    let addBtn = document.querySelector('button');
    let textIpt = document.querySelector('input');    
    addBtn.addEventListener('click',hadler);
    let names = {
        13:['Nixon'],
        15:['Peterson']
    }

    function hadler(e){
        const name = textIpt.value.charAt(0).toUpperCase() + textIpt.value.slice(1).toLowerCase();
        const k = name.charCodeAt(0)-65;
        const list = document.querySelector('ol').children;
        if (!names.hasOwnProperty(k))names[k] = [];
        names[k].push(name);
        list[k].textContent = names[k].join(", ");
    }   
}