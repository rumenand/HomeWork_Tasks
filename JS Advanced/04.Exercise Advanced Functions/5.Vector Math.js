(function() {  
    return {
        add: (a,b) => [a[0]+ b[0],a[1]+b[1]],
        multiply: (a,b) => [a[0]*b, a[1]*b],
        length: (a,b) => Math.sqrt(a[0]**2 + a[1]**2),
        dot: (a,b) => a[0]*b[0] + a[1]*b[1],
        cross: (a,b) => a[0]*b[1] - a[1]*b[0]
    }
}())
console.log(solution.add([1,1],[1,0]));
solution.cross([3, 7], [1, 0]);