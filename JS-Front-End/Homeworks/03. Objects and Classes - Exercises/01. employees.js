function parseEmployees(input){
    Object.entries(
        input.reduce((data, employee) => {
            data[employee] = employee.length;
            return data;
        }, {}) 
    ).forEach(([employee, length]) => {
        console.log(`Name: ${employee} -- Personal Number: ${length}`)
    })
}

//parseEmployees([
//   'Silas Butler',
//   'Adnaan Buckley',
//   'Juan Peterson',
//   'Brendan Villarreal'
//    ])