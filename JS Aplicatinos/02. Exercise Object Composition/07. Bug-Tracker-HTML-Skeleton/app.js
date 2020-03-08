function solve () {  
    let [selector,data,ID] = ['',[],0];
    const report = function(author,description,reproducible,severity){
        data.push({ID,author,description,reproducible,severity,status:'Open'});
        ID +=1;
        createReports();
    }
    const setStatus = function(i,s){
        if (i>=0 && i<data.length){
            data[i].status = s;
            createReports();
        }
    }
    const remove = function(i){
        if (i>=0 && i<data.length-1){
            data.splice(i,1);
            createReports();
        }
    }
    const sort = function(m){
        if (typeof data[0][m] === 'number') data = data.sort((a,b)=> a[m]-b[m]);
        else if (typeof data[0][m] === 'string') data = data.sort((a,b)=>a[m].localeCompare(b[m]));
        createReports();
    }
    const output = function(s){
        selector = s;
    }
    function createReports(){
        if (selector !== ''){
        const cont = document.querySelector(selector);
        cont.innerHTML = '';
        data.forEach( x=>{
        const wrapDiv = getEl('div',[{k:'id',v:`report_${x.ID}`},{k:'class',v:'report'}]);
        const bodyDiv = getEl('div',[{k:'class',v:'body'}]);
        bodyDiv.appendChild(getEl('p',undefined,x.description));       
        const titleDiv = getEl('div',[{k:'class',v:'title'}]);
        titleDiv.appendChild(getEl('span',[{k:'class',v:'author'}],`Submitted by: ${x.author}`));
        titleDiv.appendChild(getEl('span',[{k:'class',v:'status'}],`${x.status} | ${x.severity}`));        
        wrapDiv.appendChild(bodyDiv);
        wrapDiv.appendChild(titleDiv);
        cont.appendChild(wrapDiv);
        });
    }
    }
    function getEl(a,b,c){
        let el = document.createElement(a);
        if (b !== undefined) b.forEach(x=>el.setAttribute(x.k, x.v));
        if (c !== undefined) el.textContent = c;
        return el;
    }    
    return{ report,setStatus,remove,sort,output}
}