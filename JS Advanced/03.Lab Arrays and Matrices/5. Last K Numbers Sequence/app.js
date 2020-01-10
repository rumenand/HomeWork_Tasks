function solve(n,k) {
    let arr = [1];
    for (let i = 1; i < n; i++) {
        let stInd = ((i - k) < 0) ? 0 : i - k;
        let kSum = arr.slice(stInd, i).reduce((a, b) => a + b);
        arr.push(kSum);
    }
    console.log(arr.join(" "));
}
solve(8,2);
