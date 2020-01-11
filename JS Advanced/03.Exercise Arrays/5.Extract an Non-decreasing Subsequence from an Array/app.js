function solve(data) {
    console.log(data.filter((e, i) => e >= Math.max.apply(null, data.slice(0, i)))
        .join("\n"));
}
solve([1, 3, 8, 4, 10, 12, 3, 2, 24]);
