export function getUserData(form,data){
    return data.reduce((a,b) => {
         a[b] =form.elements[b].value;
         return a;
        },{})
}
export function fillForm(form,data,values){
    values.forEach(x=>{
        form.elements[x].value = data[x];
    })
}
export async function fetchData(url,token,headers){
    const u = getUrl(url,token);
    const res = await fetch(u,headers)
    .then((res) =>{ 
        if (res.ok !== true) throw new Error('Could not load database');
        return res.json();})
    .catch((e) => alert(e));
    return res;
}
export const getUrl = (x,token) => {
    let str = `https://routinghomework-5be97.firebaseio.com/${x}.json`;
    (token)?str+=`?auth=${token}`:'';
    return str;
}
export const getCurUser = ()=> sessionStorage.getItem('username');

export const clearForm = (formRef, formConfig) => {
    formConfig.map(key => {
        formRef.elements.namedItem(key).value = '';
    });
};
export function sendThreeSecNotifyMessage(mes){
    const ctn = document.getElementById('infoBox');
    ctn.textContent = mes;
    setTimeout(()=>{ ctn.textContent ="";}, 3000);
}

