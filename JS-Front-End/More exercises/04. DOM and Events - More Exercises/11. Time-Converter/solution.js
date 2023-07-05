function attachEventsListeners() {
    const daysBtn = document.querySelector('#daysBtn');
    const hoursBtn = document.querySelector('#hoursBtn');
    const minutesBtn = document.querySelector('#minutesBtn');
    const secondsBtn = document.querySelector('#secondsBtn');
    let out = Array.from(document.querySelectorAll('input[type="text"]'));

    let convertTime = {
        'days': 0,
        'hours': 0,
        'minutes': 0,
        'seconds': 0,
        calculateDays(){
            this.days = this.hours / 24;
        },

        calculateHours(){
            this.hours = this.days * 24;
        },

        calculateMinutes(){
            this.minutes = this.hours * 60;
        },

        calculateSeconds(){
            this.seconds = this.minutes * 60;
        }
    }

    function show(){
        out[0].value = convertTime.days;
        out[1].value = convertTime.hours;
        out[2].value = convertTime.minutes;
        out[3].value = convertTime.seconds;
    }
        //days
    daysBtn.addEventListener('click', x=>{
        let days = document.querySelector('#days');
        convertTime.days = Number(days.value);
        convertTime.calculateHours();
        convertTime.calculateMinutes();
        convertTime.calculateSeconds();
        show();
    } );
        //hours
    hoursBtn.addEventListener('click', x=>{
        let hours = document.querySelector('#hours');
        convertTime.hours = Number(hours.value);
        convertTime.calculateDays();
        convertTime.calculateMinutes();
        convertTime.calculateSeconds();
        show();
    } );
        //minutes
    minutesBtn.addEventListener('click', x=>{
        let minutes = document.querySelector('#minutes');
        convertTime.minutes = Number(minutes.value);
        convertTime.hours = convertTime.minutes / 60;
        convertTime.calculateDays();
        convertTime.calculateSeconds();
        show();
    } );
        //seconds
    secondsBtn.addEventListener('click', x=>{
        let seconds = document.querySelector('#seconds');
        convertTime.seconds = Number(seconds.value);
        convertTime.minutes = convertTime.seconds / 60;
        convertTime.hours = convertTime.minutes / 60;        
        convertTime.calculateDays();
        show();
    } );
}