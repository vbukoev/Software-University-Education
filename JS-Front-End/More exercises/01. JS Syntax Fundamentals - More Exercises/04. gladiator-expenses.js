function solve(lostFights, helmetPrice, swordPrice, shieldPrice, armorPrice){
    let helmetRepair = 0;
    let swordRepair = 0;
    let shieldRepair = 0;
    let armorRepair = 0;
    let shieldInRow = 0;    
    for(let i = 1; i < lostFights + 1; i++){ // 'i' is the index for lost games
        if(i % 2 == 0){
            helmetRepair = helmetRepair + 1;
        }
        if(i % 3 == 0){
            swordRepair = swordRepair + 1;
        }
        if(i % 3 == 0 && i % 2 == 0){
            shieldRepair = shieldRepair + 1;
            shieldInRow = shieldInRow + 1;
            if(shieldInRow == 2){
                shieldInRow = 0;
                armorRepair = armorRepair + 1;
            }
        }
    }
    let expenses = ((helmetRepair * helmetPrice) + 
                    (swordRepair * swordPrice) +
                    (shieldRepair * shieldPrice) + 
                    (armorRepair * armorPrice)).toFixed(2);
    console.log(`Gladiator expenses: ${expenses} aureus`);
}

// solve(7,
//     2,
//     3,
//     4,
//     5)

 //  solve(23,
 //      12.50,
 //      21.50,
 //      40,
 //      200)