function history(obj, activity){

    obj.openTab = function (name) {
        if (!this["Open Tabs"].includes(name)) {
            this["Open Tabs"].push(name)
            this["Browser Logs"].push(`Open ${name}`)
        }
    }
    obj.closeTab = function (name) {
        if (this["Open Tabs"].includes(name)) {
            this["Open Tabs"].splice(this["Open Tabs"].indexOf(name), 1)
            this["Recently Closed"].push(name)
            this["Browser Logs"].push(`Close ${name}`)
        }
    }
    obj.clearHistory = function (){
        this['Open Tabs'] = []
        this['Recently Closed'] = []
        this['Browser Logs'] = []
    }
    obj.printInfo = function () {
        console.log(`${this["Browser Name"]}`)
        console.log(`Open Tabs: ${this['Open Tabs'].join(', ')}`)
        console.log(`Recently Closed: ${this['Recently Closed'].join(', ')}`)
        console.log(`Browser Logs: ${this['Browser Logs'].join(', ')}`)
    }


    for (item of activity) {
        [command, ...name] = item.split(' ')

        if (command === 'Close') {
            obj.closeTab(name.join(' '))
        } else if
        (command === 'Open') {
            obj.openTab(name.join(' '))
        } else if
        (command === 'Clear') {
            obj.clearHistory(name.join(' '))
        }
    }
    obj.printInfo()
}
//
//history(
//    {"Browser Name":"Mozilla Firefox",
//    "Open Tabs":["YouTube"],
//    "Recently Closed":["Gmail", "Dropbox"],
//    "Browser Logs":["Open Gmail", "Close Gmail", "Open Dropbox", "Open YouTube", "Close Dropbox"]
//    },
//    ["Open Wikipedia", "Clear History and Cache", "Open Twitter"]
//)