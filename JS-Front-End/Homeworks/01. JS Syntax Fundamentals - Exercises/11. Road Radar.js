function solve(speed, area){
    function speeding(limit){
        if(speed <= limit){
            console.log(`Driving ${speed} km/h in a ${limit} zone`);
        }
        else {
            let status = 'reckless driving';
            let difference = speed - limit;
            if(difference <= 20){
                status = 'speeding';
            }
            else if(difference <= 40){
                status = 'excessive speeding';
            }
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${limit} - ${status}`);
        }
    }

    if(area == 'motorway'){
        speeding(130, 'motorway')
    }
    else if(area == 'interstate'){
        speeding(90, 'interstate')
    }
    else if(area == 'city'){
        speeding(50, 'city')
    }
    else if(area == 'residential'){
        speeding(20, 'residential')
    }
}
//solve(40, 'city');
//solve(21, 'residential');
//solve(120, 'interstate');
//solve(200, 'motorway' );