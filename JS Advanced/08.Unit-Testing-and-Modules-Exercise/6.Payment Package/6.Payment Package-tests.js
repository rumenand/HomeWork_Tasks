const PaymentPackage = require('./6.Payment Package.js')
const expect = require("chai").expect;

describe('PaymentPackage', function() {
         it('Test valid constructor', function () {
            const package = new PaymentPackage('Pesho',20);
            expect(package.toString()).equal('Package: Pesho\n- Value (excl. VAT): 20\n- Value (VAT 20%): 24');
            expect(package.name).equal('Pesho');
            expect(package.value).equal(20);
            expect(package.VAT).equal(20);
            expect(package.active).equal(true);
         })
         it('Test setup with only with name', function () {
            expect(() => new PaymentPackage('M')).to.throw();
         })
         it('Test setup with non-string name', function () {
            expect(() => new PaymentPackage(2,3)).to.throw();
         })
         it('Test setup with empty string name', function () {
            expect(() => new PaymentPackage('',3)).to.throw();
         })
         it('Test setup with non-number value', function () {
            expect(() => new PaymentPackage('dd','w')).to.throw();
         })
         it('Test setup with negative number value', function () {
            expect(() => new PaymentPackage('dd',-1)).to.throw();
         })
         it('Test to set negative number VAT', function () {
            const package = new PaymentPackage('Pesho',20);
            expect(() => (package.VAT = -20)).to.throw();
         })
         it('Test to set non number VAT', function () {
            const package = new PaymentPackage('Pesho',20);
            expect(() => (package.VAT = 'z')).to.throw();
         })
         it('Test to set non boolean active prop', function () {
            const package = new PaymentPackage('Pesho',20);
            expect(() => (package.active = 'z')).to.throw();
         })
         it('Should have instance type', function(){
            expect(PaymentPackage.prototype).to.have.property('name');
            expect(PaymentPackage.prototype).to.have.property('value');
            expect(PaymentPackage.prototype).to.have.property('VAT');
            expect(PaymentPackage.prototype).to.have.property('active');
            expect(PaymentPackage.prototype).to.have.property('toString');
            })
        it("Test creating inactive package", function(){
            let package = new PaymentPackage("gosho", 1000);
            package.active = false;
            let expected = "Package: gosho (inactive)\n"+
                "- Value (excl. VAT): 1000\n"+
                "- Value (VAT 20%): 1200";
            expect(expected).to.equal(package.toString());
            })
        it("zero value get/set", function() {
            let actual = new PaymentPackage("str", 5);
               actual.value = 0;                 
               expect(actual.value).to.equal(0);
            });                       
});