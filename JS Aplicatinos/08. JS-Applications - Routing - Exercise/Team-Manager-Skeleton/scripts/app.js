async function homeViewHandler(){
    this.partials = {
        header : await this.load('./templates/common/header.hbs'),
        footer : await this.load('./templates/common/footer.hbs')
        }
        this.partial('./templates/home/home.hbs');
}
async function aboutViewHandler(){
    this.partials = {
    header : await this.load('./templates/common/header.hbs'),
    footer : await this.load('./templates/common/footer.hbs')
    }
    this.partial('./templates/about/about.hbs');
}
async function loginViewHandler(){
    this.partials = {
        header : await this.load('./templates/common/header.hbs'),
        footer : await this.load('./templates/common/footer.hbs'),
        loginForm: await this.load('./templates/login/loginForm.hbs')
        }
        this.partial('./templates/login/loginPage.hbs');
}
async function registerViewHandler(){
    this.partials = {
        header : await this.load('./templates/common/header.hbs'),
        footer : await this.load('./templates/common/footer.hbs'),
        registerForm: await this.load('./templates/register/registerForm.hbs')
        }
        this.partial('./templates/register/registerPage.hbs');
}

var app = Sammy('#main', function() {
    // include a plugin
    this.use('Handlebars','hbs');  
    // define a 'route'
    this.get('#/', homeViewHandler);
    this.get('#/home',homeViewHandler);
    this.get('#/about',aboutViewHandler);
    this.get('#/login',loginViewHandler);
    this.get('#/register',registerViewHandler);
  });
  
(()=> {
    app.run('#/');
})()