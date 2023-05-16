function solve(input){
    let numbers = input.toString();
    let sum = 0;

    for(let i = 0; i<numbers.length; i++){
        sum += parseInt(numbers[i]);
    }
    console.log(sum);
}

//solve(97561);
//solve(245678);
//solve(543);