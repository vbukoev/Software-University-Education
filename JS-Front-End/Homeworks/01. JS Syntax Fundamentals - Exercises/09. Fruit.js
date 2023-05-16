function solve(fruit, weight, pricePerKg){
    weight/=1000;
    console.log(`I need $${(weight*pricePerKg).toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`);
}

//Test for the solution
//solve('orange', 2500, 1.80);
//solve('apple', 1563, 2.35);