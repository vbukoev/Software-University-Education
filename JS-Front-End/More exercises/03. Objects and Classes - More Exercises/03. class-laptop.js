class Laptop{
    constructor(info, quality){
        this.info = info
        this.isOn = Boolean(false)
        this.quality = quality
    }

    turnOn() {
        this.quality -= 1
        this.isOn = Boolean(true)
    }

    turnOff() {
        this.quality -= 1
        this.isOn = Boolean(false)
    }

    showInfo(){
        return JSON.stringify(this.info)
    }

    get price(){
        return  800 - (this.info.age * 2) + (this.quality * 0.5);
    }
}