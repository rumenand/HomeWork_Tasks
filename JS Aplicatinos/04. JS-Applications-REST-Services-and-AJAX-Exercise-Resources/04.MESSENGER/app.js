function attachEvents() {
  document.querySelector('#refresh').addEventListener('click',refreshHandler);
  document.querySelector('#submit').addEventListener('click',addHandler);
}
function refreshHandler(){
    fetch(`https://rest-messanger.firebaseio.com/messanger.json`)
    .then(res => res.json())
    .then(printData)
    //.catch(errHandler);
}
function printData(data){
    const printCtn = document.querySelector('#messages');
    printCtn.value = '';
    const txt = (Object.keys(data)).map(x=>
         `${data[x].author}: ${data[x].content}`);
    printCtn.value = txt.join('\n');

}
function addHandler(){
  const authorCtn = document.querySelector('#author');
    const messageCtn = document.querySelector('#content');
    const author = authorCtn.value;
    const content = messageCtn.value;
    const data = {author,content};
    fetch(`https://rest-messanger.firebaseio.com/messanger.json`
     ,{
        method: 'post',
        body: JSON.stringify(data),
        })
    .then(() => {
      authorCtn.value = '';
      messageCtn.value = '';
    })
}

attachEvents();