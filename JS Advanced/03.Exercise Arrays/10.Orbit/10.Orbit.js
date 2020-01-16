function solve(a){
let matrix = Array.from(Array(a[0]), () => new Array(a[1]));
for(let row = 0; row< a[0]; row++) {
    for(let col=0; col<a[1]; col++) {
        matrix[row][col] = Math.max(Math.abs(row - a[2]), Math.abs(col - a[3])) + 1;
    }
}
matrix.map(row => console.log(row.join(" ")));
}
solve([4,4,0,0])