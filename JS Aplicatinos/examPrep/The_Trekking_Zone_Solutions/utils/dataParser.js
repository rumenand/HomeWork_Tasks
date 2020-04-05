export default function(data){
    return Object.keys(data).map(x=>{
        let curObj = data[x];
        curObj.id = x;
        return curObj;
        // return {
        //     'id':x,
        //     'cause':data[x].cause,
        //     'neededFunds': data[x].neededFunds,
        //     'description': data[x].description,
        //     'pictureUrl': data[x].pictureUrl,
        //     'funds':data[x].funds,
        //     'name':data[x].name,
        //     'donors':''
        // }

    })
}