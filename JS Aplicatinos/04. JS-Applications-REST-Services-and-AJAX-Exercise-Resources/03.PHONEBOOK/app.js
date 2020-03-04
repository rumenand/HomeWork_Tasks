function attachEvents() {
    document.querySelector('#btnLoad').addEventListener('click',getData);    
    document.querySelector('#btnCreate').addEventListener('click',createHandler);

}
function getData(){    
        fetch(`https://phonebook-nakov.firebaseio.com/phonebook.json`)
        .then(res => res.json())
        .then(printData)
        .catch(errHandler);
}
function printData(data){
    const phBook = document.querySelector('#phonebook');
    phBook.innerHTML = '';   
    (Object.keys(data)).forEach(x=>{
        const li = document.createElement('li');
        li.textContent = `${data[x].person}: ${data[x].phone}`;
        const delBtn = document.createElement('button');
        delBtn.textContent = 'Delete';
        delBtn.addEventListener('click',delHandler.bind({key:x}));
        li.appendChild(delBtn);
        phBook.appendChild(li);
    });    
}

function delHandler(){
    const key = this.key;
    const headers = {
        method : "DELETE"
    };
    fetch(`https://phonebook-nakov.firebaseio.com/phonebook/${key}.json`,headers)
    .then(getData);
}

function createHandler(){
    const personCtn = document.querySelector('#person');
    const phoneCtn = document.querySelector('#phone');
    const person = personCtn.value;
    const phone = phoneCtn.value;
    const data = {person,phone};
    fetch(`https://phonebook-nakov.firebaseio.com/phonebook.json`
     ,{
        method: 'post',
        body: JSON.stringify(data),
        })
    .then(getData)
    .then(() => {
        personCtn.value = '';
        phoneCtn.value = '';
    })
}
function errHandler() {
    document.querySelector('#phonebook').innerHTML = "There are no elements";
}

attachEvents();