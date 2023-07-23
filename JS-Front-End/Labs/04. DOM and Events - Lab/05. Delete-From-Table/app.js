function deleteByEmail() {
    const res = document.getElementById('result')
    const input = document.querySelector('input[name="email"]')
    const evenTds = Array.from(document.querySelectorAll('td:nth-child(even)'));
    let emailValue = input.value;
    let foundElement = evenTds.find((td) => td.textContent === emailValue);
    if(foundElement){
        console.log(foundElement);
        foundElement.parentElement.remove();
        res.textContent = 'Deleted.';
    } else{
        res.textContent = 'Not found.';
    }
}