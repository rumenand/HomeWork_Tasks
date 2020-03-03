function getInfo() {
const bId = document.querySelector('#stopId').value;
const stopId = document.querySelector('#stopName');
const busesCont = document.querySelector('#buses');

stopId.textContent = '';
busesCont.innerHTML = '';

fetch(`https://judgetests.firebaseio.com/businfo/${bId}.json`)
.then(res => res.json())
.then(handler)
.catch(errHandler);

function handler(data){
    const {name, buses} = data;
    stopId.textContent = name;
    (Object.keys(buses)).forEach(x=>{
        const li = document.createElement('li');
        li.textContent = `Bus ${x} arrives in ${buses[x]} minutes`;
        busesCont.appendChild(li);
    });
}
function errHandler(err){
    stopId.textContent = "Error";
}
}