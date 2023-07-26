function army(list){
    res = {}

    list.forEach(element => {
        if(element.includes('defeated')){
            element = element.replace(' defeated', '')
            delete res[element]
        } else if(element.includes('arrives') && !res.hasOwnProperty(element.replace(' arrives', ''))){
            element = element.replace(' arrives', '')
            res[element] = {}
            res[element].armies = []
            res[element].totalArmy = 0
        } else if(element.includes('+')){
           [armyName, count] = element.split(' + ')
           for (const key in res) {
                res[key].armies.forEach(item => {
                    if(item.name === armyName){
                        count = parseInt(count)
                        item.count += count
                        res[key].totalArmy += count
                    }
                })
            }
        } else{
            [leader, ...armyInfo] = element.split(': ')
            let [armyName, armyCount] = armyInfo[0].split(', ')
            
            if(res.hasOwnProperty(leader)){
                armyCount = parseInt(armyCount)
                res[leader].armies.push({name: armyName, count: armyCount})
                res[leader].totalArmy += armyCount
            }
        }
    })

    for (const [name, army] of Object.entries(res)
            .sort(([, a], [, b]) => b.totalArmy - a.totalArmy)) {
                console.log(`${name}: ${army.totalArmy}`)

                    for (const {name, count} of army.armies.sort((a, b) => b.count - a.count)) {
                        console.log(`>>> ${name} - ${count}`)
                    }
    }
}

//army(['Rick Burr arrives', 'Findlay arrives', 'Rick Burr: Juard, 1500', 'Wexamp arrives', 'Findlay: Wexamp, 34540', 'Wexamp + 340', 'Wexamp: Britox, 1155', 'Wexamp: Juard, 43423'])