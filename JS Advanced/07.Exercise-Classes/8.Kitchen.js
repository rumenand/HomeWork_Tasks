class Kitchen{
    budget; 
    menu = {};
    productsInStock = {};
    actionsHistory = [];

    constructor(budget){
        this.budget = budget;
    }

    loadProducts(a){
        a.map(x=>{
            const b =x.split(' ');
            if (this.isAffordable(b[2])){
                this.addProduct(b);
                this.actionsHistory.push(`Successfully loaded ${b[1]} ${b[0]}`);
            }
            else   this.actionsHistory.push(`There was not enough money to load ${b[1]} ${b[0]}`);           
        })        
        return this.actionsHistory.join('\n').trim();
    }
    addToMenu(a,b,c){
    if (!this.menu.hasOwnProperty(a)){        
       this.menu[a]={};
       this.menu[a]['price']=Number(c);
       this.menu[a]['products'] = b;
       return `Great idea! Now with the ${a} we have ${Object.keys(this.menu).length} meals in the menu, other ideas?`;
    }
    return `The ${a} is already in our menu, try something different.`;
    }
    showTheMenu(){
        let result = '';
        Object.keys(this.menu).map(x=>{
            result +=`${x} - $ ${this.menu[x]['price']}\n`;
        })
        if (result ==='') result +='Our menu is not ready yet, please come later...';
        return result;
    }
    makeTheOrder(a){
        if (!this.menu.hasOwnProperty(a)){ 
            return `There is not ${a} yet in our menu, do you want to order something else?`; 
        }
        if (!this.hasProds(this.menu[a]['products'])){
            return `For the time being, we cannot complete your order (${a}), we are very sorry...`
        }
        this.budget += this.menu[a]['price'];
        this.removeProds(this.menu[a]['products']);
        return `Your order (${a}) will be completed in the next 30 minutes and will cost you ${this.menu[a]['price']}.`;
    }
    addProduct(a){
        if (!this.productsInStock.hasOwnProperty(a[0])){
            this.productsInStock[a[0]] = 0;
        }
        this.productsInStock[a[0]]+=Number(a[1]);
        this.budget -= Number(a[2]);
    }
    isAffordable(a){
        return Number(a)<=this.budget;
    }
    hasProds(a){
        for (const pr of a) {
            const tk = pr.split(' ');
            if (!this.productsInStock.hasOwnProperty(tk[0])
            || this.productsInStock[tk[0]]<Number(tk[1]))
            return false;
        }
        return true;
    }
    removeProds(a){
        a.map(x=>{
            const b = x.split(' ');
            this.productsInStock[b[0]] -= Number(b[1]);
        })
    }
}