function oddAndEvenSum(numbers){
    numbers = numbers.toString();
    let oddNumbers = 0;
    let evenNumbers = 0;

    for(let number of numbers){
        number = parseInt(number)
        if(number % 2 === 0){
            evenNumbers = evenNumbers + number;
        }else{
            oddNumbers = oddNumbers + number;
        }
    }
    console.log(`Odd sum = ${oddNumbers}, Even sum = ${evenNumbers}`)
}

// oddAndEvenSum(1000435);
// oddAndEvenSum(3495892137259234)