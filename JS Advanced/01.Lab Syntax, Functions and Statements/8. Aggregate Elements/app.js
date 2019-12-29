'use strict';
function solve(a) {
    console.log(a.reduce((x, y) => x + y));
    let b = a.map(x => 1 / x);
    console.log((b.reduce((x, y) => x + y)));
    console.log(a.reduce((x, y) => `${x}` + `${y}`));
}
solve([1, 2, 3]);
