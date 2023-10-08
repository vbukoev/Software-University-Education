function solve() {
  const [generateTextArea, buyTextArea] = Array.from(document.getElementsByTagName('textArea'));
  const [generateButton, buyButton] = Array.from(document.getElementsByTagName('button'));
  const tbody = document.querySelector('.table > tbody');
  generateButton.addEventListener('click', generateHandler);
  buyButton.addEventListener('click', buyHandler);
  
  function generateHandler(){
    const data = JSON.parse(generateTextArea.value);
    for (const {img, name, price, decFactor} of data) {
      const tableRow = createElement('tr', '', tbody);
      const firstColumnTd = createElement('td', '', tableRow);
      createElement('img', '', firstColumnTd, '', '', {src: img});
      const secondColumnTd = createElement('td', '', tableRow);
      createElement('p', name, secondColumnTd);
      const thirdColumnTd = createElement('td', '', tableRow);
      createElement('p', price, thirdColumnTd);
      const forthColumnTd = createElement('td', '', tableRow);
      createElement('p', decFactor, forthColumnTd);
      const fifthColumnTd = createElement('td', '', tableRow);
      createElement('input', '', fifthColumnTd, '', '', {type: 'checkbox'})
    }
  }

  function buyHandler(){
    let boughtItems = [];
    let totalPrice = 0;
    let totalDecFactor = 0;
    const allCheckedInputs = Array.from(document.querySelectorAll('tbody tr input:checked'))

    for (const input of allCheckedInputs) {
      const tableRow = input.parentElement.parentElement;
      const [_firstColumn, secondColumn, thirdColumn, forthColumn] = Array.from(tableRow.children);
      let item = secondColumn.children[0].textContent;
      boughtItems.push(item);
      let currentPrice = Number(thirdColumn.children[0].textContent);
      totalPrice += currentPrice;
      let currentDecFactor = Number(forthColumn.children[0].textContent);
      totalDecFactor += currentDecFactor;
    }

    buyTextArea.value += `Bought furniture: ${boughtItems.join(', ')}\n`;
    buyTextArea.value += `Total price: ${totalPrice.toFixed(2)}\n`; 
    buyTextArea.value += `Average decoration factor: ${totalDecFactor / allCheckedInputs.length}`;
  }

  //                   string, string,            string, array, object
function createElement(type, content, parentNode, id, classes, attributes){
  const htmlElement = document.createElement(type);
  if(content && type !== 'input'){
    htmlElement.textContent = content;
  }

  if(content && type === 'input'){
    htmlElement.value = content;
  }

  if(id){
    htmlElement.id = id;
  }

  if(classes){
    htmlElement.classList.add(...classes);
  }

  if(parentNode){
    parentNode.appendChild(htmlElement);
  }
  
  if(attributes){
    for (const key in attributes) {
      htmlElement.setAttribute(key, attributes[key]);
    }
  }

  return htmlElement;
}
}

