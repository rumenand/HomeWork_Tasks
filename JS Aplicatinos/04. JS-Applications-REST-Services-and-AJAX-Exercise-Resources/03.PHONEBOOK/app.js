function attachEvents() {
    html.btnLoad().addEventListener('click',getData);    
    html.btnCreate().addEventListener('click',createHandler);    
}
function getUrl(x){
    return `https://phonebook-nakov.firebaseio.com/${x}.json`
}
function fetchData(url,headers,callbacks){
    fetch(getUrl(url),headers)
    .then(res=>res.json())
    .then((data) => callbacks.forEach(x=>x(data)))
    .catch((e) => html.phBookList().innerHTML = e);
}
function getData(){
    fetchData('phonebook',undefined,[printData])        
}
function printData(data){   
    html.phBookList().innerHTML = ''; 
    (Object.keys(data)).forEach(x=>{
        const li = document.createElement('li');
        li.textContent = `${data[x].person}: ${data[x].phone}`;
        const delBtn = document.createElement('button');
        delBtn.textContent = 'Delete';
        delBtn.addEventListener('click',delHandler.bind({key:x}));
        li.appendChild(delBtn);
        html.phBookList().appendChild(li);
    });   
}
function delHandler(){   
    fetchData(`phonebook/${this.key}`,{method: "DELETE"},[getData]);
}
function createHandler(){    
    const data = {
        person: html.personCtn().value,
        phone: html.phoneCtn().value
    };
    fetchData('phonebook',
     {method: 'post',body: JSON.stringify(data)},
     [getData,clearFields]);     
}
function clearFields(){
    html.personCtn().value = '';
    html.phoneCtn().value = '';  
}
const html = {
    phBookList: () => document.getElementById('phonebook'),
    btnLoad: () => document.getElementById('btnLoad'),    
    btnCreate: () =>document.getElementById('btnCreate'),
    personCtn: ()=> document.getElementById('person'),
    phoneCtn: ()=> document.getElementById('phone')
}
attachEvents();