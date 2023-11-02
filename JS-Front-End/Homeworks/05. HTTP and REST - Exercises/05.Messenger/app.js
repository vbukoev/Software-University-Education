function attachEvents() {
   const name = document.querySelector('input[name=\'author\']');
   const content = document.querySelector('input[name=\'content\']');
   const messages = document.querySelector('#messages');
   const [submit, refresh] = Array.from(document.querySelectorAll('#controls > input'));
   const apiUrl = 'http://localhost:3030/jsonstore/messenger';

   submit.addEventListener('click', () =>
   {
    const message = {
        author: name.value,
        content: content.value,
    }

    const httpHeaders = {
        'Content-Type': 'application/json'
    };
    const body = JSON.stringify(message);

    fetch(apiUrl, {
        method: 'POST', httpHeaders, body 
    })
   })

   refresh.addEventListener('click', () => {
    messages.textContent = '';
    let res = [];
    fetch(apiUrl).then(x=> x.json()).then(x=> {
        for (const key in x) {
            res.push(`${x[key].author}: ${x[key].content}`)
        }
        messages.textContent = res.join('\n');
    }).catch()
   })
}
attachEvents();