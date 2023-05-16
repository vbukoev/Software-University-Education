function solve(start, end){
    let sum = [];
    for (let i = start; i <= end; i++){
        sum.push(i);
    }
    console.log(`${sum.join(' ')}\nSum: ${sum.reduce((accumulator, currValue) => accumulator + currValue, 0)}`);
}

//solve(5, 10);
//solve(0, 26);
//solve(50, 60);