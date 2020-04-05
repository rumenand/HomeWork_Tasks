import extend from '../utils/context.js';
import models from '../models/index.js';
import parser from '../utils/dataParser.js';
import message from '../utils/notifications.js';

export default {
    get:{
        home(context)
        {            
            extend(context).then(function ()
            {
                if (context.loggedIn)
                {
                    message.show('loadingNotification');
                    models.treks.getAll().then((res)=>
                    {
                        context.trek = parser(res);
                        if (context.trek[0].id !== undefined) context.hasTreks=true;
                        message.hide('loadingNotification');
                        this.partial('../views/home/home.hbs');
                    })
                }
                else
                {
                    this.partial('../views/home/home.hbs');
                }
            })
        }
    }
}