function signCheck(...numbers) {
    return numbers
      .filter((num)=>num<0)
      .length % 2 === 0 ? 'Positive' : 'Negative'
}

    // console.log(signCheck(5,
    // 12,
    // -15
    // ))

    // console.log('---------')

    // console.log(signCheck(-6,
    // -12,
    // 14
    // ))
    
    // console.log('---------')  

    // console.log(signCheck(-1,
    //     -2,
    //     -3
    //     ))
    
    // console.log('---------')

    // console.log(signCheck(-5,
    // 1,
    // 1
    // ))