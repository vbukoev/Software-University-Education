function students(list){
    let res = {}

    list.forEach(item => {
        if(!item.includes(' with email ')) {
            let[courseName, capacity] = item.split(': ')
            if(!res.hasOwnProperty(courseName)){
                res[courseName] = {}
                res[courseName].capacity = 0
                res[courseName].users = []
            }

            res[courseName].capacity = res[courseName].capacity + parseInt(capacity)
        } else{
            let [userName, data] = item.split(' with email ')
            let [email, courseName] = data.split(' joins ')
            if(res.hasOwnProperty(courseName) && res[courseName].capacity > res[courseName].users.length){
                [userName, credits] = userName.split('[')
                res[courseName].users.push({
                    name: userName, email: email, credits: parseInt(credits.replace(']', ''))
                })
            }
        }
    })

    Object.entries(res).sort(([courseNameA, courseA],[courseNameB, courseB]) => courseB.users.length - courseA.users.length)
                       .forEach(([courseName, course]) => {
                        console.log(`${courseName}: ${course.capacity - course.users.length} places left`)
                        course.users.sort((a, b) => b.credits - a.credits)
                         .forEach(({credits, name, email}) => console.log(`--- ${credits}: ${name}, ${email}`))
                       })
}