'use strict';
function solve(a) {
    let f = {
        chop: (x) => x / 2,
        dice: (x) => Math.sqrt(x),
        spice: (x) => x + 1,
        bake: (x) => x * 3,
        fillet: (x) => x - (x * 0.2)
    }
    
    let s = Number(a[0]);
    a = a.slice(1);
    for (let action in a) {
        if (f[a[action]] !== undefined) {
            s = f[a[action]](s);
            console.log(s);
        }
    }    
}
solve(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);
