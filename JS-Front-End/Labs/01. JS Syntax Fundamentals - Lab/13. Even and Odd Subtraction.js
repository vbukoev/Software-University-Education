function solve(list){
    let sumEven = 0;
    let sumOdd = 0;
    for (let i=0; i < list.length; i++ ){
        let num = list[i];
        if(num%2==0){
            sumEven = sumEven + num;
        }
        else{
            sumOdd = sumOdd + num; 
        }
    }
    console.log(`${sumEven - sumOdd}`)
}

//solve([1,2,3,4,5,6])