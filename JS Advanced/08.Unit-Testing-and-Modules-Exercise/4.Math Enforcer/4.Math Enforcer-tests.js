const expect = require("chai").expect;
const mathEnforcer = require('./4.Math Enforcer.js');

describe('mathEnforcer',function(){
    it('should return undefined if non-number first param addFive function',function (){
        expect(mathEnforcer.addFive('a')).to.equal(undefined,'The function is not working correct');
    });  
    it('should return correct if number first param addFive function',function (){
        expect(mathEnforcer.addFive(5)).to.equal(10,'The function is not working correct');
    });   
    it('should return correct if number first param floating addFive function',function (){
        expect(mathEnforcer.addFive(5.23)).to.equal(10.23,'The function is not working correct');
    }); 
    it('should return correct if number first param negative addFive function',function (){
        expect(mathEnforcer.addFive(-5)).to.equal(0,'The function is not working correct');
    }); 
    it('should return correct if number first param negative addFive function',function (){
        expect(mathEnforcer.addFive(-5.25)).to.equal(-0.25,'The function is not working correct');
    });  
    it('should return correct result with floating point value', function(){
        expect(mathEnforcer.addFive(5.50)).to.be.closeTo(10.50, 0.01);
    })   
    it('should return undefined if non-number first param subtractTen function',function (){
        expect(mathEnforcer.subtractTen('a')).to.equal(undefined,'The function is not working correct');
    });  
    it('should return correct if number first param subtractTen function',function (){
        expect(mathEnforcer.subtractTen(15)).to.equal(5,'The function is not working correct');
    });
    it('should return correct if number first param floating subtractTen function',function (){
        expect(mathEnforcer.subtractTen(15.23)).to.equal(5.23,'The function is not working correct');
    }); 
    it('should return correct if number first param floating negative subtractTen function',function (){
        expect(mathEnforcer.subtractTen(-10)).to.equal(-20,'The function is not working correct');
    }); 
    it('should return undefined if non-number first param sum function',function (){
        expect(mathEnforcer.sum('a',2)).to.equal(undefined,'The function is not working correct');
    });  
    it('should return undefined if non-number second param sum function',function (){
        expect(mathEnforcer.sum(2,'2')).to.equal(undefined,'The function is not working correct');
    }); 
    it('should return correct if number first and second param sum function',function (){
        expect(mathEnforcer.sum(15,8)).to.equal(23,'The function is not working correct');
    });
    it('should return correct if number first and second param floating sum function',function (){
        expect(mathEnforcer.sum(5.5,5.5)).to.equal(11,'The function is not working correct');
    });
    it('should return correct if number first and second param floating negative sum function',function (){
        expect(mathEnforcer.sum(5.5,-5.5)).to.equal(0,'The function is not working correct');
    });
});