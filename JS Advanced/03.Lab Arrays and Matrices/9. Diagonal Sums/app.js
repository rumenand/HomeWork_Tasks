function solve(data) {
    let d1 = 0, d2 = 0;
    for (var i = 0; i < data.length; i++) {
        d1 += data[i][i];
        d2 += data[i][data.length - i - 1];
    }
    console.log(`${d1} ${d2}`);
}
solve([[20, 40],
[10, 60]]);