const html = {
    loadBtn: () => document.querySelector('.load'),
    cathesCtn: () => document.getElementById('main'),
    addBth: () => document.querySelector('.add'),
    addForm: () => document.getElementById('addForm')
}
const loadHdr = () => fetchData('catches',{method: "GET"},[printData]);
const getUrl = (x) => `https://fisher-game.firebaseio.com/${x}.json`;
const clearField = () => html.cathesCtn().innerHTML ='<legend>Catches</legend>';
function attachEvents() {
   html.loadBtn().addEventListener('click',loadHdr);
   html.addForm().querySelector('button').addEventListener('click',addHdr);
}
function fetchData(url,headers,callbacks){
    fetch(getUrl(url),headers)
    .then((res)=>{
		if (res.ok !== true) throw new Error('Cannot load resourse!');
		return res.json();
	})
    .then((data) => {
		if(data === null && headers.method === 'GET')
		{
			clearField();
			throw new Error('Database is empty!');
		}
		callbacks.forEach(x=>x(data))
		})
    .catch((e) =>alert(e));
}
function printData(data){
	clearField();
    Object.keys(data).forEach(id=>{
        const div = getEl('div',
        [{k:'class',v:'catch'},{k:'data-id',v:id}],
        getDivBody(id,data[id]));
    const updBtn = getEl('button',[{k:'class',v:'update'}],'Update');
    updBtn.addEventListener('click',updHandler.bind({id}));   
    const delBtn = getEl('button',[{k:'class',v:'update'}],'Delete');
    delBtn.addEventListener('click',delHandler.bind({id,})); 
    div.appendChild(updBtn);
    div.appendChild(delBtn);
    html.cathesCtn().appendChild(div);
    });  
}
function delHandler(){
	 if(confirm(`Do you want to delete catch with id ${this.id}?`)){
		fetchData(`catches/${this.id}`,{method: "DELETE"},[loadHdr]);
	 }
}
function addHdr(){
    const obj = getDataObj(html.addForm().querySelectorAll('input'));
    fetchData('catches',
    {method: 'POST',body: JSON.stringify(obj)},
    [loadHdr]);
}
function updHandler(){
    const obj = getDataObj(document.querySelector(`[data-id="${this.id}"]`)
                            .querySelectorAll('input'));
    fetchData(`catches/${this.id}`,{method: 'PUT',body: JSON.stringify(obj)},[loadHdr]);
}
function getDataObj(x){
    return {
        angler: `${x[0].value}`,
        weight: x[1].value,
        species: `${x[2].value}`,
        location: `${x[3].value}`,
        bait: `${x[4].value}`,
        captureTime: x[5].value
    }
}
function getEl(a,b,c){
    let el = document.createElement(a);
    if (b !== undefined) b.forEach(x=>el.setAttribute(x.k, x.v));
    if (c !== undefined) el.innerHTML = c;
    return el;
}
function getDivBody(x,y){
    return `<label>Angler</label>
    <input type="text" class="angler" value="${y.angler}" />
    <hr>
    <label>Weight</label>      
    <input type="number" class="weight" value="${y.weight}" />
    <hr>
    <label>Species</label>
    <input type="text" class="species" value="${y.species}" />
    <hr>
    <label>Location</label>
    <input type="text" class="location" value="${y.location}" />
    <hr>
    <label>Bait</label>
    <input type="text" class="bait" value="${y.bait}" />
    <hr>
    <label>Capture Time</label>
    <input type="number" class="captureTime" value="${y.captureTime}" />
    <hr>`
}

attachEvents();