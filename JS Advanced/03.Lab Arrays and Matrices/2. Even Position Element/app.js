function solve(a) {
    console.log(a.reduce((a, b, i) => {
        if (i % 2 == 0) a.push(b);
        return a;
    }, []).join(" "));
}
solve(['20', '30', '40']);
