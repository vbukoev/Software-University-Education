function solve(list, rotation){
    for (let i = 0; i < rotation; i++){
        list.push(list.shift());
    }
    console.log(list.join(' '));
}

//solve([51, 47, 32, 61, 21], 2);
//console.log('-------------');
//solve([32, 21, 61, 1], 4);
//console.log('-------------');
//solve([2, 4, 15, 31], 5);