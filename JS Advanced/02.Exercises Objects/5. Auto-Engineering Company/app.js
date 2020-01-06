'use strict';
function solve(a) {
    let prod = a.map(x => x.split(" | ")).reduce((acc, cur) => {
        let car = cur[0];
        let model = cur[1];
        let manif = Number(cur[2]);
        if (car in acc) {
            const found = acc[car].find(el => el.model == model);
            if (found == null) acc[car].push({
                model: model,
                prod: manif
            });
            else found.prod += manif;
        }
        else {
            acc[car] = [{
                model: model,
                prod: manif
            }];
        }
        return acc;
    }, {});   

    for (const car in prod) {     
            console.log(car);
            for (const mod in prod[car]) {
                console.log(`###${prod[car][mod].model} -> ${prod[car][mod].prod}`);
            }
        }        
}

solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']
);
