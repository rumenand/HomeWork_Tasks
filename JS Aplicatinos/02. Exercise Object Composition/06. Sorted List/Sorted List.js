function solve(){    
    const processArr = function () {
            this.list = this.list.sort((a,b) => a-b);
            this.size = this.list.length;
    }
    const add = function(elemenent){
        this.list.push(elemenent);
        this.processArr();
    }
    const remove = function(index){
        if(index>=0){
        this.list.splice(index,1);
        this.processArr();
        }
    }
    const get = function(index){
        return this.list[index];
    }
  
    return Object.assign({},{list:[],size:0,processArr,add,remove,get})
}

let list = solve()
list.add(9);
list.add(5);
list.remove(-1)
console.log(list.get(0));
console.log(list.size);