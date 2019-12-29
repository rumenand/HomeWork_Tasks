'use strict';

function solve(a) {
    let days = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'];
    let index = days.findIndex(x => x == a);
    if (index > -1) console.log(index+1);
    else console.log("error");
}
solve('Frida');
