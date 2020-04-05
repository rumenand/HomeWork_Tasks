import extend from '../utils/context.js';
import models from '../models/index.js';
import parser from '../utils/dataParser.js';
import message from '../utils/notifications.js';

export default {
    get:{
        profile(context){  
            message.show('loadingNotification');
            models.treks.getAll().then((res)=>
                    {
                        context.treks = parser(res).filter(x=>x.organizer === localStorage.getItem('name'));
                        extend(context).then(function () { 
                            message.hide('loadingNotification'); 
                             this.partial('../views/user/profile.hbs');            
                        })
                    })          
           
        }
    }
}