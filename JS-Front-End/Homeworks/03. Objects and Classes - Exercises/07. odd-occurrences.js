function occurrences(string){
    string = string.split(' ');
    let res = new Map();

    for(let word of string){
        word = word.toLowerCase()
        if(res.has(word)){
            res.set(word, res.get(word) + 1);
        } else{
            res.set(word, 1);
        }
    }

    for(item of res){
        if(item[1] % 2 !== 0){
            process.stdout.write(`${item[0]} `)
        }
    }
}

//occurrences('Java C# Php PHP Java PhP 3 C# 3 1 5 C#')