function solve(a) {
    console.log(a.reduce((a, b) => {
        if (b >= 0) a.push(b);
        else a.unshift(b);
        return a;
    }, []).join("\n"));
}
solve([7, -2, 8, 9]);
