function solve(data) {
    let k = data[0];
    console.log(data.slice(1).slice(0, k).join(" "));
    console.log(data.slice(1).slice(data.length-k-1, data.length).join(" "));
}
solve([3,
    6, 7, 8, 9]);
