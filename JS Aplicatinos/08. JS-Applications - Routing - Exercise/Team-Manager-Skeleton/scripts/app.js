import{loginViewHandler,registerViewHandler,logoutHandler} from './auth.js';
import{homeViewHandler,aboutViewHandler,catalogViewHandler,teamViewHandler,
        createViewHandler,leaveHandler,joinHandler,editHandler}
        from './handlers.js';

var app = Sammy('#main', function() {
    // include a plugin
    this.use('Handlebars','hbs');  
    // define a 'route'
    this.get('#/', homeViewHandler);
    this.get('#/home',homeViewHandler);
    this.get('#/about',aboutViewHandler);
    this.get('#/login',loginViewHandler);
    this.get('#/register',registerViewHandler);
    this.get('#/catalog',catalogViewHandler);
    this.get('#/catalog/:id',teamViewHandler);
    this.get('#/create',createViewHandler);
    this.post('#/create',()=>false);
    this.post('#/register',() => false);
    this.post('#/login',() => false);
    this.post('#/edit/:',() => false);
    this.get('#/logout',logoutHandler);
    this.get('#/leave/:id',leaveHandler);    
    this.get('#/join/:id',joinHandler);    
    this.get('#/edit/:id',editHandler);    
  });
  
(()=> {
    app.run('#/');
})()