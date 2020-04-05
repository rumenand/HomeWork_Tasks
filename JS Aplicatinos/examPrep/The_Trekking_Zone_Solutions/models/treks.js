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
        let trek = {...data};
        trek.organizer = localStorage.getItem('name');
        trek.likes =0
       return fetchData ('treks',localStorage.getItem('token'),{method: 'POST',
       body: JSON.stringify(trek)});
    },
    getAll(){
        return fetchData ('treks',localStorage.getItem('token'),{method: 'GET'})
    },
    getById(id){
        return fetchData (`treks/${id}`,localStorage.getItem('token'),{method: 'GET'});
    },
    like(id){
        return this.getById(id).then((res)=>{
            res.likes =Number(res.likes)+1;
            return fetchData (`treks/${id}`,localStorage.getItem('token'),{method: 'PUT',
            body: JSON.stringify(res)});
        })
    },
    del(cId){
        return fetchData (`treks/${cId}`,localStorage.getItem('token'),{method: 'DELETE'});
    },
    update(data){
        const obj = {...data};
        const id = obj.id;
        delete obj.id;
        return fetchData (`treks/${id}`,localStorage.getItem('token'),{method: 'PUT',
        body: JSON.stringify(obj)});
    }
}
