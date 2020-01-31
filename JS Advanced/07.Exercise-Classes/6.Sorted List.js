class List{
    size;
    arr;
    constructor(){
        this.arr = [];
        this.size = 0;
    }    
    add(x){
        this.arr.push(x);
        this.sortArr();
        this.size++;
    }
    remove(x){
        if (this.isInRange(x)&& this.size !==0) {
            this.arr.splice(x,1);
            this.size --;
        } 
    }
    get(x){
        if (this.isInRange(x)) return this.arr[x];
    }
    isInRange(x){
        if (x<0 || x>this.size) throw console.error(`Index ${x} out of bounds`);
        return true;
    }
    sortArr(){
        this.arr = this.arr.sort((a,b) => a-b);
    }
}

let list = new List();
list.add(5);
list.add(3);
console.log(list.get(0)); 
list.remove(0);
console.log(list.get(0)); 
//console.log(list.get(0)); 

