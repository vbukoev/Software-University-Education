function solve(arr){
    arr.sort((a, b)=> a - b);
    let out = [];
    while(arr.length > 0){
        out.push(arr.shift())
        out.push(arr.pop())
    }
    //console.log(out)
    return out
}

//solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56])