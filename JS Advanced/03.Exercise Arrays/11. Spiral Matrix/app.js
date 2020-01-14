function solve(x, y) {
    let matrix = getMatrix(x,y);
    let forPrint = spiral(matrix);
    matrix = [];
    for(const i in forPrint){
        if (forPrint[i]) matrix[forPrint[i]-1] = Number(i)+1;
    }
    let num = 0;
    for (let i = 0; i < x; i++) {
        console.log(matrix.slice(i*x,i*x+y).join(" "));
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
        let matrix = [];
        let num = 1;
        for (let i = 0; i < x; i++) {
            let row = [];
            for (let j = 0; j < y; j++) {
                row.push(num);
                num++;
            }
            matrix.push(row);
        }
        return matrix;
    }
}
solve(3,3);