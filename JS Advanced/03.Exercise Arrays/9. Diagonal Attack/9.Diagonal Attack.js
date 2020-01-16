function solve(data){
    const getSum = (a,b) => a.reduce((a,b) => a + b);
    const modifyMatrix = (m,sum) => {
       return m.map((x,i) =>{ 
        return x.map((y,j) => {
            if (j!==i && j!==m.length-1-i ) y=sum;
            return y;
        });
      });
    }
    const printMatrix = (a) => a.map(x=>console.log(x.join(" ")));
    let matrix = data.reduce((a,b) => {
        a.push(b.split(" ").map(Number));
        return a;
    },[]);
    let fDiag = getSum(matrix.map((x,i) => x[i]));
    let sDiag = getSum(matrix.map((x,i) => x[matrix.length-1-i]));
    if (fDiag === sDiag) matrix = modifyMatrix(matrix,fDiag);
    printMatrix(matrix);
}
solve(['5 3 12 3 1',
'11 4 23 2 5',
'101 12 3 21 10',
'1 4 5 2 2',
'5 22 33 11 1']
)