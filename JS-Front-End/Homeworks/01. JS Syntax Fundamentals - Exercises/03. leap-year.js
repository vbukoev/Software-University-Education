function solve(input){
    if(input%400 == 0 || input % 4 == 0 && input % 100 != 0) {
        console.log('yes');
    }
    else {
        console.log('no');
    }
}

//solve(1984);
//solve(2003);
//solve(4);