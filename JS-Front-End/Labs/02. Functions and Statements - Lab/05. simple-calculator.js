function calculator(firstNum, secondNum, op) {
    const multiply = (a,b) => a*b;
    const divide = (a,b) => a/b;
    const add = (a,b) => a+b;
    const subtract = (a,b) => a-b;

    switch(op){
        case 'multiply':
            return multiply(firstNum, secondNum);
        
        case 'divide':
            return divide(firstNum, secondNum);
        
        case 'add':
            return add(firstNum, secondNum);
        
        case 'subtract':
            return subtract(firstNum, secondNum);
        
    }
}

//console.log(calculator(40,8,'divide'))