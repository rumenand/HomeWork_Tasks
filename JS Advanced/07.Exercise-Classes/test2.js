class person{
    name = '';
     append(x) {
        name +=x;
    }
    print(){
        console.log(name)
    }
}

let p = new person();
p.print();
p.name = 'Pesho';
p.print();
p.append(' Petrov');
p.print();