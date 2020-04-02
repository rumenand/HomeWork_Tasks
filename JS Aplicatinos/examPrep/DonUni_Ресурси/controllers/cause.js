import extend from '../utils/context.js';
import models from '../models/index.js';
import parser from '../utils/dataParser.js';
import message from '../utils/notifications.js';

export default{
    get:{
        dashboard(context){
            message.show('loadingNotification');
            models.cause.getAll().then((res)=>{
            context.cause = parser(res);
            extend(context).then(function (){
                message.hide('loadingNotification');
                this.partial('../views/causes/dashBoard.hbs');
            })
          })
        },
        create(context){
            extend(context).then(function (){
                this.partial('../views/causes/create.hbs');
            })
        },
        details(context){
            message.show('loadingNotification');
            const causeId = context.params.id;
            models.cause.getById(causeId).then((res)=>{
            Object.keys(res).forEach(x=>context[x]=res[x]);
            context.id = causeId;            
            context.donor = context.donors.split(', ');
            context.isAuthor = (res.name===localStorage.getItem('name'));
            extend(context).then(function (){
                message.hide('loadingNotification');
                this.partial('../views/causes/details.hbs');
            })
        })
        }        
    },
    post:{
        create(context){
            message.show('loadingNotification');
            models.cause.create(context.params)
            .then((res) => {
                message.hide('loadingNotification');
                message.threeSec('successNotification');
                context.redirect('#/cause/dashboard')
            });
        }
    },
    put:{
        donate(context){
            message.show('loadingNotification');
            const obj = {...context.params};
            models.cause.donate(obj).then((res)=>{
                message.hide('loadingNotification');
                message.threeSec('successNotification');
                context.redirect(`#/cause/details/${obj.id}`);
            })        
        }
    },
    del:{
        delById(context){
            message.show('loadingNotification');
            const causeId = context.params.id;
            if (confirm('Are you sure that you want to delete this cause?')){
                models.cause.del(causeId).then((res)=>{
                    message.hide('loadingNotification');
                    message.threeSec('successNotification');
                    context.redirect(`#/cause/dashboard`);
                })   
            }
        }
    }
}