function solve(data) {
    var gladiators = {};
    while(data) {
        let row = data.shift();
        if (row === 'Ave Cesar') break;
        if (row.includes(" -> ")) addGladiator(row,gladiators);
        else if (row.includes(" vs ")) fightGladiator(row,gladiators)
    }
    let sorted = Object.keys(gladiators).sort((a, b) => {
        let result = getTotalPoints(gladiators[b]) - getTotalPoints(gladiators[a]);
        if (result === 0) result = a.localeCompare(b);
        return result;
    });
    sorted.map(x => {
        console.log(`${x}: ${getTotalPoints(gladiators[x])} skill`);
        getSortedSkills(gladiators[x]).map(y => {
            console.log(`- ${y} <!> ${gladiators[x][y]}`);            
        }) 
    });       
    function addGladiator(row,a) {
        let [glad, tech, skill] = row.split(" -> ");
        if (!a.hasOwnProperty(glad)) a[glad] = {};
        if (a[glad].hasOwnProperty(tech)) {
            if (a[glad][tech] < Number(skill))
                a[glad][tech] = Number(skill);
        }
        else a[glad][tech] = Number(skill);
    }
    function fightGladiator(row,a) {
        let [glad1, glad2] = row.split(" vs ");
        if (a.hasOwnProperty(glad1) && a.hasOwnProperty(glad2)) {
           for (const tech in a[glad1]) {
                if (a[glad2][tech]) {
                  if (getTotalPoints(a[glad1]) > getTotalPoints(a[glad2])) delete a[glad2];
                  else if (getTotalPoints(a[glad1]) < getTotalPoints(a[glad2])) delete a[glad1];
                  break;
                }
            }           
        }
    }    
    function getTotalPoints(glad) {
        return Object.keys(glad).reduce((a, b) => a + glad[b], 0);
    }
    function getSortedSkills(c){
        return Object.keys(c).sort((a, b) => {
            let result = c[b] - c[a];
            if (result === 0) result = a.localeCompare(b);
            return result;
        });
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
