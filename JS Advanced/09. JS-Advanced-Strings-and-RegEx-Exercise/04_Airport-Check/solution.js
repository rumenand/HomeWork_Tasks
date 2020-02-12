function solve() {
    const input = document.querySelector('#string').value;
    const result = document.querySelector('#result');

    const airPatrn = /\s[A-Z]{3}\/[A-Z]{3}\s/;
    const namePatrn = /\s([A-Za-z]+)(-[A-Za-z]+\.)?(-[A-Za-z]+)\s/;
    const ticketPatrn = /\s[A-Z]{1,3}\d{1,5}\s/;
    const companyPatrn = /-\s[A-Za-z]+\*[A-Za-z]+\s/;

    let inpRend = input.split(',');
    const pName = inpRend[0].match(namePatrn)[0]
                  .trim().replace(/-/g,' ');
    const flights = inpRend[0].match(airPatrn)[0]
                  .trim().split('/');
    const ticket = inpRend[0].match(ticketPatrn)[0]
                    .trim();
    const company = inpRend[0].match(companyPatrn)[0]
                    .replace(/-/g,' ')
                    .replace(/\*/g,' ')
                    .trim();    

    const printMapper = {
        name: () => `Mr/Ms, ${pName}, have a nice flight!`,
        flight: () => `Your flight number ${ticket} is from ${flights[0]} to ${flights[1]}.`,
        company: () => `Have a nice flight with ${company}.`,
        all: () => `Mr/Ms, ${pName}, your flight number ${ticket} is from ${flights[0]} to ${flights[1]}. Have a nice flight with ${company}.`
    }
    
    const resP = document.createElement('p');
    resP.textContent = printMapper[inpRend[1].trim()]();
    result.appendChild(resP);
}