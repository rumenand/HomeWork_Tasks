'use strict';
function solve(n, m) {
    let result=0;
    for (let i = Number(n); i <= Number(m); i++) {
        result += i;
    }
    return result;
}
console.log(solve('-8', '20'));
