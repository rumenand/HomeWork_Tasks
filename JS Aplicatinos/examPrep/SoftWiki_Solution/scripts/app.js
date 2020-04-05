import controllers from '../controllers/index.js';
const app = Sammy('#root',function(){
    this.use('Handlebars','hbs');
    //Home
    this.get('#/home',controllers.home.get.home);
    //User
    this.get('#/login',controllers.user.get.login);
    this.get('#/logout',controllers.user.get.logout);
    this.get('#/register',controllers.user.get.register);
    this.post('#/register',controllers.user.post.register);
    this.post('#/login',controllers.user.post.login);

    //Articles
        //Create
    this.get('#/articles/create',controllers.articles.get.create);
    this.post('#/articles/create',controllers.articles.post.create);
        //Details
    this.get('#/articles/details/:id',controllers.articles.get.details); 
        //Delete
    this.get('#/articles/close/:id',controllers.articles.del.delById);
        //Edit
    this.get('#/articles/edit/:id',controllers.articles.get.edit);
    this.post('#/articles/edit/:id',controllers.articles.post.edit);

});

(() => {
    app.run('#/home')
})();
