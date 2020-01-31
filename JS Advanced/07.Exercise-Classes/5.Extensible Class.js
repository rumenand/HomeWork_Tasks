let p = (() => {
    let id = 0;
    return class Extensible {
        constructor() {
            this.id = id;
            id++;
        }
        extend(template) {
            Object.keys(template).map(x=>{
                (typeof (template[x]) === 'function')
                ? Object.getPrototypeOf(this)[x] = template[x]
                :this[x] = template[x];
            })
        }
    }
})();


let obj1 = new p();
let obj2 = new p();
let obj3 = new p();
console.log(obj1.id);
console.log(obj2.id);
console.log(obj3.id);
