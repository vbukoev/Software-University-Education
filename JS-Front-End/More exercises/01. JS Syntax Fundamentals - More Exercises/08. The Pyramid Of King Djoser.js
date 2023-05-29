function pyramid(base, increment){
    let stoneQty = 0;
    let marbleQty = 0;
    let lapisLazuliQty = 0;
    let goldQty = 0;
    let currRow = 0;
    let currBase = base; //this is going to be the initial value of the base

    while(currBase > 2){
        let marble = currBase * 4 - 4;
        let stone = currBase * currBase - marble;
        stoneQty = stoneQty + stone;
        currRow = currRow + 1;
        
        if(currRow % 5 == 0){
            lapisLazuliQty = lapisLazuliQty + marble;
        }
        else{
            marbleQty = marbleQty + marble;
        }
        currBase = currBase - 2;
    }
    currRow++;
    let gold = currBase ** 2;

    console.log(`Stone required: ${Math.ceil(stoneQty * increment)}`);
    console.log(`Marble required: ${Math.ceil(marbleQty * increment)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(lapisLazuliQty * increment)}`);
    console.log(`Gold required: ${Math.ceil(gold * increment)}`);
    console.log(`Final pyramid height: ${Math.floor(currRow * increment)}`);
}

//pyramid(11, 1);
//console.log('////////////////////////');
//pyramid(11, 0.75);
//console.log('////////////////////////');
//pyramid(12, 1);