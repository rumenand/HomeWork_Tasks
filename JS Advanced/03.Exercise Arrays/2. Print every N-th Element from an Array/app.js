function solve(a) {
    for (let i = 0; i < a.length - 1; i += Number(a[a.length-1])) {
        console.log(a[i]);
    }
}
solve(['dsa', 'asd', 'test', 'tset', '2']);
