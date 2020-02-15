let SkiResort = require('./solution');
const expect = require("chai").expect;

describe('SkiResort', function () {     
    it('Test valid constructor', function () {
        const resort = new SkiResort('Ski');
        expect(resort.name).to.equal('Ski');
        expect(resort.voters).to.equal(0);
        expect(resort.hotels.length).to.equal(0);
     })  
     it('Test build hotel', function () {
        const resort = new SkiResort('Ski');
        let result = resort.build('hot',1);
        expect(result).to.equal('Successfully built new hotel - hot');
        expect(resort.hotels.length).to.equal(1);
        expect(resort.hotels[0].name).to.equal('hot');
        expect(resort.hotels[0].beds).to.equal(1);
        expect(resort.hotels[0].points).to.equal(0);
        expect(() => resort.build('',9)).to.throw("Invalid input");
        expect(() => resort.build('aaa',0)).to.throw("Invalid input");
        expect(() => resort.build('aaa',-1)).to.throw("Invalid input");
     })     
     it('Test get best hotel', function () {
        const resort = new SkiResort('Ski');        
        let result = resort.bestHotel;
        expect(result).to.equal('No votes yet');
        resort.build('hot',5);
        expect(resort.bestHotel).to.equal('No votes yet');
     })       
     it('Test book hotel', function () {
        const resort = new SkiResort('Ski');        
        resort.build('new',4);
        const result = resort.book('new',1);
        expect(result).to.equal("Successfully booked");
        expect(resort.hotels[0].beds).to.equal(3);
        expect(() => resort.book('aaa',2)).to.throw("There is no such hotel");
        expect(() => resort.book('new',10)).to.throw("There is no free space");
        expect(() => resort.book('',10)).to.throw("Invalid input");
        expect(() => resort.book('aa',0)).to.throw("Invalid input");
        expect(() => resort.book('aa',-100)).to.throw("Invalid input");
     })  
     it('Test leave hotel', function () {
      const resort = new SkiResort('Ski');        
      resort.build('new',4);
      resort.book('new',2);
      expect(resort.hotels[0].beds).to.equal(2);
      const result = resort.leave('new',2,5);
      expect(result).to.equal("2 people left new hotel");
      expect(resort.bestHotel).to.equal('Best hotel is new with grade 10. Available beds: 4');
      expect(resort.hotels[0].beds).to.equal(4);
      expect(resort.hotels[0].points).to.equal(10);
      expect(() => resort.leave('aaa',2,5)).to.throw("There is no such hotel");
      expect(() => resort.leave('',2,5)).to.throw("Invalid input");
      expect(() => resort.leave('new',0,5)).to.throw("Invalid input");
   }) 
   it('Test leave hotel', function () {
      const resort = new SkiResort('Ski');        
      resort.build('new',4);
      resort.book('new',2);
      const result = resort.averageGrade();
      expect(result).to.equal('No votes yet');
      resort.leave('new',2,5);
      const result2 = resort.averageGrade();
      expect(result2).to.equal('Average grade: 5.00')
   }) 
});
