function solve() {
    [...document.querySelectorAll('button')]
    .map(x=>x.addEventListener('click',handler));
    const screen = document.getElementById('expressionOutput');
    const result = document.getElementById('resultOutput');
    const funcMapper = {        
        '=': calculateResult,
        'C': clearScreens
    }
    const calcMapper = {
        '+': (a,b) => a+b,
        '-': (a,b) => a-b,
        'x': (a,b) => a*b,
        '/': (a,b) => a/b
    }
   
    function handler(e){
        const cValue = e.target.innerHTML;
        if (!isNaN(Number(cValue)) || cValue === '.') screen.innerHTML +=cValue;
        else if (cValue !=='C' && cValue !=='='){
        screen.innerHTML +=' ' + cValue +' ';        
        }
        else funcMapper[cValue].call(this,screen.innerHTML);
    }
    function calculateResult(exp){ 
        let eParts = exp.split(" ").filter(x=>x!=='');
        result.innerHTML= (eParts.length === 3) 
            ? calcMapper[eParts[1]](Number(eParts[0]),Number(eParts[2]))
            : 'NaN';
    }
    function clearScreens()
    {
        screen.innerHTML = '';
        result.innerHTML = '';
    }
}