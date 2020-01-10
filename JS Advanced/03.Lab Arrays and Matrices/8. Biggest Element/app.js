function solve(data) {
    console.log(data.reduce((a, b) => {
        let big = Math.max(...b);
        if (a < big) a = big;
        return a;
    },- Number.MAX_VALUE));
}
solve([[3, 5, 7, 12],
[-1, 4, 33, 2],
[8, 3, 0, 4]]
);
