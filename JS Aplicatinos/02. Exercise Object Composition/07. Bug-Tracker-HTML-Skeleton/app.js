function solve () {  
    let [container,ID] = [undefined,0];
    const report = function(author,description,reproducible,severity){
        if (container !== undefined){
            container.innerHTML += `<div id="report_${ID}" class="report">
        <div class="body">
          <p>${description}</p>
        </div>
        <div class="title">
          <span class="author">Submitted by: ${author}</span>
          <span class="status">Open | ${severity}</span>
        </div>
      </div>`;
        ID +=1;
        }
    }
    const setStatus = function(i,s){
        if (i>=0 && i<ID){
            const tgRep = document.querySelector(`[id="report_${i}"]`);
            const statusCont = tgRep.querySelector('.status');
            let text = statusCont.textContent.split(' | ');
            text[0] = s;
            statusCont.textContent = text.join(' | ');
        }
    }
    const remove = function(i){
        if (i>=0 && i<ID && container !== undefined){
            const tgRep = document.querySelector(`[id="report_${i}"]`);
            tgRep.remove();
        }
    }
    const sort = function(m){
       // if (typeof data[0][m] === 'number') data = data.sort((a,b)=> a[m]-b[m]);
       // else if (typeof data[0][m] === 'string') data = data.sort((a,b)=>a[m].localeCompare(b[m]));
       // createReports();
    }
    const output = function(s){
        container = document.querySelector(s);
        container.innerHTML = '';
    }       
    return { report,setStatus,remove,sort,output};
}


let tracker = solve();

tracker.output('#content');
tracker.report('guy', 'report content', true, 5);
tracker.report('second guy', 'report content 2', true, 3);
tracker.report('abv', 'report content three', true, 4);
tracker.setStatus(2,'closed');
//tracker.remove(2);

//tracker.sort('author');
//tracker.sort('severity');
////tracker.sort('ID');