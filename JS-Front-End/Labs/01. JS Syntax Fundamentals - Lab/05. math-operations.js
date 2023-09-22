function solve(numberOne, numberTwo, operator){  
    let result = {
        '+' : numberOne + numberTwo,
        '-' : numberOne - numberTwo,
        '*' : numberOne * numberTwo,
        '**': numberOne ** numberTwo,
        '/' : numberOne / numberTwo,
        '%' : numberOne % numberTwo
    }
    console.log(result[operator])
}

//solve(5, 6, '+')