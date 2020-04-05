import extend from '../utils/context.js';
import models from '../models/index.js';

export default{
    get:{
        create(context){
            extend(context).then(function (){
                this.partial('../views/articles/create.hbs');
            })
        },
        details(context){
            const artId = context.params.id;
            models.articles.getById(artId).then((res)=>{
            Object.keys(res).forEach(x=>context[x]=res[x]);
            context.id = artId;            
            context.isAuthor = (res.creator===localStorage.getItem('name'));
            extend(context).then(function (){
                this.partial('../views/articles/details.hbs');
            })
            })
        },
        edit(context){
            const artId = context.params.id;
            models.articles.getById(artId).then((res)=>{
            Object.keys(res).forEach(x=>context[x]=res[x]);
            context.id = artId;
            extend(context).then(function (){
                this.partial('../views/articles/edit.hbs');
            })
            })   
        }
    },
    post:{
        create(context){
            models.articles.create(context.params)
            .then((res) => {
                context.redirect('#/home');
            });
        },
        edit(context){
            models.articles.update(context.params)
            .then((res) => {
                context.redirect('#/home');
            });
        }
    },   
    del:{
        delById(context){
            const trekId = context.params.id;
            if (confirm('Are you sure that you want to delete this article?')){
                models.articles.del(trekId).then((res)=>{
                    context.redirect('#/home');
                })   
            }
            else{
                context.redirect(`#/articles/details/${trekId}`);
            }
        }
    }
}