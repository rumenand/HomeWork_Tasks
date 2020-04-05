import extend from '../utils/context.js';
import models from '../models/index.js';
import message from '../utils/notifications.js';

export default{
    get:{
        create(context){
            extend(context).then(function (){
                this.partial('../views/treks/create.hbs');
            })
        },
        details(context){
            message.show('loadingNotification');
            const trekId = context.params.id;
            models.treks.getById(trekId).then((res)=>{
            Object.keys(res).forEach(x=>context[x]=res[x]);
            context.id = trekId;            
            context.isAuthor = (res.organizer===localStorage.getItem('name'));
            extend(context).then(function (){
                message.hide('loadingNotification');
                this.partial('../views/treks/details.hbs');
            })
            })
        },
        like(context){
            message.show('loadingNotification');
            const trekId = context.params.id;
            models.treks.like(trekId).then((res)=>{
                message.hide('loadingNotification');
                message.threeSec('successNotification');
                context.redirect(`#/treks/details/${trekId}`);
            })
        },
        edit(context){
            message.show('loadingNotification');
            const trekId = context.params.id;
            models.treks.getById(trekId).then((res)=>{
            Object.keys(res).forEach(x=>context[x]=res[x]);
            context.id = trekId;
            extend(context).then(function (){
                message.hide('loadingNotification');
                this.partial('../views/treks/edit.hbs');
            })
            })   
        }
    },
    post:{
        create(context){
            message.show('loadingNotification');
            models.treks.create(context.params)
            .then((res) => {
                message.hide('loadingNotification');
                message.threeSec('successNotification');
                context.redirect('#/home');
            });
        },
        edit(context){
            message.show('loadingNotification');
            models.treks.update(context.params)
            .then((res) => {
                message.hide('loadingNotification');
                message.threeSec('successNotification');
                context.redirect(`#/treks/details/${context.params.id}`);
            });
        }
    },   
    del:{
        delById(context){
            message.show('loadingNotification');
            const trekId = context.params.id;
            if (confirm('Are you sure that you want to delete this trek?')){
                models.treks.del(trekId).then((res)=>{
                    message.hide('loadingNotification');
                    message.threeSec('successNotification');
                    context.redirect('#/home');
                })   
            }
            else{
                message.hide('loadingNotification');
                context.redirect(`#/treks/details/${trekId}`);
            }
        }
    }
}