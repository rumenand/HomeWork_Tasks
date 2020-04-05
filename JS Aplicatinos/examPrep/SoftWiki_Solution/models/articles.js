function fetchData(url,token,headers){
    const u = getUrl(url,token);
    return fetch(u,headers)
    .then((res) =>{ 
        if (res.ok !== true) throw new Error('Could not load database');
        return res.json();}) 
}
function getUrl (x,token) {
    let str = `https://routinghomework-5be97.firebaseio.com/${x}.json`;
    (token)?str+=`?auth=${token}`:'';
    return str;
}

export default {
    create(data){
        let article = {...data};
        article.creator = localStorage.getItem('name');
       return fetchData ('articles',localStorage.getItem('token'),{method: 'POST',
       body: JSON.stringify(article)});
    },
    getAll(){
        return fetchData ('articles',localStorage.getItem('token'),{method: 'GET'})
    },
    getById(id){
        return fetchData (`articles/${id}`,localStorage.getItem('token'),{method: 'GET'});
    },
    del(cId){
        return fetchData (`articles/${cId}`,localStorage.getItem('token'),{method: 'DELETE'});
    },
    update(data){
        const obj = {...data};
        const id = obj.id;
        delete obj.id;
        obj.creator = localStorage.getItem('name');
        return fetchData (`articles/${id}`,localStorage.getItem('token'),{method: 'PUT',
        body: JSON.stringify(obj)});
    }
}
