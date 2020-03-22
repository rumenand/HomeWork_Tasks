const getUrl = (x) => `https://remote-databases-homework.firebaseio.com/${x}.json`;
const getData = () => fetchData('players',{method:"GET"},[printData]);
let curPlayer;
const html = {
    canvas:() => document.getElementById('canvas'),
    playerCtn: () => document.getElementById('players'),
    addPlayer: () => document.getElementById('addPlayer'),
    addName: () => document.getElementById('addName'),
    buttons: () =>  [...document.getElementById('buttons').querySelectorAll('button')]
}
const addGameEvent =  {
    'Reload': (x)=> x.addEventListener('click',reload),
    'Save': (x) => x.addEventListener('click',save)
};
function attachEvents() {    
    addPlayer.addEventListener('click',addHandler);
    html.buttons().forEach(btn=>{
        addGameEvent[btn.textContent](btn);
    }); 
    getData();
	curPlayer = undefined;
}
function printData(data){
    html.playerCtn().innerHTML = '';
    Object.keys(data).forEach(x=>{
        const playerObj = {Id:x,obj:data[x]};
        const wrapDiv = getEl('div',[{k:'class',v:'player'},{k:'data-id',v:x}]);
        wrapDiv.innerHTML = getPlayerDivBody(x,data[x]);
        const playBtn = getEl('button',[{k:'class',v:'play'}],'Play');
        const delBtn = getEl('button',[{k:'class',v:'delete'}],'Delete');
        wrapDiv.appendChild(playBtn);
        wrapDiv.appendChild(delBtn);
        playBtn.addEventListener('click',play.bind(playerObj));
        delBtn.addEventListener('click',delPlayer.bind(playerObj));
        html.playerCtn().appendChild(wrapDiv);
    })
}
function fetchData(url,headers,callbacks){
    fetch(getUrl(url),headers)
    .then(res=>res.json())
    .then((data) => callbacks.forEach(x=>x(data)))
    .catch((e) => console.log(e));
}
function getEl(a,b,c){
    let el = document.createElement(a);
    if (b !== undefined) b.forEach(x=>el.setAttribute(x.k, x.v));
    if (c !== undefined) el.innerHTML = c;
    return el;
}
function getPlayerDivBody(id,player){
    return `<div class="player" data-id="<${id}>">
            <div class="row">
                <label>Name:</label>
                <label class="name">${player.name}</label>
            </div>
            <div class="row">
                <label>Money:</label>
                <label class="money">${player.money}</label>
            </div>
            <div class="row">
                <label>Bullets:</label>
                <label class="bullets">${player.bullets}</label>
            </div>
        </div>`
}
function play(){
    if (html.canvas().style.display === 'none'){
        setContent('block');
        curPlayer = this;       
        loadCanvas(this.obj);
    }
}
function delPlayer(){
    if(confirm(`Do you want to delete player with name ${this.obj.name}?`)){
		fetchData(`players/${this.Id}`,{method: "DELETE"},[getData]);
	 }
}
function addHandler(){
    const newPl = {
        name: html.addName().value,
        money:500,
        bullets:6
    }
    if (newPl.name !== ''){
    fetchData('players',{method: 'POST',body: JSON.stringify(newPl)},
    [getData]);
	html.addName().value = '';
	}
    else alert('Player name cannot be empty!');
}
function reload(){
    if (curPlayer !== undefined){
        curPlayer.obj.money -=60;
        curPlayer.obj.bullets = 6;
    }
}
function setContent(ctn){
    html.canvas().style.display = ctn;
    html.buttons().forEach(btn=>{
        btn.style.display = ctn;
    });  
}
function save(){    
    setContent('none');
    clearInterval(html.canvas().intervalId);      
    fetchData(`players/${curPlayer.Id}`,
    {method: 'PUT',body: JSON.stringify(curPlayer.obj)},[getData]);
	curPlayer = undefined;
}