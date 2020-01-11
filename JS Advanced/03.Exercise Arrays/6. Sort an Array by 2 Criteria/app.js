function solve(data) {
    console.log(data.sort((a, b) => {
        result = a.length - b.length;
        if (result == 0) result = a.localeCompare(b);
        return result;
    }).join("\n"));
}
solve(['alpha', 'beta', 'gamma']);
