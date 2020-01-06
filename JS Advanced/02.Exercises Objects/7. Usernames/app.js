function solve(data) {
    console.log([...new Set(data)].sort((a, b) => {
        let result = a.length - b.length;
        if (result == 0) result = a.localeCompare(b);
        return result;
    }).join("\n"));
}

solve(['Ashton',
    'Kutcher',
    'Ariel',
    'Lilly',
    'Keyden',
    'Aizen',
    'Billy',
    'Braston']
);
