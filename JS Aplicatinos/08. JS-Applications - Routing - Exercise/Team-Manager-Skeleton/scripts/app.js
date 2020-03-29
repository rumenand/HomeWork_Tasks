import {getUserData,fetchData,getCurUser,curUserTeam,getIndexOfTeam} from './helpers.js';
async function applyCommon(){
    this.partials = {
        header : await this.load('./templates/common/header.hbs'),
        footer : await this.load('./templates/common/footer.hbs')
        }
    this.username = getCurUser();
    this.loggedIn = !!sessionStorage.getItem('token');
    this.hasNoTeam = true;
}
async function homeViewHandler(){
        await applyCommon.call(this);
        this.partial('./templates/home/home.hbs');
}
async function aboutViewHandler(){
    await applyCommon.call(this);
    this.partial('./templates/about/about.hbs');
}
async function loginViewHandler(){
    await applyCommon.call(this);
    this.partials.loginForm = await this.load('./templates/login/loginForm.hbs');
    await this.partial('./templates/login/loginPage.hbs');
    const formCtn = document.querySelector('#login-form');
    formCtn.addEventListener('submit',(e)=>{
        e.preventDefault();
        const chUser = getUserData(formCtn,['username','password']);
        firebase.auth().signInWithEmailAndPassword(chUser.username, chUser.password)
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
    this.partials.registerForm = await this.load('./templates/register/registerForm.hbs');
    await this.partial('./templates/register/registerPage.hbs');
    const formCtn = document.querySelector('#register-form');
    formCtn.addEventListener('submit',(e)=>{
        e.preventDefault();
        const chUser = getUserData(formCtn,['username','password','repeatPassword']);
        if (chUser.password === chUser.repeatPassword){
            firebase.auth().createUserWithEmailAndPassword(chUser.username, chUser.password)
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
function fillTeams(){
    fetchData('teams',sessionStorage.getItem('token')
                ,{method:"GET"},[(data)=>{
                   let arr = Object.keys(data)
                    .map(x=>{
                        return {
                            '_id':x,
                            'name':data[x].name,
                            'comment':data[x].comment,
                            'members':data[x].members,
                            'author':data[x].author
                        }}); 
                        this.teams = arr;
                        this.hasNoTeam =(curUserTeam(arr) === '');                   
                        this.partial('./templates/catalog/teamCatalog.hbs');
                        sessionStorage.setItem('teams',JSON.stringify(arr));                        
                }]);
}
async function catalogViewHandler(){
    await applyCommon.call(this);
    this.partials.team = await this.load('./templates/catalog/team.hbs');
    await fillTeams.call(this);    
}
function logoutHandler(){
    sessionStorage.clear();
    firebase.auth().signOut().then(()=> {
        this.redirect('#/home');
      }).catch(function(error) {
        alert(error);
      });
}
async function createViewHandler(){
    await applyCommon.call(this);    
    this.partials.createForm = await this.load('./templates/create/createForm.hbs');
    await this.partial('./templates/create/createPage.hbs');
    const formCtn = document.querySelector('#create-form');
    formCtn.addEventListener('submit',(e)=>{
        e.preventDefault();
        const team = getUserData(formCtn,['name','comment']);
        team.author = getCurUser();
        team.members = getCurUser();
        fetchData('teams',sessionStorage.getItem('token'),{method: 'POST',
            body: JSON.stringify(team)});
        this.redirect('#/catalog');
    })
}
async function teamViewHandler(){
    await applyCommon.call(this);
    this.partials.teamMember = await this.load('./templates/catalog/teamMember.hbs');
    this.partials.teamControls = await this.load('./templates/catalog/teamControls.hbs');
    const teams = JSON.parse(sessionStorage.getItem('teams'));
    const curTeam = teams.filter(x=>x._id === this.params.id.slice(1))[0];
    this.teamId = curTeam._id;
    this.name = curTeam.name;
    this.comment = curTeam.comment;
    this.members = curTeam.members.split(', ').map(x=>{
        return {'username':x};
    });
    this.isAuthor = (curTeam.author === getCurUser());
    this.isOnTeam = curTeam.members.split(', ').includes(getCurUser());
    await this.partial('./templates/catalog/details.hbs');
}
function leaveHandler(){   
    const teams = JSON.parse(sessionStorage.getItem('teams'));
    const cTeamId = getIndexOfTeam(teams,this.params.id.slice(1));    
    if(confirm(`Do you want to leave team ${teams[cTeamId].name}`) === true){
        let membArr = teams[cTeamId].members.split(', ');       
        let found = membArr.indexOf(getCurUser());
        membArr.splice(found, 1).join(', ');
        teams[cTeamId].members = membArr.join(', ');
        fetchData(`teams/${teams[cTeamId]._id}`,sessionStorage.getItem('token'),
        {method: "PUT",body: JSON.stringify(teams[cTeamId])},
        [()=>{
            sessionStorage.setItem('teams',JSON.stringify(teams));
            this.redirect(`#/catalog/:${teams[cTeamId]._id}`);
        }]);
    }
    else this.redirect(`#/catalog/:${teams[cTeamId]._id}`);
}
function joinHandler(){
    const teams = JSON.parse(sessionStorage.getItem('teams'));
    const userTeam = curUserTeam(teams);
    if (userTeam ===''){
    const cTeamId = getIndexOfTeam(teams,this.params.id.slice(1));
        if(confirm(`Do you want to join team ${teams[cTeamId].name}`) === true){
            let membArr = teams[cTeamId].members.split(', ');       
            membArr.push(getCurUser());
            teams[cTeamId].members = membArr.join(', ');
            fetchData(`teams/${teams[cTeamId]._id}`,sessionStorage.getItem('token'),
            {method: "PUT",body: JSON.stringify(teams[cTeamId])},
            [()=>{
                sessionStorage.setItem('teams',JSON.stringify(teams));
                this.redirect(`#/catalog/:${teams[cTeamId]._id}`);
            }]);
        }
        else this.redirect(`#/catalog/:${teams[cTeamId]._id}`); 
    }
    else{
        alert(`You cannot join this team because you are a memder of team: ${userTeam}`);
        this.redirect(`#/catalog/:${this.params.id.slice(1)}`);
    }
}
async function editHandler(){
    await applyCommon.call(this);
    this.partials.editForm = await this.load('./templates/edit/editForm.hbs');
    await this.partial('./templates/edit/editPage.hbs'); 
    const formCtn = document.querySelector('#edit-form');
    formCtn.addEventListener('submit',(e)=>{
        e.preventDefault();
        const newTeam = getUserData(formCtn,['name','comment']);
        const teams = JSON.parse(sessionStorage.getItem('teams'));
        const cTeamId = getIndexOfTeam(teams,this.params.id.slice(1));
        if(confirm(`Do you want to edit team ${teams[cTeamId].name}`) === true){
            teams[cTeamId].name = newTeam.name;
            teams[cTeamId].comment = newTeam.comment;
            fetchData(`teams/${teams[cTeamId]._id}`,sessionStorage.getItem('token'),
            {method: "PUT",body: JSON.stringify(teams[cTeamId])},
            [()=>{
                sessionStorage.setItem('teams',JSON.stringify(teams));
                this.redirect(`#/catalog/:${teams[cTeamId]._id}`);
            }]);
        }
        else this.redirect(`#/catalog/:${teams[cTeamId]._id}`); 
    })
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