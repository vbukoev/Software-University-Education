function encodeAndDecodeMessages() {
    const [encodeBtn, decodeBtn] = Array.from(document.querySelectorAll('button'));
    let [sentText, receivedText] = Array.from(document.querySelectorAll('textarea'));

    encodeBtn.addEventListener('click', x=>{
        let out = '';
        for (const letter of sentText.value) {
            out += String.fromCharCode(letter.charCodeAt(0) + 1);
        }
        sentText.value = '';
        receivedText.value = out;
    })

    decodeBtn.addEventListener('click', x => {
        let out = '';
        for (const letter of receivedText.value) {
            out += String.fromCharCode(letter.charCodeAt(0) - 1);
        }
        receivedText.value = out;
    })
}