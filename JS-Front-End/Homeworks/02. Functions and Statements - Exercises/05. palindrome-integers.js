function palindromeIntegers(numbers){
    numbers
        .forEach((num) => {
        console.log(isPalindrome(num));
    });

    function isPalindrome(num){
        let reversed = Number([...num.toString()].reverse().join(''));
        return num === reversed;
    }
}


//TEST
//palindromeIntegers([123,323,421,121]);
//palindromeIntegers([32,2,232,1010]);