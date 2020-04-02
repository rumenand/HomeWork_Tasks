import controllers from '../controllers/index.js';
const app = Sammy('#main',function(){
    this.use('Handlebars','hbs');
    //Home
    this.get('#/home',controllers.home.get.home);
    //User
    this.get('#/login',controllers.user.get.login);
    this.get('#/logout',controllers.user.get.logout);
    this.get('#/register',controllers.user.get.register);
    this.post('#/register',controllers.user.post.register);
    this.post('#/login',controllers.user.post.login);

    //Cause
    this.get('#/cause/dashboard',controllers.cause.get.dashboard);
    this.post('#/cause/dashboard',controllers.cause.get.dashboard);

    this.get('#/cause/create',controllers.cause.get.create);
    this.post('#/cause/create',controllers.cause.post.create);

    this.get('#/cause/details/:id',controllers.cause.get.details); 

    this.post('#/cause/donate/:id',controllers.cause.put.donate);

    this.get('#/cause/close/:id',controllers.cause.del.delById)
});

(() => {
    app.run('#/home')
})();
