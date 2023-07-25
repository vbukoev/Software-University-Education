function validateDistance(list){
    function distance(x1, y1, x2, y2){
        return Math.sqrt((x2-x1) ** 2 + (y2-y1) ** 2);
    }

    const [x1, y1, x2, y2] = list
    const dis1 = distance(x1, y1, 0, 0);
    const dis2 = distance(x2, y2, 0, 0);
    const dis3 = distance(x1, y1, x2, y2);

    if(Number.isInteger(dis1)){
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    } else{
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }

    if(Number.isInteger(dis2)){
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    } else{
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }

    if(Number.isInteger(dis3)){
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    } else{
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
}

// validateDistance([3, 0, 0, 4]);
// console.log('-----------')
// validateDistance([2, 1, 1, 1]);