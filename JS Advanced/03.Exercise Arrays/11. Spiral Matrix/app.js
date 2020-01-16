function solve(x, y) {
    let forPrint = spiral(getMatrix(x,y));
    let route = spiral(getMatrix(x,y)).reduce((a,b,i) => {
        a[b-1] = i+1;
        return a;
    },[]);
    matrix = [];
    for(const i in forPrint){
        if (forPrint[i]) matrix[forPrint[i]-1] = Number(i)+1;
    }
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
    function getMatrix(x, y) {
        let matrix = Array.from(Array(x), () => new Array(y));   
        for (let i in matrix) {
            for (let j = 0; j < y; j++) {
                matrix[i][j] = i*y+j+1;
            }
        }
        return matrix;
    }
}
solve(3,3);