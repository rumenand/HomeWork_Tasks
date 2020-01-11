function solve(data) {
    let arr = data.reduce((a, b, i) => {
        if (b === 'add') a.push(i + 1);
        else if (b === 'remove') a.pop();
        return a;
    }, [])
    console.log((arr.length > 0) ? arr.join("\n") : "Empty");
}
solve(['add','add','add','add']);