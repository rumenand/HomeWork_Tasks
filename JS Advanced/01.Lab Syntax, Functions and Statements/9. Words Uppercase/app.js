
function solve(a) {
    if (typeof (a) === 'string') {
        let myRe = new RegExp('\\w+', 'g');
        const matches = a.matchAll(myRe);
        let result = "";
        for (const match of matches) {
            result += match[0].toUpperCase() + ", ";
        }
        result = result.substring(0, result.length - 2);
        console.log(result);
    }
}
solve('Hi, how are you?');
