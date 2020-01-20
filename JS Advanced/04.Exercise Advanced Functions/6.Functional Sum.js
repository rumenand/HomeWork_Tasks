const add = (function() {
    let sum = 0;
    function calc(a){
        sum +=a;
        return calc;
    } 
    calc.result = () => sum;
    return calc;
})();

console.log(add(3)(4).result())
