const html = {
    getBtn: () => document.getElementById('submit'),
    loc: () => document.getElementById('location'),
    mainFr: () => document.getElementById('forecast'),
    curFr: () => document.getElementById('current'),
    upcFr: () => document.getElementById('upcoming')
}
const symbolMap ={
    'Sunny':'&#x2600',
    'Partly sunny':	'&#x26C5', 
	'Overcast':'&#x2601',
    'Rain':'&#x2614',
    'Degrees':'&#176'
}
const getUrl = (x) => `https://judgetests.firebaseio.com/${x}.json`;
const getCode = (data) => data.filter(x=>x.name === html.loc().value)[0].code;
const getDegrStr = (x) =>`${x.low}${symbolMap['Degrees']}/${x.high}${symbolMap['Degrees']}`;
const getSymbol = (x) => symbolMap[x];
const displFr = () => html.mainFr().style.display = 'block';
const initFr = () => html.mainFr().innerHTML = `<div id="current"></div>
												<div id="upcoming"></div>`;
const getLocations = () => fetchData('locations',[initFr,displFr,getOneDay,getThreeDays]);
const getOneDay = (data) => fetchData(`forecast/today/${getCode(data)}`,[printOneDay]);
const getThreeDays = (data) =>fetchData(`forecast/upcoming/${getCode(data)}`,[printThreeDays]);

function attachEvents() {
    html.getBtn().addEventListener('click',getLocations);
}
function fetchData(url,callbacks){
    fetch(getUrl(url))
    .then(res=>res.json())
    .then((data) => callbacks.forEach(x=>x(data)))
    .catch(() => {html.mainFr().textContent = 'Error'});
}
function printThreeDays(data){
    const wrapDiv = getEl('div','forecast-info');
    data.forecast.forEach(x=>{
        const wrapSpan = getEl('span','upcoming');  
        wrapSpan.appendChild(getEl('span','symbol',getSymbol(x.condition))); 
        wrapSpan.appendChild(getEl('span','forecast-data',getDegrStr(x)));
        wrapSpan.appendChild(getEl('span','forecast-data',x.condition));
        wrapDiv.appendChild(wrapSpan);
    })
    html.upcFr().innerHTML = '<div class="label">Three-day forecast</div>';
    html.upcFr().appendChild(wrapDiv);
}
function printOneDay(data){
    const wrapDiv = getEl('div','forecast');
    wrapDiv.appendChild(getEl('span','condition symbol',getSymbol(data.forecast.condition)));    
    const wrapSpan = getEl('span','condition');  
    wrapSpan.appendChild(getEl('span','forecast-data',data.name));
    wrapSpan.appendChild(getEl('span','forecast-data',getDegrStr(data.forecast)));
    wrapSpan.appendChild(getEl('span','forecast-data',data.forecast.condition));    
    wrapDiv.appendChild(wrapSpan);
    html.curFr().innerHTML = '<div class="label">Current conditions</div>';
    html.curFr().appendChild(wrapDiv);
}
function getEl(type,cl,text){
    const el = document.createElement(type);
    if (cl !== undefined) el.setAttribute('class',cl);
    if (text !== undefined) el.innerHTML = text;
    return el;
}

attachEvents();