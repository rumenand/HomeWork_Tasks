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

    //Trek
    this.get('#/treks/all',controllers.treks.get.allTreks);
    // this.post('#/cause/dashboard',controllers.cause.get.dashboard);

    this.get('#/treks/create',controllers.treks.get.create);
    this.post('#/treks/create',controllers.treks.post.create);

    this.get('#/treks/details/:id',controllers.treks.get.details); 

    this.get('#/treks/close/:id',controllers.treks.del.delById);
    this.get('#/treks/like/:id',controllers.treks.get.like);

    this.get('#/treks/edit/:id',controllers.treks.get.edit);
    this.post('#/treks/edit',controllers.treks.post.edit);

    this.get('#/profile',controllers.profile.get.profile);
});

(() => {
    app.run('#/home')
})();
