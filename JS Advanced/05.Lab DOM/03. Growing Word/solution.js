function growingWord() {
    const word = document.querySelector("#exercise > p");
    if (word === null) {
        throw new Error("No such word");
    }
    let fontSize = window
        .getComputedStyle(word)
        .fontSize
        .replace("px", "");
    if (fontSize === '0'){
        document.count = state();
    }
    const colorMap = ["blue", "green", "red"];   
    function state() {
        let e = 0;
        return function (command) {
            if (command === 'incr') e++;
            if (command === 'zero') e=0;
            return e;
        }
    }
    if (document.count() >= colorMap.length) {
        document.count('zero');
    } 
    word.style.color = colorMap[document.count()];
    document.count('incr'); 
    word.style.fontSize = (fontSize === "0" ? "4" : Number(fontSize) * 2) + "px";
}