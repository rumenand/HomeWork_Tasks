'use strict';

function solve(a) {
    let heroes = a.map(row =>
        customSpliter(row, '/')).map(row => {
            return {
                name: row[0],
                level: Number(row[1]),
                items: (!row[2]) ? [] : customSpliter(row[2], ', ')
            }
        });
    console.log(JSON.stringify(heroes));
    function customSpliter(a,sp) {
        return a.split(sp).filter((x) => x != "").map((x) => x.trim());
    }
}

solve(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']
);