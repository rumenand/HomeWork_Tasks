function solve(){
    return {
        extend: function (obj) {
           for (const pr in obj){
            (typeof obj[pr] === 'function')
            ?Object.getPrototypeOf(this)[pr] = obj[pr]
            :this[pr] = obj[pr];
           }

        }
    }
}