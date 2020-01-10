function solve(a) {
    console.log(a.slice(0, a.length - 1).join(a[a.length-1]));
}
solve(['One', 'Two', 'Three', 'Four', 'Five', '-']);