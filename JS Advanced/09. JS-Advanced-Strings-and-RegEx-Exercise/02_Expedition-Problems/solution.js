function solve() {
    const mArg = document.querySelector('#string').value;
    const text = document.querySelector('#text').value;
    const coordPattern  = /(east|north).*?(\d{2})[^,]*?,[^,]*?(\d{6})/gim;
    const messagePattern = `(?<=${mArg}).+(?=${mArg})`;
    const message = text.match(messagePattern);
    let coords = coordPattern.exec(text);
    let north ='',
        east = '';
    while(coords){        
        const coord = coords[2]+'.'+coords[3];
        (coords[1].toLowerCase() === 'north')
        ? north = coord
        : east = coord;
        coords = coordPattern.exec(text); 
    }
    const result = document.querySelector('#result');
    const msg = document.createElement('p');
    const eCoord = document.createElement('p');
    const nCoord = document.createElement('p');
    msg.textContent = 'Message: '+message;
    eCoord.textContent = east +' E';
    nCoord.textContent = north + ' N';
    result.appendChild(nCoord);
    result.appendChild(eCoord);
    result.appendChild(msg);
}