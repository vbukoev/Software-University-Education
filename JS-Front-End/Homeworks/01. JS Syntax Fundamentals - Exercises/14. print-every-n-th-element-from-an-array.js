function solve(list, num){
    let output = []

    for(let i = 0; i < list.length; i++){
        if(i % num == 0){
            output.push(list[i])
        }
    }

    return output
}

//solve(['5', '20', '31', '4', '20'], 2);

//solve(['dsa','asd','test','tset'],2);

//solve(['1', '2', '3', '4', '5'], 6);