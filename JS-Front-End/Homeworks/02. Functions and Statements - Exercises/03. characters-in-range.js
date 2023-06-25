function charactersInRange(firstChar, secondChar){
    let firstCharAscii = firstChar.charCodeAt(0);
    let secondCharAscii = secondChar.charCodeAt(0);
    
    let minValue = Math.min(firstCharAscii, secondCharAscii);
    let maxValue = Math.max(firstCharAscii, secondCharAscii);

    let chars = [];

    for(let asciiCode = minValue + 1; asciiCode < maxValue; asciiCode++){
        chars.push(String.fromCharCode(asciiCode));
    }

    return chars.join(' ');
}
//TESTING THE CODE 

//VVVVV


// console.log(charactersInRange('a',
// 'd'))
