function garage(list){
    garage = {}
    for (const carInfo of list) {
        parts = carInfo.split(' - ')
        garageNum = parts[0]
        if(!garage.hasOwnProperty(garageNum)){
            garage[garageNum] = {}
            garage[garageNum].cars = []
        }
        obj = {}
        parts[1].split(", ").forEach(element => {
            const [key, value] = element.split(": ")
            obj[key] = value
        })
        garage[garageNum].cars.push(obj)
    }
    for (const key in garage) {
        console.log(`Garage № ${key}`)
        cars = garage[key].cars
        for (const car of cars) {
            const props = []
            for (const prop in car) {
                props.push(`${prop} - ${car[prop]}`)
            }
            console.log(`--- ${props.join(', ')}`)
        }
    }
}

// garage(
//     [   
//         '1 - color: green, fuel type: petrol',
//         '1 - color: dark red, manufacture: WV',
//         '2 - fuel type: diesel',
//         '3 - color: dark blue, fuel type: petrol'
//     ]
// )