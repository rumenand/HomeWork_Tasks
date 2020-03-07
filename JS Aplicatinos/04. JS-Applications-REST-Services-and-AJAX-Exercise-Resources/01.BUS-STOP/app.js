function getInfo() {
const html = {
        stopId: ()=> document.getElementById('stopId'),
        stopName: ()=> document.getElementById('stopName'),
        bussesCont: ()=> document.getElementById('buses')
    }
html.stopName().textContent = '';
html.bussesCont().innerHTML = '';
let url = `https://judgetests.firebaseio.com/businfo/${html.stopId().value}.json`;
fetch(url)
.then(res => res.json())
.then(handler)
.catch(errHandler);

function handler(data){
    const {name, buses} = data;
    html.stopName().textContent = name;
    (Object.keys(buses)).forEach(x=>{
        const li = document.createElement('li');
        li.textContent = `Bus ${x} arrives in ${buses[x]} minutes`;
        html.bussesCont().appendChild(li);
    });
}
function errHandler(err){
    html.stopName().textContent = err;
}
}