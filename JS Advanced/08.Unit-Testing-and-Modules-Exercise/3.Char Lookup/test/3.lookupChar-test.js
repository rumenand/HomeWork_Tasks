const expect = require("chai").expect;
const lookupChar = require('../3.lookupChar.js');

describe('lookupChar',function(){
    it('should return undefined if non-string first param',function (){
        expect(lookupChar(13,0)).to.equal(undefined,'The function is not working correct');
    });
    it('should return undefined if non-number second param',function (){
        expect(lookupChar('ww','2')).to.equal(undefined,'The function is not working correct');
    });  
    it('should return undefined if float number second param',function (){
        expect(lookupChar('ww',2.33)).to.equal(undefined,'The function is not working correct');
    });   
    it('should return Incorrect index if less then zero second param',function (){
        expect(lookupChar('ww',-1)).to.equal("Incorrect index",'The function is not working correct');
    });
    it('should return Incorrect index if bigger then length second param',function (){
        expect(lookupChar('ww',100)).to.equal("Incorrect index",'The function is not working correct');
    });
    it('should return Incorrect index if equal to length second param',function (){
        expect(lookupChar('ww',2)).to.equal("Incorrect index",'The function is not working correct');
    });
    it('should return correct answer if first and second param are correct',function (){
        expect(lookupChar('wwwedwe',6)).to.equal("e",'The function is not working correct');
    });
    it('should return correct answer if first and second param are correct',function (){
        expect(lookupChar('wwwedwe',0)).to.equal("w",'The function is not working correct');
    });
});