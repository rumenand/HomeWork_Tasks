function solve(a,b){
    let sorter = filter();
    console.log(sorter[b](a));
    function filter()
    {
    return {
        asc: (s) => s.sort((a,b) => a-b),
        desc: (s) => s.sort((a,b) => b-a)
        }
    }
}
solve([14, 7, 17, 6, 8], 'desc');