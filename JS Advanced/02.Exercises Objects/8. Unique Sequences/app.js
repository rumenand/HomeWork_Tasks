function solve(data) {
    let arrs = data.reduce((a, b) => {
        let arr = JSON.parse(b).sort((x, y) => y - x);        
        a.set(`[${arr.join(', ')}]`, arr.length);
        return a;
    }, new Map());

    let sorted = [...arrs].sort((a, b) => a[1] - b[1])
        .map(a => a[0])
        .join("\n");
    console.log(sorted);
}

solve(["[7.14, 7.180, 7.339, 80.099]",
    "[7.339, 80.0990, 7.140000, 7.18]",
    "[7.339, 7.180, 7.14, 80.099]"]
);
