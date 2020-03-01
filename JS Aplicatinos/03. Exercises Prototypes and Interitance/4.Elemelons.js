function solve(){
    class Melon{
        constructor(weight,melonSort){
            if (new.target === Melon){
                throw new Error('Abstract class cannot be instantiated directly');
            }
            this.weight = weight;
            this.melonSort = melonSort;
        }
        get elementIndex(){
            return this.weight* this.melonSort.length;
        }
        toString(){
            let str ='';
            let name = this.constructor.name.replace('melon','');
            str += `Element: ${name}\n`;
            str += `Sort: ${this.melonSort}\n`;
            str += `Element Index: ${this.elementIndex}`;
            return str;
        }       
    }
    class Watermelon extends Melon{
        constructor(weiht,melonSort){
            super(weiht,melonSort);
        }
    } 
    class Firemelon extends Melon{
        constructor(weiht,melonSort){
            super(weiht,melonSort);
        }
    } 
    class Earthmelon extends Melon{
        constructor(weiht,melonSort){
            super(weiht,melonSort);
        }
    }
    class Airmelon extends Melon{
        constructor(weiht,melonSort){
            super(weiht,melonSort);
        }
    } 
    class Melolemonmelon extends Watermelon{
        _index = -1;
        _types = [];
        constructor(weiht,melonSort){
            super(weiht,melonSort);
            this.setTypes();
            this.morph();
        }
        morph(){
            this._index ++;
            if (this._index === 4) this._index = 0;
            this.constructor = this._types[this._index].constructor;
        }
        setTypes(){
            this._types.push(new Watermelon(this.weight,this.melonSort));
            this._types.push(new Firemelon(this.weight,this.melonSort));
            this._types.push(new Earthmelon(this.weight,this.melonSort));
            this._types.push(new Airmelon(this.weight,this.melonSort));            
        }
    }
    return {
        Melon,Watermelon,Firemelon,Earthmelon,Airmelon,Melolemonmelon
    }
}

let classes = solve();
let watermelon = new classes.Melolemonmelon(12.5, "Kingsize");
console.log(watermelon.toString());
watermelon.morph();
console.log(watermelon.toString());
