function solve(str){
    str = str.split(' ');
    function lettersNumbers(string){
        return Boolean(string.match(/#[A-Za-z]/));
    }

    for(const word of str){
        if(lettersNumbers(word)){
            console.log(word.slice(1, word.length))
        }
    }
}

//solve('Nowadays everyone uses # to tag a #special word in #socialMedia');
//solve('The symbol # is known #variously in English-speaking #regions as the #number sign');