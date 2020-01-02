'use strict';
function solve(a) {
    checkDist([a[0], a[1], 0, 0]);
    checkDist([a[2], a[3], 0, 0]);
    checkDist(a);
    function checkDist(y) {
        let a = y[0] - y[2];
        let b = y[1] - y[3];
        let c = Math.sqrt(a * a + b * b);
        let result = Number.isInteger(c) ? "valid" : "invalid"
        console.log(`{${y[0]}, ${y[1]}} to {${y[2]}, ${y[3]}} is ${result}`);
    }
}
solve([2, 1, 1, 1]);
