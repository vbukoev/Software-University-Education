function solve(product, qnty){
    let price={
        'coffee' : 1.5,
        'water' : 1.00,
        'coke' : 1.40,
        'snacks' : 2.00
    }
    let res = (price[product]*qnty).toFixed(2)
    console.log(res)
}

//solve("coffee", 2);
//solve("water", 5);