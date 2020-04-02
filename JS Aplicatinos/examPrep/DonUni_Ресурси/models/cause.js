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
        let cause = {...data};
        cause.name = localStorage.getItem('name');
        cause.funds =0
        cause.donors = '';
       return fetchData ('causes',localStorage.getItem('token'),{method: 'POST',
       body: JSON.stringify(cause)});
    },
    getAll(){
        return fetchData ('causes',localStorage.getItem('token'),{method: 'GET'})
    },
    getById(cId){
        return fetchData (`causes/${cId}`,localStorage.getItem('token'),{method: 'GET'});
    },
    donate(data){
        return this.getById(data.id).then((res)=>{
            res.funds =Number(res.funds) + Number(data.currentDonation);
            res.donors += `, ${localStorage.getItem('name')}`; 
            return fetchData (`causes/${data.id}`,localStorage.getItem('token'),{method: 'PUT',
            body: JSON.stringify(res)});
        })
    },
    del(cId){
        return fetchData (`causes/${cId}`,localStorage.getItem('token'),{method: 'DELETE'});
    }
}
