function perfect(number){
    let divisors = [];

    for(let currNum = 1; currNum < number; currNum++){
        if(number % currNum === 0){
            divisors.push(currNum);
        }
    }

    let dvisorsSum = divisors.reduce((previosValue, currValue)=> previosValue + currValue, 0);

    if(number === dvisorsSum){
        console.log("We have a perfect number!");
    }else{
        console.log("It's not so perfect.");
    }
}

perfect(6)