function validSolution(board) {
    for (let row = 0; row < 9; row++) {
        let rowValues = [];
        for (let col = 0; col < 9; col++) {
            if (board[row][col] === 0 || rowValues.includes(board[row][col])) {
                return false;
            }
            rowValues.push(board[row][col]);
        }
    }

    for (let col = 0; col < 9; col++) {
        let colValues = [];
        for (let row = 0; row < 9; row++) {
            if (board[row][col] === 0 || colValues.includes(board[row][col])) {
                return false;
            }
            colValues.push(board[row][col]);
        }
    }

    for (let blockRow = 0; blockRow < 9; blockRow += 3) {
        for (let blockCol = 0; blockCol < 9; blockCol += 3) {
            let blockValues = [];
            for (let row = blockRow; row < blockRow + 3; row++) {
                for (let col = blockCol; col < blockCol + 3; col++) {
                    if (board[row][col] === 0 || blockValues.includes(board[row][col])) {
                        return false;
                    }
                    blockValues.push(board[row][col]);
                }
            }
        }
    }

    return true;
}