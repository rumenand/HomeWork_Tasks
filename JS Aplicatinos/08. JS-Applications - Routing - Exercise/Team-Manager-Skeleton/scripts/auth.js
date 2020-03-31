import {getUserData,applyCommon} from './helpers.js';

export async function loginViewHandler(){
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
export function logoutHandler(){
    sessionStorage.clear();
    firebase.auth().signOut().then(()=> {
        this.redirect('#/home');
      }).catch((e) => alert(e));
}
export async function registerViewHandler(){
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