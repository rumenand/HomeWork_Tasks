const expect = require("chai").expect;
const isOddOrEven = require('./2.Even or Odd.js');

describe('isOddOrEven',function(){
    it('should return undefined if non-string first param',function (){
        expect(isOddOrEven(13)).to.equal(undefined,'The function is not working correct');
    }); 
    it('should return undefined if no first param',function (){
        expect(isOddOrEven()).to.equal(undefined,'The function is not working correct');
    }); 
    it('should return correct res if string is passed',function (){
        expect(isOddOrEven('www')).to.equal('odd','The function is not working correct');
    }); 
    it('should return correct res if string is passed',function (){
        expect(isOddOrEven('wewe')).to.equal('even','The function is not working correct');
    }); 
    it('should return correct res if empty string is passed',function (){
        expect(isOddOrEven('')).to.equal('even','The function is not working correct');
    }); 
});