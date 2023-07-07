function validate() {
    const email = document.querySelector('#email');
    function emailValidation(){
        const res = email.value.match(/^[a-z]+@[a-z]+\.[a-z]+$/);
        if(res){
            email.classList.remove('error');
        } else{
            email.classList.add('error');
        }
    }
    email.addEventListener('change', emailValidation)
}