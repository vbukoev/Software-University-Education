function solve(arr){
    arr.sort((a,b) => a.localeCompare(b))

    let i = 1;
    for (const name of arr){
        console.log(`${i}.${name}`);
        i++;
    }
}

//solve(["John", "Bob", "Christina", "Ema"]);