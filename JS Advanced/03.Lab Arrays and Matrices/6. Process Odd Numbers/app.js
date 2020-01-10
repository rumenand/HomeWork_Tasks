function solve(data) {
    console.log(data.reduce((a, b, i) => {
        if (i % 2 != 0) a.push(b*2);
        return a;
    }, []).reverse().join(" "));
}
solve([10, 15, 20, 25]);
