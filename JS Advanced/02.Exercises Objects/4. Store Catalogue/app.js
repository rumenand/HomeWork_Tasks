'use strict';
function solve(a) {
    let prod = a.map(x => x.split(" : ")).reduce((acc, cur) => {
        acc[cur[0]] = Number(cur[1]);
        return acc;
    }, {});  
    const ordered = {};
    Object.keys(prod).sort().forEach(function (key) {
        ordered[key] = prod[key];
    });

    let e = "";
    for (const key in ordered) {
        if (e != key[0]) {
            e = key[0];
            console.log(e);
        }
        console.log(`  ${key}: ${prod[key]}`);
    }
}

solve(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
);
