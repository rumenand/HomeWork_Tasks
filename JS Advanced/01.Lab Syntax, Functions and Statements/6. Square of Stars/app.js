'use strict';
function solve(a = 5) {
    let row = "";
    for (let i = 0; i < a; i++) {
        row = "";
        for (let j = 0; j < a; j++) {
            row += "* ";
        }
        console.log(row);
    }
}
solve();
