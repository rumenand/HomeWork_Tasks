const StringBuilder = require('./5.String Builder.js')
const expect = require("chai").expect;
const assert = require("chai").assert;
describe('StringBuilder', function() {
         it('Test constructor with non string', function () {
            expect(() => new StringBuilder(2)).to.throw();
         })
         it('Test constructor with string', function () {
            let str = new StringBuilder('hello');
            expect(str.toString()).equal('hello');
         })
         it('Test append function', function () {
            let str = new StringBuilder('hello');
            str.append(' Pesho');
            expect(str.toString()).equal('hello Pesho');
            expect(() => str.append(11)).to.throw();
         })
         it('Test prepend function', function () {
            let str = new StringBuilder('hello');
            str.prepend('Pesho ');
            expect(str.toString()).equal('Pesho hello');
            expect(() => str.prepend(11)).to.throw();
         })
         it('Test insertAt function', function () {
            let str = new StringBuilder('hello');
            str.insertAt('Pesho',5);
            expect(str.toString()).equal('helloPesho');
            expect(() => str.insertAt(11,2)).to.throw();
         })
         it('Test remove function', function () {
            let str = new StringBuilder('hello');
            str.remove(0,2);
            expect(str.toString()).equal('llo');
         })
         it('Should have instance type', function(){
            expect(StringBuilder.prototype).to.have.property('append');
            expect(StringBuilder.prototype).to.have.property('prepend');
            expect(StringBuilder.prototype).to.have.property('insertAt');
            expect(StringBuilder.prototype).to.have.property('remove');
            expect(StringBuilder.prototype).to.have.property('toString');
            })
            it('Simple input test', function () {
                 let str = new StringBuilder('hello');
                 str.append(', there');
                 str.prepend('User, ');
                 str.insertAt('woop', 5);
                 str.remove(6, 3);
                
                 expect(str.toString()).equal('User,w hello, there');
                 })
});