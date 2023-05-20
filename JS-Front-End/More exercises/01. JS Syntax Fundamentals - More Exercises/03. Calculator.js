function calculate(number1, operator, number2){
    let result = {
        '+' : number1 + number2,
        '-' : number1 - number2,
        '*' : number1 * number2,
        '/' : number1 / number2,
    }
    console.log(result[operator].toFixed(2));
}

//calculate(5,
//    '+',
//    10
//    );
//
//calculate(25.5,
//    '-',
//    3);