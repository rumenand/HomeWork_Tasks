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
            result += '<th>' + escapeHtml(key) + '</th>';
        }
        result += '</tr>';
        return result;
    }
    function makeValueRow(obj) {
        let result = '<tr>';
        for (let key in obj) {
            result += '<td>' + escapeHtml(obj[key]) + '</td>';
        }
        result += '</tr>';
        return result;
    }
    function escapeHtml(value) {
        if (typeof (value) === 'string') {
            value = value.replace(/&/g, '&amp;')
                .replace(/</g, '&lt;')
                .replace(/>/g, '&gt;')
                .replace(/"/g, '&quot;')
                .replace(/'/g, '&#39;');
        }
        return value;
    }
    console.log(outputArr.join('\n'));
}

solve(['[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]']);
