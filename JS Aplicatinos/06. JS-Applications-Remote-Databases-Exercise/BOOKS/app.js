const getUrl = (x) => `https://remote-databases-homework.firebaseio.com/${x}.json`;
const loadBooks = () => fetchData('books',{method:"GET"},[printBooksTable,clearForm]);
const clearForm = () => html.formInputs().forEach(x=>x.value = '');
const html = {
    btnLoad:() => document.getElementById('loadBooks'),
    btnSubmit: () => document.querySelector('form>button'),
    title: () => document.getElementById('title'),
    author: () => document.getElementById('author'),
    isbn: () => document.getElementById('isbn'),
    tbody: () => document.querySelector('tbody'),
    formInputs: () => [...document.querySelectorAll('form>input')]
}
function attachEvents(){
    html.btnLoad().addEventListener('click',loadBooks);
    html.btnSubmit().addEventListener('click',addBook);
}
function printBooksTable(data){
    html.tbody().innerHTML = '';
    Object.keys(data).forEach(x=>{
        const obj ={id: x,title: data[x].title} 
        const nRow = getEl('tr');
        nRow.appendChild(getEl('td',data[x].title));
        nRow.appendChild(getEl('td',data[x].author));
        nRow.appendChild(getEl('td',data[x].isbn));
        const btnCtr = getEl('td');
        const btnEdit = getEl('button','Edit');
        const btnDel = getEl('button','Delete');
        btnCtr.appendChild(btnEdit);
        btnCtr.appendChild(btnDel);
        nRow.appendChild(btnCtr);        
        btnDel.addEventListener('click',delHandler.bind(obj));
        btnEdit.addEventListener('click',editHandler.bind(obj));
        nRow.addEventListener('click',fillForm.bind(data[x]));
        html.tbody().appendChild(nRow);
    });
}
function fetchData(url,headers,callbacks){
    fetch(getUrl(url),headers)
    .then((res)=> {
		if (res.ok !== true) throw new Error('Could not load database');
		return res.json()})
    .then((data) => {
		if (data===null && headers.method ==='GET'){
		html.tbody().innerHTML = '';
		throw new Error('DataBase is empty!')};
		callbacks.forEach(x=>x(data))})
    .catch((e) => alert(e));
}
function addBook(e){
    e.preventDefault();
    fetchData('books',
     {method: 'POST',body: JSON.stringify(getHeaderfromForm())},
     [loadBooks]);
}
function delHandler(){
    if(confirm(`Do you want to Delete book ${this.title}?`) === true){
    fetchData(`books/${this.id}`,{method: "DELETE"},[loadBooks]);
    }
}
function editHandler(){
    const curData = getHeaderfromForm();
    if(confirm(`Do you want to edit book ${this.title} with data:
        Title: ${curData.title}
        Author: ${curData.author}
        Isbn: ${curData.isbn}`) === true){
            fetchData(`books/${this.id}`,
            {method: "PUT",body: JSON.stringify(curData)},
            [loadBooks,clearForm]);
    }
}
function getHeaderfromForm(){
    return{
        title:html.title().value,
        author:html.author().value,
        isbn: html.isbn().value
    }
}
function fillForm(e){
    if (e.target.nodeName !== 'BUTTON'){
        html.title().value = this.title;
        html.author().value = this.author;
        html.isbn().value = this.isbn;
    }
}
function getEl(a,b){
    let el = document.createElement(a);
    if (b !== undefined) el.innerHTML = b;
    return el;
}
attachEvents()