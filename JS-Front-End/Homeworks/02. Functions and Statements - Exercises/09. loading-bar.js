function loadingBar(num){
    let numberRange = Math.floor(num / 10);
    let target = 10;
    if(target === numberRange){
        console.log("100% Complete!\n" + "[%%%%%%%%%%]");
    }else{
        console.log(`${num}% [${"%".repeat(numberRange)}${".".repeat(target - numberRange)}]\nStill loading...`)
    }
}

// loadingBar(50);