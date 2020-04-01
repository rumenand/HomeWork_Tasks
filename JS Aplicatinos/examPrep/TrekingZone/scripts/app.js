import {getUserData,fetchData,getCurUser,clearForm,sendThreeSecNotifyMessage,fillForm} from './helpers.js';
async function applyCommon(){
    this.partials = {
        header : await this.load('./templates/common/header.hbs'),
        footer : await this.load('./templates/common/footer.hbs')
        }
    this.username = getCurUser();
    this.loggedIn = !!sessionStorage.getItem('token');
}
async function homeViewHandler(){
        await applyCommon.call(this);
        if (!!sessionStorage.getItem('token')){
            let treks = await fetchData('treks',sessionStorage.getItem('token')
            ,{method:"GET"}) || {};
            if (Object.keys(treks)[0] !== undefined) this.hasTreks = true;
            this.treks = Object.keys(treks).map(x=>{
                return {
                    'trekId':x,
                    'location':treks[x].location,
                    'imageURL':treks[x].imageURL,
                }
            });
        }
        this.partial('./templates/home/home.hbs');
}
async function loginViewHandler(){
    await applyCommon.call(this);
    await this.partial('./templates/login/loginPage.hbs');
    const formCtn = document.querySelector('form');
    formCtn.addEventListener('submit',(e)=>{
        e.preventDefault();
        const chUser = getUserData(formCtn,['inputEmail','inputPassword']);
        firebase.auth().signInWithEmailAndPassword(chUser.inputEmail, chUser.inputPassword)
        .then((res)=>{
            firebase.auth().currentUser.getIdToken().then(token=>{
                sessionStorage.setItem('token',token);
                sessionStorage.setItem('username',res.user.email);
                this.redirect('#/home');
            })
        })
        .catch((e) => alert(e));
    })
}
async function registerViewHandler(){
    await applyCommon.call(this);
    await this.partial('./templates/register/registerPage.hbs');
    const formCtn = document.querySelector('form');
    formCtn.addEventListener('submit',(e)=>{
        e.preventDefault();
        const chUser = getUserData(formCtn,['inputEmail','inputPassword','inputRePassword']);
        if (chUser.inputPassword === chUser.inputRePassword){
            firebase.auth().createUserWithEmailAndPassword(chUser.inputEmail, chUser.inputPassword)
            .then((user)=>{
                firebase.auth().currentUser.getIdToken().then(token=>{
                    sessionStorage.setItem('token',token);
                    sessionStorage.setItem('username',user.user.email);
                    this.redirect('#/home');
                })
            })
            .catch((e) => alert(e.message));
        }
        else alert('Passwordn did not match!');
    })
}

function logoutHandler(){
    sessionStorage.clear();
    firebase.auth().signOut().then(()=> {
        sendThreeSecNotifyMessage('Logout successful!')
        this.redirect('#/');
      }).catch(function(error) {
        alert(error);
      });
}
async function createViewHandler(){
    await applyCommon.call(this);    
    await this.partial('./templates/create/createPage.hbs');
    const formCtn = document.querySelector('form');
    formCtn.addEventListener('submit',(e)=>{
        e.preventDefault();
        const newTrek = getUserData(formCtn,['location','dateTime','description','imageURL']);
        newTrek.author = getCurUser();
        newTrek.likes = 0;
        let res = fetchData('treks',sessionStorage.getItem('token'),
        {method:'POST',body: JSON.stringify(newTrek)});
        if (res !== null) {
            clearForm(formCtn,['location','dateTime','description','imageURL']);
            sendThreeSecNotifyMessage('Trek Created Succesfully!');
        }
        
    })
}
async function editHandler(){
    const trekId = this.params.id.slice(1);
    await applyCommon.call(this);    
    await this.partial('./templates/edit/editPage.hbs');
    const formCtn = document.querySelector('form');
    const formFields = ['location','dateTime','description','imageURL'];
    let edTrek = await fetchData(`treks/${trekId}`
    ,sessionStorage.getItem('token'),{method:"GET"});
    fillForm(formCtn,edTrek,formFields);
    formCtn.addEventListener('submit',(e)=>{
        e.preventDefault();
        const newTrek = getUserData(formCtn,formFields);
        newTrek.likes = edTrek.likes;
        newTrek.author = edTrek.author;
        let res = fetchData(`treks/${trekId}`,sessionStorage.getItem('token'),
        {method: 'PUT',body: JSON.stringify(newTrek)});
        if (res !== null) {
            sendThreeSecNotifyMessage('Trek Udated Succesfully!');
            this.redirect('#/');
        }
        
    })
}
async function trekViewHandler(){
    const trekId = this.params.id.slice(1);
    await applyCommon.call(this);
    let trek = await fetchData(`treks/${trekId}`
    ,sessionStorage.getItem('token')
            ,{method:"GET"}) || {};
    this.id = trekId;
    this.location = trek.location;
    this.imageURL = trek.imageURL;
    this.description = trek.description;
    this.author = trek.author;
    this.dateTime = trek.dateTime;
    this.likes = trek.likes;
    if (trek.author === getCurUser()) this.isAuthor = true;
    this.partial('./templates/catalog/details.hbs');

}
async function likeHandler(){
    const trekId = this.params.id.slice(1);
    let trek = await fetchData(`treks/${trekId}`
    ,sessionStorage.getItem('token'),{method:"GET"});
    trek.likes++;
    let res = await fetchData(`treks/${trekId}`,sessionStorage.getItem('token')
            ,{method:"PUT",body: JSON.stringify(trek)});
    if (res!==null) sendThreeSecNotifyMessage('Successfully liked!');
    this.redirect(`#/details/:${trekId}`);
}

async function deleteHandler(){
    const trekId = this.params.id.slice(1);
    if (confirm(`Are you sure that you want to delete current trek?`)){
        let res = await fetchData(`treks/${trekId}`,sessionStorage.getItem('token')
            ,{method:"DELETE"});
    sendThreeSecNotifyMessage('Treck successfully deleted!');
    this.redirect(`#/`);
    }
    this.redirect(`#/catalog/:${trekId}`);
}
async function userViewHandler(){
    await applyCommon.call(this);
    this.partial('./templates/users/user.hbs');
}

var app = Sammy('#main', function() {
    // include a plugin
    this.use('Handlebars','hbs');  
    // define a 'route'
    this.get('#/', homeViewHandler);
    this.get('#/home',homeViewHandler);
    this.get('#/index.html',homeViewHandler);
    this.get('#/login',loginViewHandler);
    this.get('#/user',userViewHandler);
    this.post('#/login',() => false);
    this.get('#/register',registerViewHandler);
    this.post('#/register',() => false);
    this.get('#/logout',logoutHandler);
    this.get('#/create',createViewHandler);
    this.post('#/create',()=>false);
    this.get('#/details/:id',trekViewHandler);
    this.get('#/like/:id',likeHandler);
    this.get('#/edit/:id',editHandler);
    this.get('#/delete/:id',deleteHandler);
    this.post('#/edit',() => false);
   // this.get('#/about',aboutViewHandler);
    
   // 
   // this.get('#/catalog',catalogViewHandler);
   // 

   // 
   
   // this.post('#/edit/:',() => false);
   // this.get('#/logout',logoutHandler);
   // this.get('#/leave/:id',leaveHandler);    
   // this.get('#/join/:id',joinHandler);    
   // this.get('#/edit/:id',editHandler);    
  });
  
(()=> {
    app.run('#/');
})()