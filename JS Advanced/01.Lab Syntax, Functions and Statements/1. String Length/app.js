'use strict';
function solve(a, b, c) {
    let sumLength = a.length + b.length + c.length;
    let average = Math.floor(sumLength / 3);
    console.log(sumLength);
    console.log(average);
}
solve('chocolate', 'ice cream', 'cake');
