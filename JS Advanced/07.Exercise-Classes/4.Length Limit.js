class Stringer{
    constructor (str,length){
        this.innerString  = str;
        this.innerLength = length;
    }
    decrease(x) {
        this.innerLength -=x;
        if (this.innerLength<0) this.innerLength = 0;
    }
    increase(x) {
        this.innerLength +=x;
    }
    toString() {
        if (this.innerLength===0) return '...';
        if (this.innerLength<this.innerString.length)
        return this.innerString.substring(0,this.innerLength)+'...';
        return this.innerString;
    }    
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...
test.increase(4); 
console.log(test.toString());


