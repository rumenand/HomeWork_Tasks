function solve(data) {
    console.log([...new Set(data)].sort((a, b) => {
        return a.length - b.length || a.localeCompare(b);
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
