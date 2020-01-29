function attachEventsListeners() {
    document.querySelector('#convert')
    .addEventListener('click',handler);
    const convMap = {
        km:	1000, 
        m: 1,
        cm: 0.01,
        mm: 0.001,
        mi: 1609.34,
        yrd: 0.9144,
        ft:	0.3048,
        in: 0.0254 
    }

    function handler(e){
        const inpUn = document.querySelector('#inputUnits').value;
        const outUn = document.querySelector('#outputUnits').value;
        const inpDist = document.querySelector('#inputDistance').value;
        const a = Number(inpDist)*convMap[inpUn]/convMap[outUn];
        document.querySelector('#outputDistance').value = a;

    }
}