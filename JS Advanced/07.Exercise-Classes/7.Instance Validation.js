class CheckingAccount{
    constructor(id,email,fName,lName){
        this.isIdValid(id);
        this.id = id;
        this.isEmailValid(email);
        this.email = email;
        this.chValidNameLength(fName,'First');
        this.chValidNameSymbols(fName,'First');
        this.firstName = fName;
        this.chValidNameLength(lName,'Last');
        this.chValidNameSymbols(lName,'Last');
        this.lastName = lName;  
    }
    isIdValid(a){
        if(a.length !==6 && !isNaN(Number(a))) throw TypeError('Client ID must be a 6-digit number');
    }
    isEmailValid(a){
        if (!/^[a-zA-Z]+@[a-zA-z\.]+/.test(a))
        throw TypeError('Invalid e-mail');
    }
    chValidNameLength(a,b){
        if (a.length<3 || a.length > 20)
        throw TypeError(`${b} name must be between 3 and 20 characters long`)
    }
    chValidNameSymbols(a,b){
        if (!/^[a-zA-Z]+$/.test(a)) 
        throw TypeError(`${b} name must contain only Latin characters`);
    }
}

let acc = new CheckingAccount('131455', 'ivan@some.com', 'Ivan', 'P3trov')