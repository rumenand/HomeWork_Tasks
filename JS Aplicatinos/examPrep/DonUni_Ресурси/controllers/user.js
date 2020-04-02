import models from '../models/index.js';
import extend from '../utils/context.js';
import message from '../utils/notifications.js';

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
            message.show('loadingNotification');
            models.user.logout().then((res) => {
                message.hide('loadingNotification');
                message.threeSec('successNotification');
                context.redirect('#/home');
            });      
        }
    },
    post:{
        login(context){
            message.show('loadingNotification');
            const {username,password} = context.params;
            models.user.login(username,password)
                .then((res)=>{
                    message.hide('loadingNotification');
                    message.threeSec('successNotification');
                    context.redirect('#/home');
                })
                .catch((e)=>console.error(e));
            }
        ,
        register(context){
            const {username,password,rePassword} = context.params;
            if(password === rePassword){
            message.show('loadingNotification');
            models.user.register(username,password)
                .then((res)=>{
                    message.hide('loadingNotification');  
                    message.threeSec('successNotification');
                    context.redirect('#/login');               
                })
                .catch((e)=>console.error(e));
            }
            else alert("Password didn't match");
            }
        }
    }
