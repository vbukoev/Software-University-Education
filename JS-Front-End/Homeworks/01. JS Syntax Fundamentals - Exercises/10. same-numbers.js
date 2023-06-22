function solve(number){
    number = number.toString();
    let numberIsEqual = number[0];
    let equalNumbers = "";
    let sum = 0;
    for(let i = 0; i< number.length; i++){
        if(numberIsEqual == number[i]){
            equalNumbers += "1";
        }
        sum += parseInt(number[i]);
    }
    if(equalNumbers.length == number.length){
        console.log(`true\n${sum}`)
    }
    else {
        console.log(`false\n${sum}`)
    }
}

//solve(2222222);
//solve(1234);