function solve(input){
    if(typeof input != 'number'){
        console.log(`We can not calculate the circle area, because we receive a ${typeof input}.`);
    }
    else{
        console.log(`${(Math.PI * input * input).toFixed(2)}`);
    }
}

//solve(5)
//solve('name')