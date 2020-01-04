'use strict';
function solve(a){
    let quant = {};
    let all = {};
    for (const row of a) {
        let cur = getQuantity(row.split(" => "));
        while (quant[cur] >= 1000)  makeBottles(cur);        
    }
    for (const key in all) {
        console.log(`${key} => ${all[key]}`);
    }

    function getQuantity(b) {
        let x = b[0];
        if (x in quant) quant[x] += Number(b[1]);
        else quant[x] = Number(b[1]);
        return x;
    }
    function makeBottles(c) {
        if (c in all) {
            all[c] += 1;
        }
        else all[c] = 1;
        quant[c] -= 1000;
    }
}

solve(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']
);
