function solve(input) {
    const horses = input.shift().split('|');
    let line = input.shift();
    while (line != 'Finish') {
        //TODO: command        
        const lineArr = line.split(' ');
        const command = lineArr[0];
        const firstHorse = lineArr[1];
        const secondHorse = lineArr[2];

        const firstHorsePosition = horses.indexOf(firstHorse); 
        const secondHorsePosition = horses.indexOf(secondHorse);

        switch (command) {
            case 'Retake':
              
                if(firstHorsePosition < secondHorsePosition){
                    horses[firstHorsePosition] = secondHorse;
                    horses[secondHorsePosition] = firstHorse; 
                    console.log(`${firstHorse} retakes ${secondHorse}.`);
                }
                break;

            case 'Trouble':
                if(firstHorsePosition > 0){
                    horses[firstHorsePosition] = horses[firstHorsePosition - 1];
                    horses[firstHorsePosition - 1] = firstHorse;
                    console.log(`Trouble for ${firstHorse} - drops one position.`);
                }
                break;

            case 'Rage':
                if(firstHorsePosition === horses.length - 2){
                    horses[horses.length - 2] = horses[horses.length - 1];
                    horses[horses.length - 1] = firstHorse;                    
                } else if(firstHorsePosition !== horses.length - 1){
                    horses[firstHorsePosition] = horses[firstHorsePosition + 1];
                    horses[firstHorsePosition + 1] = horses[firstHorsePosition + 2];
                    horses[firstHorsePosition + 2] = firstHorse;                    
                }
                console.log(`${firstHorse} rages 2 positions ahead.`);
                break;

            case 'Miracle':
                const lastHorse = horses.shift();
                horses.push(lastHorse);
                console.log(`What a miracle - ${lastHorse} becomes first.`);
                break;
        }

        line = input.shift();
    }

    console.log(horses.join('->'));
    console.log(`The winner is: ${horses.pop()}`);
}

// solve(
//     [
//         'Bella|Alexia|Sugar',
//         'Retake Alexia Sugar',
//         'Rage Bella',
//         'Trouble Bella',
//         'Finish'
//     ]
// )