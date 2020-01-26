function notify(message) {
    const n = document.getElementById('notification');
    n.innerHTML = message;
    n.style.display = 'block';

setTimeout(function(){
    n.innerHTML = '';
    n.style.display = 'none';
}, 2000);
}