class Hex {
    constructor(value){
        this.value = value;
    }
    valueOf(){
        return this.value;
    }
    toString(){
        return `0x${this.value.toString(16).toUpperCase()}`;
    }
    plus(number){
        let num =0;
        if (typeof(number) === 'number'){
            num = number + this.value;
        }
        else if (typeof(number) === "object"){
            num = this.value + number.valueOf();
        }
        return new Hex(num);
    }
    minus(number){
        number -= this.value;
        return new Hex(number);
    }
    parse(string){
        return parseInt(string, 16);
    }
}

let FF = new Hex(255);
console.log(FF.toString());
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString()==='0xF');

