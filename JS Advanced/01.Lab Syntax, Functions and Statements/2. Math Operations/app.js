'use strict';
function solve(a, b, c) {
    let result;
    switch (c) {
        case '+': result = a + b; break;
        case '-': result = a - b; break;
        case '/': result = a / b; break;
        case '*': result = a * b; break;
        case '%': result = a % b; break;
        case '**': result = a ** b; break;           
    }
    console.log(result);
}
solve(5, 6, '-');
