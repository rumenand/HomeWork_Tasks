var person = (function () {
    var initialString = '';
 
    function append(input) {
        this.initialString += input;
    }
 
    function print() {
        console.log(this.initialString);
    }
 
    return {
        append,
        initialString,
        print
    }
})();
 
 
person.initialString = 'test1';
person.append('test2');
console.log(person.initialString);
person.print();
