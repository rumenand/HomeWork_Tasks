function solve(moves){
    const initBoard = () => Array.from(Array(3), () => new Array(false,false,false));
    const hasMove = (a) => a.some(row => row.some(x=>x ===false));
    const swapPlayers = (a) => (a === 'X')?'O':'X';
    const getResult = (a,b) => a.every(x=>x === b);
    let curPl = 'X';
    let board = initBoard();
    let winner;
    while(hasMove(board) && moves.length)
    {
        let cMove = moves.shift().split(" ");
        if (!setOnBoard(curPl,cMove,board)){
            console.log("This place is already taken. Please choose another!");
            continue;
        }
        if (chWinner(curPl,board)) {
            winner = curPl;
            break;
        }
        curPl = swapPlayers(curPl);
    }
    if (winner === undefined) console.log("The game ended! Nobody wins :(");
    else console.log(`Player ${winner} wins!`);
    board.map(x => console.log(x.join("\t")));
    function setOnBoard(p,m,b){
        if (b[m[0]][m[1]] === false) {
        b[m[0]][m[1]] = p;
        return true;
        }
        return false;
    }
    function chWinner(p,board){
        let diag = getResult(board.map((x,i) => x[i]));
        if(getResult(board[0],p) || getResult(board[1],p) || getResult(board[2],p)
        || getResult(board.map(x => x[0]),p)
        || getResult(board.map(x => x[1]),p)
        || getResult(board.map(x => x[2]),p)
        || getResult(board.map((x,i) => x[i]),p)
        || getResult(board.map((x,i) => x[board.length-1-i]),p)
        )
        return true;
        else false;
    }
}

solve(["0 1",
"0 0",
"0 2",
"2 0",
"1 0",
"1 2",
"1 1",
"2 1",
"2 2",
"0 0"]
);