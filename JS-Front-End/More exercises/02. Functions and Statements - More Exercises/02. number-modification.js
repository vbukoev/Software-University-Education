function modification(numbers){
    numbers = numbers.toString();

    function average(numbers){
        let sum = 0
        for(let number of numbers){
            sum += parseInt(number)
        }
        return sum / numbers.length
    }

    while(average(numbers) < 5){
        numbers += '9';
    }
    console.log(numbers)
}

//modification(101)