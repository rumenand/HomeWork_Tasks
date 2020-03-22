let curIDs;
const html = {
    tbody: () => document.querySelector('tbody'),
    formCtn: () => document.querySelector('form'),
    formInputs: () =>html.formCtn().querySelectorAll('input')
}
const colorMap = {
    'ID':0,
    'FirstName':1,
    'LastName':2,
    'FacultyNumber':3,
    'Grade':4           
}
const fillIDs = (data) => curIDs = Object.keys(data).map(x=>data[x].ID);
const printStudents = () => fetchData('students',{method:"GET"},[printTable,fillIDs]);
const getUrl = (x) => `https://remote-databases-homework.firebaseio.com/${x}.json`;
function fetchData(url,headers,callbacks){
    fetch(getUrl(url),headers)
    .then((res) =>{ 
        if (res.ok !== true) throw new Error('Could not load database');
        return res.json();})
    .then((data) => {
        if (data === null) throw new Error('Database is empty');
        callbacks.forEach(x => x(data))})
    .catch((e) => alert(e));
}
function printTable(data){
    html.tbody().innerHTML = '';
    sortAcsendingByID(data).forEach(x=>{
        const nRow = getEl('tr');
        nRow.appendChild(getEl('td',data[x].ID));
        nRow.appendChild(getEl('td',data[x].FirstName));
        nRow.appendChild(getEl('td',data[x].LastName));
        nRow.appendChild(getEl('td',data[x].FacultyNumber));
        nRow.appendChild(getEl('td',data[x].Grade));
        html.tbody().appendChild(nRow);
    })
}
function getEl(a,b){
    let el = document.createElement(a);
    if (b !== undefined) el.innerHTML = b;
    return el;
}
function sortAcsendingByID(data){
   return Object.keys(data).sort((a,b) => data[a].ID-data[b].ID);
}
function createStudent(e){
    e.preventDefault();
    html.formInputs().forEach(x=>x.style.backgroundColor = '');
    const obj = getStudentObj();
    try{
        if (validateData(obj) === true){
            fetchData('students',{method: 'POST',
            body: JSON.stringify(obj)},[printStudents]);
            [...html.formInputs()].forEach(x=>x.value = '');
        }
    }
    catch(err){
        const e = JSON.parse(err.message);
        html.formInputs()[colorMap[e.target]].style.backgroundColor = 'red';
        alert(e.error);
    }

}
function validateData(obj){
    Object.keys(obj).forEach(x=>{
        if(obj[x] === undefined || obj[x] === null || obj[x] === ''){
            throw new Error(JSON.stringify({ target: x, error: `Field ${x} cannot be empty!` }));
        }
        if((x==='ID' || x==='Grade') && isNaN(obj[x])){
            throw new Error(JSON.stringify({ target: x, error:`${x} must be a number!`}));
        }
        if(x==='ID' && curIDs.includes(obj[x])) {
            throw new Error(JSON.stringify({ target: x, error:`ID ${obj[x]} already exist! Please enter differnt value!`}));
        }
		if((x==='Grade') && (Number(obj[x]>6) || Number(obj[x]<2))){
            throw new Error(JSON.stringify({ target: x, error:`${x} must be between 2 and 6!`}));
		}
	})
    return true;
}
function getStudentObj(){
    const data = [...html.formInputs()].map(x=>x.value);
    return{
        ID: (data[0]) ?Number(data[0]) : data[0],
        FirstName:  data[1],
        LastName:   data[2],
        FacultyNumber:  data[3],
        Grade: (data[4]) ?Number(data[4]) : data[4]
    }
}
function initConent(){
    printStudents();
    html.formCtn().querySelector('button').addEventListener('click',createStudent);
}

initConent();