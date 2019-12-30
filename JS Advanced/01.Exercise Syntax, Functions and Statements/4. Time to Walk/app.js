'use strict';
function solve(a, b, c) {
    var br = Math.floor((a * b) / 500);
    var time = (((a * b) / 1000) / c) * 3600 + br* 60;
    // Hours, minutes and seconds
    var hrs = Math.floor(time / 3600);
    var mins = Math.floor((time % 3600) / 60);
    var secs = Math.round(time % 60);

    var ret = "";
    ret += (hrs<10 ?"0":"") + hrs + ":" + (mins < 10 ? "0" : ""); 
    ret += "" + mins + ":" + (secs < 10 ? "0" : "");
    ret += "" + secs;
    console.log(ret);
}
solve(2564, 0.70, 5.5);
