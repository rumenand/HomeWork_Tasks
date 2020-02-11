function solve() {
    const input = JSON.parse(document.querySelector('#array').value);
    const result = document.querySelector('#result');
    const regex = new RegExp(`(\\s|^)(${input[0]}\\s+)([A-Z!#$%]{8,})(\\.|,|\\s|$)`,'gi');
    for (let i=1;i<input.length;i++){
        let str = input[i];
        let match = regex.exec(str);
        while(match){
            let encMes = match[3];
            if(encMes.toUpperCase() === encMes){
                encMes = encMes.replace(/!/g,'1');
                encMes = encMes.replace(/%/g,'2');
                encMes = encMes.replace(/#/g,'3');
                encMes = encMes.replace(/\$/g,'4');
                allMes = match[1]+match[2]+ encMes.toLowerCase() + match[4];
                str = str.replace(match[0], allMes);
            }
            match = regex.exec(str);
        }
        let pEl = document.createElement('p');
        pEl.textContent = str;
        result.appendChild(pEl);
    }    
}
