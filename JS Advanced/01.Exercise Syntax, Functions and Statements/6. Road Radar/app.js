'use strict';
function solve(a) {
    var limits = { motorway: 130, interstate: 90, city: 50, residential: 20 };
    let result = "";
    if (limits[a[1]] > 0) result = getSentence(a[0] - limits[a[1]]);
    console.log(result);

    function getSentence(diff) {
        let res = "";
        if (diff <= 0) res = "";
        else if (diff <= 20) res = "speeding";
        else if (diff <= 40) res = "excessive speeding";
        else res = "reckless driving";
        return res;
    }
}
solve([120, 'interstate']);
