'use strict';
function solve(a, b, c) {
    let result = a;
    if (result < b) result = b;
    if (result < c) result = c;
    console.log(`The largest number is ${result}.`);
}
solve(5, -3, 16);
