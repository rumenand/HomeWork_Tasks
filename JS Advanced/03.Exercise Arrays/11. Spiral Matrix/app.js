function solve(x, y) {
    let route = spiral(getMatrix(x,y)).reduce((a,b,i) => {
        a[b-1] = i+1;
        return a;
    },[]);
    for (let i = 0; i < x; i++) {
        console.log(route.slice(i*x,i*x+y).join(" "));
    }   
    function spiral(matrix) {
        const arr = [];        
        while (matrix.length) {
            arr.push(
                ...(matrix.shift()),
                ...matrix.map(a => a.pop()),
                ...(matrix.pop() || []).reverse(),
                ...matrix.map(a => a.shift()).reverse()
            );
        }
        return arr;
    }
    function getMatrix(a, b) {
        return Array.from(Array(a), () => new Array(b)).map((x,i) => {
            for (let j = 0; j < b; j++)  x[j] = i*b+j+1;
            return x;
        });   
    }
}
solve(3,3);