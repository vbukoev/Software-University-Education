function wordsTracker(input){
    let searchedWords = input.shift().split(' ');
    let words = {};
    for (const word of searchedWords) {
        let count = input.filter((w) => w === word).length;
        words[word] = count;
    }
    let sortedWords = Object.entries(words)
    .sort((wordA, wordB) =>{
        let [_nameA, countA] = wordA;// name A and B are unused but i want to keep them in the solution
        let [_nameB, countB] = wordB;// name A and B are unused but i want to keep them in the solution

        return countB-countA;
    });

    for (const [word, count] of sortedWords) {
        console.log(`${word} - ${count}`);
    }
}

//wordsTracker(
//    [
//        'this sentence',
//        'In', 'this', 'sentence', 'you', 'have',
//        'to', 'count', 'the', 'occurrences', 'of',
//        'the', 'words', 'this', 'and', 'sentence',
//        'because', 'this', 'is', 'your', 'task'
//    ]
//)