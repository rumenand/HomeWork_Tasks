function solve(data1, data2) {
    let kingdoms = data1.reduce((a, b) => {
        if (!a.hasOwnProperty(b.kingdom)) a[b.kingdom] = {};
        if (!a[b.kingdom].hasOwnProperty(b.general)) {
            a[b.kingdom][b.general] = {};
            a[b.kingdom][b.general].army = 0;
            a[b.kingdom][b.general].wins = 0;
            a[b.kingdom][b.general].losses = 0;
        }
        a[b.kingdom][b.general].army += b.army;        
        return a;
    }, {});
    for (const i in data2) {
        let [site1, gen1, site2, gen2] = data2[i];
        if ((site1 !== site2) && kingdoms.hasOwnProperty(site1) && kingdoms.hasOwnProperty(site2)) {
            if (kingdoms[site1].hasOwnProperty(gen1) && kingdoms[site2].hasOwnProperty(gen2)) {
                performFight(kingdoms[site1][gen1], kingdoms[site2][gen2]);
            }
        }
    }    
    function performFight(x, y) {
        if (x.army != y.army) {
            if (x.army > y.army) {
                win(x);
                loser(y);
            }
            else {
                win(y);
                loser(x);
            }
        }
    }
    function win(z) {
        z.army = Math.floor(z.army + z.army * 0.1);
        z.wins += 1;
    }
    function loser(z) {
        z.army = Math.floor(z.army - z.army * 0.1);
        z.losses += 1;
    }
    let sorted = Object.keys(kingdoms).sort((a, b) => {
        let ch = getTotalWins(kingdoms[a]);
        let result = getTotalWins(kingdoms[b]) - getTotalWins(kingdoms[a]);
        if (result == 0) result = getTotalLosses(kingdoms[a]) - getTotalLosses(kingdoms[b]);
        if (result == 0) result = a.localeCompare(b);
        return result;
    });
    let genSorted = Object.keys(kingdoms[sorted[0]]).sort((a, b) => {
        return kingdoms[sorted[0]][b].army - kingdoms[sorted[0]][a].army;
    });
    console.log(`Winner: ${sorted[0]}`);
    for (const gen in genSorted) {        
        console.log(`/\\general: ${genSorted[gen]}`);
        console.log(`---army: ${kingdoms[sorted[0]][genSorted[gen]].army}`);
        console.log(`---wins: ${kingdoms[sorted[0]][genSorted[gen]].wins}`);
        console.log(`---losses: ${kingdoms[sorted[0]][genSorted[gen]].losses}`);     
    }   
    function getTotalWins(site) {
        return Object.keys(site).reduce((a, b) => a + site[b].wins, 0);
    }
    function getTotalLosses(site) {
        return Object.keys(site).reduce((a, b) => a + site[b].losses, 0);
    }
}

solve([{ kingdom: "Maiden Way", general: "Merek", army: 5000 },
{ kingdom: "Stonegate", general: "Ulric", army: 4900 },
{ kingdom: "Stonegate", general: "Doran", army: 70000 },
{ kingdom: "YorkenShire", general: "Quinn", army: 0 },
{ kingdom: "YorkenShire", general: "Quinn", army: 2000 }],
    [["YorkenShire", "Quinn", "Stonegate", "Doran"],
    ["Stonegate", "Ulric", "Maiden Way", "Merek"]]

);
