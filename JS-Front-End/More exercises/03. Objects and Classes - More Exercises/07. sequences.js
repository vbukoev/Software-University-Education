function sequence(list){

    //store only the unique arrays
    list = list.map(el => JSON.parse(el))
    list.forEach(el => el.sort((a, b) => b - a)) 
    let res = []
    //loop for the first lists
    for (let i = 0; i < list.length; i++) {
        let currList = list[i]
        let isUnique = true    

        //loop for the next lists
        for (let j = 0; j < res.length; j++) {
            let nextList = res[j]
            if(nextList.toString() === currList.toString()){ //check if the arrays are the same and if they are it means they are not unique!
                isUnique = false
                break
            }
        }
        if(isUnique){ // if the arrays are unique
            res.push(currList)
        } 
    }
    res.sort((a, b)=> a.length - b.length)
    res.forEach(el => console.log(`[${el.join(', ')}]`))
}

//sequence(
//    [
//        "[-3, -2, -1, 0, 1, 2, 3, 4]", "[10, 1, -17, 0, 2, 13]", "[4, -3, 3, -2, 2, -1, 1, 0]"
//    ]
//)