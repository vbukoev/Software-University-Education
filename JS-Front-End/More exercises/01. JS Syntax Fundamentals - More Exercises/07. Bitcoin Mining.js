function solve(list){
    let bitcoins = 0;
    let firstDayBitcoin = 0;
    let total = 0;
    let days = 0;
    let priceOfGold = 67.51;
    let bitcoinPrice = 11949.16;

    for(let gold of list){
        days = days + 1;
        if(days % 3 == 0){
            gold *= 0.7;
        }
        total = total + gold * priceOfGold;
        while(total>=bitcoinPrice){
            bitcoins = bitcoins + 1;
            total -= bitcoinPrice;
            if(firstDayBitcoin == 0){
                firstDayBitcoin = days
            }
        }
    }
    if(bitcoins){
        console.log(`Bought bitcoins: ${bitcoins}`);
        console.log(`Day of the first purchased bitcoin: ${firstDayBitcoin}`);
    }
    else{
        console.log('Bought bitcoins: 0');
    }
    console.log(`Left money: ${total.toFixed(2)} lv.`);
}

//solve([100, 200, 300]);
//solve([50, 100]);
//solve([3124.15, 504.212, 2511.124]);