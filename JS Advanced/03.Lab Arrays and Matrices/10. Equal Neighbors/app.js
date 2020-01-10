function solve(data) {
    let eq = 0;
    for (var i = 1; i < data.length; i++) {
        for (var j = 0; j < data[i].length-1; j++) {
            if (data[i - 1][j] === data[i][j]) eq++;
            if (data[i][j] == data[i][j + 1]) eq++;
        }
    }
    console.log(eq);
}
solve([['test', 'yes', 'yo', 'ho'],
['well', 'done', 'yo', '6'],
['not', 'done', 'yet', '5']]
);
