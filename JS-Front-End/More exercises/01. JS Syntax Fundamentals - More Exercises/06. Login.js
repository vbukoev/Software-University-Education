function login(list){
    let username = list.shift();
    for(let i = 0; i< list.length; i++){
        if(username == list[i].split("").reverse().join("")){
            console.log(`User ${username} logged in.`)
            break
        }
        else{
            if(i==3){ //this is the forth time that the user tries to log in and he/she is going to be blocked
                console.log(`User ${username} blocked!`)
                break
            }
            console.log("Incorrect password. Try again.")
        }
    }
}

//login(['Acer','login','go','let me in','recA']);
//console.log('----------------------');
//login(['momo','omom'] );
//console.log('----------------------');
//login(['sunny','rainy','cloudy','sunny','notsunny']);