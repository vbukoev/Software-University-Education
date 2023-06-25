// function calculations(firstNum,secondNum, thirdNum){
//     const sum=(a,b)=> a+b;
//     const subtract=(c,d)=>c-d;

//     return subtract(sum(firstNum, secondNum), thirdNum);
// }

const calculations = (firstNum,secondNum, thirdNum) => {
    const sum=(a,b)=> a+b;
    const subtract=(c,d)=>c-d;

    return subtract(sum(firstNum, secondNum), thirdNum);
}

// console.log(calculations(1,
//     17,
//     30))