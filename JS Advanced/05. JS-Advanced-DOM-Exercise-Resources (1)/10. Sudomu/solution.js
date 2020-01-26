function solve() {
    const funcMap = {
        Quick: checkNums,
        Clear: ClearNums
    };
    [...document.querySelectorAll('button')]
    .map(x=>x.addEventListener('click',(e) => funcMap[e.target.innerHTML.split(" ")[0]](e)));

    const table = document.querySelector('table');
    const res = document.querySelector('#check p');
    const cells = [...document.querySelectorAll('input')];

    function checkNums(e){
     const nums = cells.map(x=>Number(x.value));
     const matrix = [];
     while(nums.length) matrix.push(nums.splice(0,3));
     (isSudomu(matrix))
        ? applyResult('2px solid green','green','You solve it! Congratulations!')
        : applyResult('2px solid red','red','NOP! You are not done yet...');

        function isSudomu(x){
            return (unNumCount(x[0]) && unNumCount(x[1]) && unNumCount(x[2]))
            && unNumCount(x.map(y => y[0]))
            && unNumCount(x.map(y => y[1]))
            && unNumCount(x.map(y => y[2]))
            ? true :false;
       }
       function unNumCount(x){
           return new Set(x).size === 3;
       }
       function applyResult(x,y,z){           
        table.style.border = x;
        res.style.color = y;
        res.innerHTML = z;
       }   
    }

    function ClearNums(e){        
        cells.map(x=>x.value = '');
        table.style.border = '';
        res.innerHTML = '';
        res.style.color = '';
    }
}