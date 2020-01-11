function solve(data) {
    let rot = data.pop();
    for (let i = 0; i < rot; i++) {
        data.unshift(data.pop());
    }
    console.log(data.join(" "));
}
solve([1,2,3,4,2]);