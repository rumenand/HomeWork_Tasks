import models from '../models/index.js';
import extend from '../utils/context.js';

export default{
    get:{
        login(context){
            extend(context).then(function (){
                this.partial('../views/auth/login.hbs');
            })
        },
        register(context){
            extend(context).then(function (){
                this.partial('../views/auth/register.hbs');
            })
        },
        logout(context){
            models.user.logout().then((res) => {
                context.redirect('#/login');
            });      
        }
    },
    post:{
        login(context){
            const {email,password} = context.params;
            models.user.login(email,password)
                .then((res)=>{
                    context.redirect('#/home');
                })
                .catch((e)=>{
                    alert(e);                    
                })
            }
        ,
        register(context){
            const {email,password} = context.params;
            const rePassword = context.params['rep-pass'];
            if(password === rePassword){
            models.user.register(email,password)
                .then(()=>{
                    context.redirect('#/home');        
                })
                .catch((e)=>{
                    alert(e);                    
                })
            }
            else {
                alert("Password didn't match");
                }
            }
        }
    }
