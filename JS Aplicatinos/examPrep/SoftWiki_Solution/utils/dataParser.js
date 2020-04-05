export default {
    getAll(data){
    return Object.keys(data).map(x=>{
        let curObj = data[x];
        curObj.id = x;
        return curObj;
        })
    },
    // getSingleArticle(data,art){
    //     return data.filter(x=>x.category == art);
    // }
    getSingleArticleSortByDes(data,art){
           return data.filter(x=>x.category == art)
           .sort((a,b)=>b.title.localeCompare(a.title));
        }
}