'use strict';
function solve(a){
    var all = {};
    let q = a.map(x => x.split(" => ")).reduce((acc, cur) => {
        if (cur[0] in acc) acc[cur[0]] += Number(cur[1]);
        else acc[cur[0]] = Number(cur[1]);
        while (acc[cur[0]] >= 1000) {
            if (cur[0] in all) all[cur[0]] += 1;
            else all[cur[0]] = 1;
            acc[cur[0]] -= 1000;
        }
        return acc;
    }, {});       
    
    for (const key in all) {
        console.log(`${key} => ${all[key]}`);
    }
}

solve(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']
);
