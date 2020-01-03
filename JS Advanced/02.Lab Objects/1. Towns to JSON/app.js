'use strict';
function solve(a) {
    var keys = customSpliter(a[0]);
    let towns = a.slice(1).map(row =>
        customSpliter(row).reduce((acc, cur, i) => {
            if (i > 0) cur = Math.round(Number(cur) * 1e2) / 1e2;
            acc[keys[i]] = cur;
            return acc;
        }, {}));

    console.log(JSON.stringify(towns));

    function customSpliter(a) {
        return a.split("|").filter((x) => x != "").map((x) => x.trim());
    }
}
solve(['| Town | Latitude | Longitude |',
'| Veliko Turnovo | 43.0757 | 25.6172 |',
'| Monatevideo | 34.50 | 56.11 |']
);
