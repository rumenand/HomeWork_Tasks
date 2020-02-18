const PizzUni = require('./02. PizzUni_Ресурси.js')
const expect = require("chai").expect;

describe('PizzUni test', function() {           
    it('Test constructor', function () {
        const pizza = new PizzUni();
        expect(pizza.registeredUsers.length).to.equal(0);

        expect(pizza.availableProducts.pizzas.length).to.equal(3);
        expect(pizza.availableProducts.pizzas[0]).to.equal('Italian Style');
        expect(pizza.availableProducts.pizzas[1]).to.equal('Barbeque Classic');
        expect(pizza.availableProducts.pizzas[2]).to.equal('Classic Margherita');

        expect(pizza.availableProducts.drinks.length).to.equal(3);
        expect(pizza.availableProducts.drinks[0]).to.equal('Coca-Cola');
        expect(pizza.availableProducts.drinks[1]).to.equal('Fanta');
        expect(pizza.availableProducts.drinks[2]).to.equal('Water');
        
        expect(pizza.orders.length).to.equal(0);
    })  
    it('Test registerUser', function () {
        const pizza = new PizzUni();
        const user = pizza.registerUser('coke');
        expect(pizza.registeredUsers[0]).to.equal(user);
        expect(pizza.registeredUsers[0].email).to.equal('coke');
        expect(pizza.registeredUsers[0].orderHistory.length).to.equal(0);
        expect(() => pizza.registerUser('coke')).to.throw('This email address (coke) is already being used!');
    })  
    it('Test makeAnOrder', function () {
        const pizza = new PizzUni();

        expect(() => pizza.makeAnOrder('coke','Italian Style','Fanta'))
        .to.throw('You must be registered to make orders!');

        const user = pizza.registerUser('user@abv.bg');

        expect(() => pizza.makeAnOrder('user@abv.bg','Italia','Fanta'))
        .to.throw('You must order at least 1 Pizza to finish the order.');

        const order = pizza.makeAnOrder('user@abv.bg','Italian Style');
        
        expect(pizza.orders.length).to.equal(1);
        expect(pizza.orders[order].email).to.equal('user@abv.bg');
        expect(pizza.orders[order].status).to.equal('pending');
        expect(pizza.orders[order].orderedPizza).to.equal('Italian Style');
        expect(pizza.orders[order].orderedDrink).to.equal(undefined);
        expect(pizza.registeredUsers[0].orderHistory.length).to.equal(1);
        expect(pizza.registeredUsers[0].orderHistory[0].orderedPizza).to.equal('Italian Style');

        const order2 = pizza.makeAnOrder('user@abv.bg','Italian Style','Fanta');
        expect(pizza.orders[order2].orderedDrink).to.equal('Fanta');

        const order3 = pizza.makeAnOrder('user@abv.bg','Italian Style','7up');
        expect(pizza.orders[order3].orderedDrink).to.equal(undefined);
    })  
    it('Test completeOrder', function () {
        const pizza = new PizzUni();
        const emptyRes = pizza.completeOrder();
        expect(emptyRes).to.equal(undefined);
        pizza.registerUser('user@abv.bg');
        pizza.makeAnOrder('user@abv.bg','Italian Style');
        const res = pizza.completeOrder();
        expect(res.status).to.equal('completed');
    })  
    it('Test detailsAboutMyOrder', function () {
        const pizza = new PizzUni();        
        pizza.registerUser('user@abv.bg');
        pizza.makeAnOrder('user@abv.bg','Italian Style');
        const res = pizza.detailsAboutMyOrder(2);
        expect(res).to.equal(undefined);
        const res2 = pizza.detailsAboutMyOrder(0);        
        expect(res2).to.equal('Status of your order: pending');
        pizza.completeOrder();
        const res3 = pizza.detailsAboutMyOrder(0);
        expect(res3).to.equal('Status of your order: completed')
    }) 
    it('Test doesTheUserExist', function () {
        const pizza = new PizzUni();
        expect(pizza.doesTheUserExist('vvv')).to.equal(undefined);
        pizza.registerUser('aaa');
        const res = pizza.doesTheUserExist('aaa');
        expect(res.email).to.equal('aaa');
    }) 
});