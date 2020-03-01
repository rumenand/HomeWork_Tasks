//Console = require('./C#Console.js')
//const expect = require("chai").expect;

//describe('Console', function() {    
//           it('Test console write string', function () {
//              expect(Console.writeLine('hi')).to.equal('hi');
//           })
//           it('Test console write object', function () {
//            expect(Console.writeLine({name: 'Me'})).to.equal('{"name":"Me"}');
//         })
//         it("Throw error if no string with more than 1 arg", function () {
//            expect(() => Console.writeLine(15,'coke')).to.throw(TypeError);
//            expect(() => Console.writeLine(15,'coke')).to.throw("No string format given!");
//         })
//         it("Throw error if incorect params", function () {
//            expect(() => Console.writeLine('coke{0},{1}',"2","3","4")).to.throw(RangeError);
//            expect(() => Console.writeLine('coke{0},{1}',"2","3","4")).to.throw("Incorrect amount of parameters given!");
//         })
//         it('Test console write with correct args', function () {
//            expect(Console.writeLine("The sum of {0} and {1} is {2}", "3", "4", "7")).to.equal('The sum of 3 and 4 is 7');
//         })
//         it('Test console write with incorect args', function () {
//            expect(() => Console.writeLine('coke{0},{8}',"2","3")).to.throw(RangeError);
//            expect(() => Console.writeLine('coke {9}','3')).to.throw(RangeError);
//         })
//         it('Should recognize and more digits place holders', function () {
//            expect(() => Console.writeLine('coke {100}','3','4')).to.throw(RangeError);
//         })
//
//});