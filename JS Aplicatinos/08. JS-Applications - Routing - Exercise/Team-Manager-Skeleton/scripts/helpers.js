export function getUserData(form,data){
    return data.reduce((a,b) => {
        const el = form.querySelector(`#${b}`)
        if ( el !== undefined) {
            a[b] =el.value
        }
        return a;
    },{})
}
export function fetchData(url,token,headers,callbacks){
    const u = getUrl(url,token);
    fetch(u,headers)
    .then((res) =>{ 
        if (res.ok !== true) throw new Error('Could not load database');
        return res.json();})
    .then((data) => {
        if (data === null) throw new Error('Database is empty');
        if (callbacks) callbacks.forEach(x => x(data))
    })
    .catch((e) => alert(e));
}
export const getUrl = (x,token) => {
    let str = `https://routinghomework-5be97.firebaseio.com/${x}.json`;
    (token)?str+=`?auth=${token}`:'';
    return str;
}
export const getCurUser = ()=> sessionStorage.getItem('username');
export function curUserTeam(data){
    const tgUser = getCurUser();
    let userTeam = '';
    data.forEach(x=>{
        const res = x.members.split(', ').filter(y=>y===tgUser)[0];
        if (res !== undefined) userTeam = x;
    })
    return userTeam;
}
export function getIndexOfTeam(data,searchId){
    for (const i in data){
        if (data[i]._id === searchId) return i;
    }
    return -1;
}

export async function applyCommon(){
    this.partials = {
        header : await this.load('./templates/common/header.hbs'),
        footer : await this.load('./templates/common/footer.hbs')
        }
    this.username = getCurUser();
    this.loggedIn = !!sessionStorage.getItem('token');
}
