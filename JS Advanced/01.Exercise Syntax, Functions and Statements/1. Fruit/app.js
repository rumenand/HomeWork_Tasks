
'use strict';
function solve(a, b, c) {
    b = (b / 1000);
    let money = (b * c).toFixed(2);
    console.log(`I need \$${money} to buy ${b.toFixed} kilograms ${a}.`);
}
solve('apple', 1563, 2.35);
