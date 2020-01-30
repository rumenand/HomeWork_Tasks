function solve(a,b){
    class Ticket{
        constructor (destination,price,status){
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }
    function adjSort(x,b){
        if (isNaN(x[0][b])){
            return  x.sort((y,z)=>y[b].localeCompare(z[b]));
        }
        return x.sort((y,z) => y[b]-z[b]);
    }
    return adjSort(a.map(x=>new Ticket(...x.split('|'))),b);   
}
console.log(solve(['Philadelphia|94.20|available'], 'price'
))