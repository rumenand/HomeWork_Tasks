function solve() {
    const html = {
        txtField : () => document.querySelector('.info'),
        depBtn : ()=> document.getElementById('depart'),
        arvBtn : ()=> document.getElementById('arrive')
    }
    let cStop;
    let nStop;
    function depart() {
        fetch(getUrl(cStop))
        .then(res => res.json())
        .then(handler)
        .catch((err) => {html.txtField().textContent = err}); 
       
    }
    function getUrl(x='depot'){
        return `https://judgetests.firebaseio.com/schedule/${x}.json`;
    }
    function handler(data){
        cStop = data.name;
        nStop = data.next;
        html.txtField().textContent = `Next stop ${cStop}`;
        html.depBtn().disabled = true;
        html.arvBtn().disabled = false;
    }

    function arrive() {
        html.txtField().textContent = `Arriving at ${cStop}`;
        html.depBtn().disabled = false;
        html.arvBtn().disabled = true;
        cStop = nStop;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();