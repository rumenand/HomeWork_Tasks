function solve(a){
let matrix = Array.from(Array(a[0]), () => new Array(a[1]))
            .map((x,i) =>{
                for (let col = 0; col < a[1]; col++) {
                x.push(Math.max(Math.abs(i - a[2]), Math.abs(col - a[3])) + 1);                   
                }
                return x;
            })
matrix.map(row => console.log(row.join(" ")));
}
solve([4,4,0,0])