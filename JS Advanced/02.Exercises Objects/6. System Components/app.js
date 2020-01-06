

function solve(a) {
    const finder = (a, b) => a.find(obj => obj.com === b);
    let sys = a.reduce((acc, cur) => {
        let [name, comp, subComp] = cur.split(' | ');
        if (!acc.hasOwnProperty(name)) acc[name] = {};
        if (!acc[name].hasOwnProperty(comp)) acc[name][comp] = [];
        acc[name][comp].push(subComp)
        return acc;
    }, {});

    let sysSorted = Object.keys(sys).sort((a, b) => {
        let result = Object.keys(sys[b]).length - Object.keys(sys[a]).length;
        if (result == 0) result = a.localeCompare(b);
        return result;
    });
    for (const i in sysSorted) {       
        console.log(sysSorted[i]);
        let compSorted = Object.keys(sys[sysSorted[i]]).sort((a, b) => {
            return sys[sysSorted[i]][b].length - sys[sysSorted[i]][a].length;
        });
        for (const j in compSorted) {
            console.log(`|||${compSorted[j]}`);
            console.log("||||||"+sys[sysSorted[i]][compSorted[j]].join("\n||||||"));
            }    
    }
}

solve(['SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security']
);