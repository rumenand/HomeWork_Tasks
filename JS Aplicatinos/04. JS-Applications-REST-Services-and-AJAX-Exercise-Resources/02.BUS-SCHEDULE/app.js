function solve() {
    let cStop = '';
    let nStop = '';
    const txtCtn = document.querySelector('.info');
    const depBtn = document.querySelector('#depart');
    const arvBtn = document.querySelector('#arrive');
    function depart() {
        if (cStop === '') cStop = 'depot';
        fetch(`https://judgetests.firebaseio.com/schedule/${cStop}.json `)
        .then(res => res.json())
        .then(handler)
    //.catch(errHandler);
        
       
    }
    function handler(data){
        cStop = data.name;
        nStop = data.next;
        txtCtn.textContent = `Next stop ${cStop}`;
        depBtn.disabled = true;
        arvBtn.disabled = false;
    }

    function arrive() {
        txtCtn.textContent = `Arriving at ${cStop}`;
        depBtn.disabled = false;
        arvBtn.disabled = true;
        cStop = nStop;
    }

    return {
        depart,
        arrive
    };
}

let result = new solve();