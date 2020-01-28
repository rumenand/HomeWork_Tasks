function encodeAndDecodeMessages() {    
    const txtBoxes = document.querySelectorAll('textarea');
    const mapper = {
        Encode: () => {
            const output = strShift(txtBoxes[0].value,1)
            txtBoxes[0].value = '';
            txtBoxes[1].value = output;
        },
        Decode: () => {
            const output = strShift(txtBoxes[1].value,-1)
            txtBoxes[1].value = output;
        }
    };
    [...document.querySelectorAll('button')]
    .map(x=>x.addEventListener('click',mapper[x.textContent.split(' ')[0]]));
    function strShift(a,b){
        return a.split('')
        .map(x=>x.charCodeAt(0)+b)
        .map(x=>String.fromCharCode(x))
        .join('');
    }
}