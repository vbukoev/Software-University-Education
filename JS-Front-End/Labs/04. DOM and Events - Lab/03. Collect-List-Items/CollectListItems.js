function extractText() {
    const liElements = Array.from(document.querySelectorAll('#items > li'));
    const res = document.getElementById('result');
    liElements
        .forEach((li) => {
            res.textContent += li.textContent + '\n';
        })
}