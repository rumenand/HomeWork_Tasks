'use strict';
function solve(json) {
    let arr = JSON.parse(json);
    let outputArr = ["<table>"];
    outputArr.push(makeKeyRow(arr));
    arr.forEach((obj) => outputArr.push(makeValueRow(obj)));
    outputArr.push("</table>");
    function makeKeyRow(arr) {
        let result = '<tr>';
        for (const key in arr[0]) {
            result += '<th>'+key +'</th>';
        }
        result += '</tr>';
        return result;
    }
    function makeValueRow(obj) {
        let result = '<tr>';
        for (const val of Object.values(obj)) {
            result += '<td>' + val + '</td>';
        }
        result += '</tr>';
        return result;
    };
    console.log(outputArr.join('\n'));
    }

solve(['[{ "name": "Pencho Penchev", "score": 0 }, { "name": "<script>alert(\"Wrong!\")</script>", "score": 1 }]']);