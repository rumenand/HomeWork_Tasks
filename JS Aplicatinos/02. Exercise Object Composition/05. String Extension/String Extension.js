(function solve (){
    String.prototype.ensureStart = function(x) {
        const chStr = this.substring(0,x.length);
        if (chStr !== x) return x+this;
        return this.toString();
    };
    String.prototype.ensureEnd = function(x){
        if (!this.includes(x)) return this+x;
        return this.toString();
    };
    String.prototype.isEmpty =  function(){
        if (this.toString() === '' ) return true;
        return false;
    };
    String.prototype.truncate =  function(x){
        if (this.length <x) return this.toString();
        if (x<4) return '.'.repeat(x);
        const arr = this.toString().split(' ');
        if (arr.length === 1) return this.substring(0,x-3)+'...';
        let str = '';
        for (const w of arr){
            if ((str.length+w.length+3) <= x) str +=w+' ';
            else break;
        }
        return str.trim()+'...';
    };
    String.format =  function(x){
        let para = [...arguments];
        let str = para.shift();
        para.map((x,i)=>{
            str = str.replace(`{${i}}`,x);
        }); 
        return str;
    }
}())

let str = 'my string';
str = str.ensureStart('my');
console.log(str);
str = str.ensureStart('hello ');
console.log(str);
str = str.truncate(16);
console.log(str);
str = str.truncate(14);
console.log(str);
str = str.truncate(8);
console.log(str);
str = str.truncate(4);
console.log(str);
str = str.truncate(2);
console.log(str);
str = String.format('The {0} {1} fox',
  'quick', 'brown');
  console.log(str);
str = String.format('jumps {0} {1}',
  'dog');
  console.log(str);
  console.log(''.isEmpty())
