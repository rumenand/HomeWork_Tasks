'use strict';

function solve(json) {
    let outputArr = "<table>\n";
    for (const row of json) {               
        outputArr += (makeValueRow(JSON.parse(row)))+"\n";
    }
    outputArr += "</table>";    
    function makeValueRow(obj) {
        let result = '\t<tr>\n';
        for (let key in obj) {
            result += '\t\t\<td>' + escapeHtml(obj[key]) + '</td>\n';
        }
        result += '\t</tr>';
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
    console.log(outputArr);
}

solve(['{"name":"Pesho","position":"Promenliva","salary":100000}',
    '{"name":"Teo","position":"Lecturer","salary":1000}',
    '{"name":"Georgi","position":"Lecturer","salary":1000}']);
