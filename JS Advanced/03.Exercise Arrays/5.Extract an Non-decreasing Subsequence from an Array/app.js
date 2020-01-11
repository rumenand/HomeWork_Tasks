function solve(data) {
    console.log(data.reduce((a, b, i) => {
        if (i == 0) a.push(b);
        else if (b >= a[a.length - 1]) a.push(b);
        return a;
    }, []).join("\n"));
}
solve([1, 3, 8, 4, 10, 12, 3, 2, 24]);
