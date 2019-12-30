'use strict';
function solve(a) {
    var digits = a.toString().split('');
    var b = digits.map(Number);
    let sameNums = true;
    for (var i = 0; i < b.length - 1; i++) {
        if (b[i] != b[i + 1]) sameNums = false;
    }
    console.log(sameNums);
    console.log(b.reduce((x, y) => x + y));
}
solve(2222222);
