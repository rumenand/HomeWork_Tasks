function attachEvents() {
  html.refrBtn().addEventListener('click',refreshHandler);
  html.submitBtn().addEventListener('click',addHandler);
}
function fetchData(_,headers,callbacks){
  fetch(getUrl(),headers)
  .then(res=>res.json())
  .then((data) => callbacks.forEach(x=>x(data)))
  .catch((e) => html.msgField().value = e);
}
const getUrl = () => 'https://rest-messanger.firebaseio.com/messanger.json';
const refreshHandler = () => fetchData.call(undefined,'',undefined,[printData]);
const addHandler = () => fetchData.call(undefined,'',getAddHeader(),[refreshHandler,clearFields]);
function printData(data){
    html.msgField().value = '';
    const txt = (Object.keys(data)).map(x=>
         `${data[x].author}: ${data[x].content}`);
    html.msgField().value = txt.join('\n');
    html.msgField().scrollTop = html.msgField().scrollHeight;
}
function getAddHeader(){
    const data = {author: html.authorCtn().value,
                  content: html.messageCtn().value};
    return {  method: 'post',
              body: JSON.stringify(data)};
}
function clearFields(){
  html.authorCtn().value = '';
  html.messageCtn().value = '';
}
const html = {
  refrBtn: () => document.getElementById('refresh'),
  submitBtn: () => document.getElementById('submit'),
  msgField: () => document.getElementById('messages'),
  authorCtn: () => document.getElementById('author'),
  messageCtn: () => document.getElementById('content')
}
attachEvents();