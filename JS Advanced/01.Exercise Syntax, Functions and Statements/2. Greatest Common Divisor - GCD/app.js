'use strict';

function solve(a, b) {
    let x = Math.abs(a);
    let y = Math.abs(b);
    while (y) {
        var t = y;
        y = x % y;
        x = t;
    }
    console.log(x);
}
solve(2154, 458);