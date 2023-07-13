function solve(input){
    let meetings= {};
    for (let line of input){
        let[ weekday, name] = line.split(' ');

        if(meetings.hasOwnProperty(weekday)){
            console.log(`Conflict on ${weekday}!`);
        } else{
            meetings[weekday] = name;
            console.log(`Scheduled for ${weekday}`)
        }
    }
    for (let key in meetings) {
        console.log(`${key} -> ${meetings[key]}`);
        }
} 

// solve(['Friday Bob',
// 'Saturday Ted',
// 'Monday Bill',
// 'Monday John',
// 'Wednesday George']
// )