function solve() {
    let select = document.getElementById('selectMenuTo');
    select.appendChild(createOpt('binary'));
    select.appendChild(createOpt('hexadecimal'));

    const convertBtn = document.getElementById('container').querySelector('button');
    convertBtn.addEventListener('click', convert);

    let convertMapper = {
        binary : (x) => (x >>> 0).toString(2),
        hexadecimal: (x) => x.toString(16).toUpperCase()
    };   
    const getNumber = () => Number(document.getElementById('input').value);
    function createOpt(x){
    let opt = document.createElement('option');
    opt.value = x;
    opt.innerHTML = x;
    return opt;
    }
    function convert(){
        num = getNumber();
        if (isNaN(num) || num === undefined) throw new console.error("No numner");
        const oper = select.options[select.selectedIndex].value;
        const output = document.getElementById('result');
        if (convertMapper[oper]){            
            output.value = convertMapper[oper](num);
        }       
    }
}