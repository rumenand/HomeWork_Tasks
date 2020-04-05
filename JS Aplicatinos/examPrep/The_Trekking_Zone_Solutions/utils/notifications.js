export default {
    show(x) {getEl(x).style.display = 'block'},
    hide(x) {getEl(x).style.display = 'none'},
    threeSec(x){
            getEl(x).style.display = 'block';
            setTimeout(() => {
            getEl(x).style.display = 'none';
            }, 3000);
        } 
    }
function getEl(x){
    return document.getElementById(x);
}    
