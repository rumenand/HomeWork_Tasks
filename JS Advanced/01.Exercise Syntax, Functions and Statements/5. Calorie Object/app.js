'use strict';
function solve(a) {
    let obj = {};
    for (let i = 0; i < a.length - 1; i++) {
        if (i % 2 == 0) obj[a[i]] = a[i + 1];
    }
    
    let result = "{ ";  
    result += Object.keys(obj).map(function (k) { return `${k}: ${obj[k]}` }).join(", ");
    result += " }"
    console.log(result);
}
solve(['Yoghurt', 48, 'Rise', 138, 'Apple', 52]);
