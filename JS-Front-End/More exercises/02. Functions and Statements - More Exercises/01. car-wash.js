function wash(list){
    let clean = 0;

    for(let cmd of list){
        // switch(cmd){
        //     case 'soap': clean += 10;
        //     case 'water': clean *= 1.20;
        //     case 'vacuum cleaner': clean *= 1.25;
        //     case 'mud': clean *= 0.90;
        // }

        if (cmd === 'soap'){
            clean += 10;
        } else if (cmd === 'water'){
            clean *= 1.20;
        } else if (cmd === 'vacuum cleaner'){
            clean *= 1.25;
        } else if (cmd === 'mud'){
            clean *= 0.9;
        }
    }
    console.log(`The car is ${clean.toFixed(2)}% clean.`)
}

//TO TEST THE SOLUTION OF THE TASK UNCOMMENT THE FOLLOWING LINES:

//wash(['soap', 'soap', 'vacuum cleaner', 'mud', 'soap', 'water']);

//wash(["soap", "water", "mud", "mud", "water", "mud", "vacuum cleaner"])