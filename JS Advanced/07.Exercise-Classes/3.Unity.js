    class Rat{
        constructor (name){
            this.name = name;
            this.repo = [];
        }
        unite(x) {
            if (x instanceof Rat) this.repo.push(x);
            }
        toString() {
            let str = this.name;
            this.repo.map(x=> str +=`\n##${x.name}`)
            return str;
        }
        getRats() {return this.repo};
    }
    
    let firstRat = new Rat("Peter");
   console.log(firstRat.toString()); // Peter
     
    console.log(firstRat.getRats()); // []
    
    firstRat.unite(new Rat("George"));
    firstRat.unite(new Rat("Alex"));
    console.log(firstRat.getRats());
    // [ Rat { name: 'George', unitedRats: [] },
    //  Rat { name: 'Alex', unitedRats: [] } ]
    
    console.log(firstRat.toString());
    