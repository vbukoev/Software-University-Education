function solve(wordCheck, str){
    str = str.split(' ');
    let out =  `${wordCheck} not found!`;
    for(let word of str){
        word = word.toLowerCase();
        if(word == wordCheck.toLowerCase()){
            out = word;
            break
        }
    }
    console.log(out);
}

//solve('javascript','JavaScript is the best programming language');
//solve('python', 'JavaScript is the best programming language');