function solve(str) {
    return JSON.stringify(str
        .join("")
        .match(/\w+/gim)
        .reduce((a, b) => {
            if (typeof a[b] === "undefined") a[b] = 0;
            a[b]++;
            return a;
        }, {}));
}

console.log(solve(['Far too slow, you\'re far too slow.']));
