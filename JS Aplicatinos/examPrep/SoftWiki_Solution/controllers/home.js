import extend from '../utils/context.js';
import models from '../models/index.js';
import parser from '../utils/dataParser.js';

export default {
    get:{
        home(context)
        { 
            extend(context).then(function ()
            {
                if (context.loggedIn)
                {
                    models.articles.getAll().then((res)=>
                    {
                        let allArticles= parser.getAll(res);
                        context.jsArt = parser.getSingleArticleSortByDes(allArticles,'JavaScript');
                        context.csArt = parser.getSingleArticleSortByDes(allArticles,'C#');
                        context.jvArt = parser.getSingleArticleSortByDes(allArticles,'Java');
                        context.pyArt = parser.getSingleArticleSortByDes(allArticles,'Pyton');
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