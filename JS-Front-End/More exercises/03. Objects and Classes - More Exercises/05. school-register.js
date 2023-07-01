function school(list){
    schoolBook = {}
    for (const item of list) {
        let [name, grade, avrScore] = item.split(', ')
        name = name.split(': ')[1]
        grade = parseInt(grade.split(': ')[1])
        avrScore = parseFloat(avrScore.split(': ')[1])
        if(avrScore >= 3){
            grade += 1
            if(!schoolBook.hasOwnProperty(grade)){
                schoolBook[grade] = {}
                schoolBook[grade].students = []
                schoolBook[grade].totalScore = 0
            }
            schoolBook[grade].students.push(name)
            schoolBook[grade].totalScore += avrScore
        }
    }
    for (classLevel of Object.entries(schoolBook)){
        console.log(`${classLevel[0]} Grade`);
        console.log(`List of students: ${classLevel[1].students.join(', ')} `)
        console.log(`Average annual score from last year: ${(classLevel[1].totalScore / classLevel[1].students.length).toFixed(2)}`)
        console.log()
    }
}   

//school(
//    [
//        "Student name: Mark, Grade: 8, Graduated with an average score: 4.75",
//         "Student name: Ethan, Grade: 9, Graduated with an average score: 5.66",
//         "Student name: George, Grade: 8, Graduated with an average score: 2.83",
//         "Student name: Steven, Grade: 10, Graduated with an average score: 4.20",
//         "Student name: Joey, Grade: 9, Graduated with an average score: 4.90",
//         "Student name: Angus, Grade: 11, Graduated with an average score: 2.90",
//         "Student name: Bob, Grade: 11, Graduated with an average score: 5.15",
//         "Student name: Daryl, Grade: 8, Graduated with an average score: 5.95",
//         "Student name: Bill, Grade: 9, Graduated with an average score: 6.00",
//         "Student name: Philip, Grade: 10, Graduated with an average score: 5.05",
//         "Student name: Peter, Grade: 11, Graduated with an average score: 4.88",
//         "Student name: Gavin, Grade: 10, Graduated with an average score: 4.00"
//    ]
//)