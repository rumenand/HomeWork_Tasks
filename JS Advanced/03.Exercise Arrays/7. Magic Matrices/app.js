function solve(data) {
    const allEqual = arr => arr.every(v => v === arr[0]);
    let sameRows = (x) => allEqual([...x.map((a) => a.reduce((x, y) => x + y))]);
    let sameCols = (x) => allEqual([...x.reduce((a, b) => a.map((y, i) => y + b[i]))]);    
    console.log(sameRows(data) && sameCols(data));
}
solve([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]);
