function attachGradientEvents() {
    const gradient = document.querySelector('#gradient');
    const res = document.querySelector('#result');
    gradient.addEventListener('mousemove', showPercent);
    gradient.addEventListener('mouseout', hidePercent);

    function showPercent(e){
        const x = e.offsetX;
        const w = gradient.clientWidth;
        const percentage = parseInt((x/w)*100);
        res.textContent = `${percentage}%`;
    }

    function hidePercent(){
        res.textContent = '';
    }
}