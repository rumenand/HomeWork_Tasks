function solve(data) {
    var gladiators = {};
    for (const row of data) {
        if (row === 'Ave Cesar') break;
        if (row.includes(" -> ")) addGladiator(row);
        else if (row.includes(" vs ")) fightGladiator(row)
    }
    let sorted = Object.keys(gladiators).sort((a, b) => {
        let result = getTotalPoints(gladiators[b]) - getTotalPoints(gladiators[a]);
        if (result == 0) result = a.localeCompare(b);
        return result;
    });
    for (const i in sorted) {
        console.log(`${sorted[i]}: ${getTotalPoints(gladiators[sorted[i]])} skill`);
        let skillSorted = Object.keys(gladiators[sorted[i]]).sort((a, b) => {
            let result = gladiators[sorted[i]][b] - gladiators[sorted[i]][a];
            if (result == 0) result = a.localeCompare(b);
            return result;
        });
        for (const j in skillSorted) {
            console.log(`- ${skillSorted[j]} <!> ${gladiators[sorted[i]][skillSorted[j]]}`);            
        } 
    }    
    function addGladiator(row) {
        let [glad, tech, skill] = row.split(" -> ");
        if (!gladiators.hasOwnProperty(glad)) gladiators[glad] = {};
        if (gladiators[glad].hasOwnProperty(tech)) {
            if (gladiators[glad][tech] < Number(skill))
                gladiators[glad][tech] = Number(skill);
        }
        else gladiators[glad][tech] = Number(skill);
    }
    function fightGladiator(row) {
        let [glad1, glad2] = row.split(" vs ");
        if (gladiators.hasOwnProperty(glad1) && gladiators.hasOwnProperty(glad2)) {
            for (const tech in gladiators[glad1]) {
                if (gladiators[glad2].hasOwnProperty(tech)) {
                    if (getTotalPoints(gladiators[glad1]) < getTotalPoints(gladiators[glad2]))
                        delete gladiators[glad1];
                    else if (getTotalPoints(gladiators[glad1]) > getTotalPoints(gladiators[glad2]))
                        delete gladiators[glad2];
                }
            }
        }
    }    
    function getTotalPoints(glad) {
        return Object.keys(glad).reduce((a, b) => a + glad[b], 0);
    }
}

solve([
    'Pesho -> Duck -> 400',
    'Julius -> Shield -> 150',
    'Gladius -> Heal -> 200',
    'Gladius -> Support -> 250',
    'Gladius -> Support -> 50',
    'Pesho vs Gladius',
    'Gladius vs Julis',
    'Gladius vs Gosho',
    'Ave Cesar'
]
);
