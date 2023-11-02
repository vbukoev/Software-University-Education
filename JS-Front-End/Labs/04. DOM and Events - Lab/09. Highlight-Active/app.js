function focused() {
    const input = document.querySelectorAll("input[type = 'text']");
    for (let i = 0; i < input.length; i++) {
        const ins = input[i];
        ins.addEventListener('focus', (e) =>{
            const div = e.target.parentNode;
            div.classList.add('focused');
        });
        ins.addEventListener('blur', (e) =>{
            const div = e.target.parentNode;
            div.classList.remove('focused');
        })
    }
}