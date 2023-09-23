function subtract() {
    let num1 = parseFloat(document.querySelector('#firstNumber').value);
    let num2 = parseFloat(document.querySelector('#secondNumber').value);
    document.querySelector('#result').textContent = num1 - num2
}