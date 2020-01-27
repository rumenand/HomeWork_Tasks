function attachEventsListeners() {
    const fields =  [...document.querySelectorAll('input')]
    .filter(x=>x.type === 'text')
    .reduce((a,b) => {
        a.set(b.id, b);
        return a;
    },new Map());
    const funcMap = {
        daysBtn : () => Number(fields.get('days').value),
        hoursBtn: () => Number(fields.get('hours').value)/24,
        minutesBtn: () => Number(fields.get('minutes').value)/1440,
        secondsBtn: () => Number(fields.get('seconds').value)/86400
    }
    const btn = [...document.querySelectorAll('input')]
    .filter(x=>x.type === 'button')
    .map(x=>x.addEventListener('click',(e) => setFields(funcMap[e.target.id]())));

    function setFields(a){
        fields.get('days').value = a
        fields.get('hours').value = a*24;
        fields.get('minutes').value = a*24*60;
        fields.get('seconds').value = a*24*60*60;
    }
}