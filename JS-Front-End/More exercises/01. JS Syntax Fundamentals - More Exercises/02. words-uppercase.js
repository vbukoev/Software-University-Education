// function solve(input){
//     input = input.split(' ');
//     let out = [];
//     for(const word of input){
//         let found = '';
//         for(const letter of word){
//             if(letter.toUpperCase() != letter.toLowerCase()){
//                 found +=letter.toUpperCase();
//             }
//             else{ //in this case there was letter.toUpperCase() == letter.toLowerCase() and the found word will be again empty string
//                 out.push(found);
//                 found = '';
//             }
//         }
//         if(found){//if there was a found word just push it to the output
//             out.push(found);
//         }
//     }
//     console.log(out.join(', '));
// }

// //solve('Hi, how are you?');
// //solve('hello');


function wordsUppercase(inputString) {
    let pattern = /\W+/gm;
    console.log(inputString.toUpperCase().split(pattern).join(' ').trim().split(' ').join(', '));
}