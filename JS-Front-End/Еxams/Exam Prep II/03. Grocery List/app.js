// window.addEventListener('load', attachEvents);

function attachEvents(){
    const BASE_URL = 'http://localhost:3030/jsonstore/grocery/';
    const inputDOMSelectors = {
        product: document.getElementById('product'),
        count: document.getElementById('count'),
        price: document.getElementById('price')
    }

    const otherDOMSelectors = {
        addBtn: document.getElementById('add-product'),
        updateBtn: document.getElementById('update-product'),
        loadBtn: document.getElementById('load-product'),
        productsContainer: document.getElementById('tbody'),
        form: document.querySelector('.list')
    }

    let currentProducts = [];
    let productToEdit = {};

    otherDOMSelectors.loadBtn.addEventListener('click', loadProductHandler);
    otherDOMSelectors.updateBtn.addEventListener('click', updateProductHandler);
    otherDOMSelectors.addBtn.addEventListener('click', addProductHandler);

    function loadProductHandler(event){
        if(event){
            event.preventDefault();
        }

        otherDOMSelectors.productsContainer.innerHTML = '';

        fetch(BASE_URL)
            .then((res) => res.json())
            .then((allProductsRes) => {
                currentProducts = Object.values(allProductsRes);
                for (const {product, count, price, _id} of currentProducts) {
                    const tableRow = createElement('tr', otherDOMSelectors.productsContainer);
                    tableRow.id = _id;
                    createElement('td', tableRow, product, ['name']);
                    createElement('td', tableRow, count, ['count']);
                    createElement('td', tableRow, price, ['product-price']);
                    const buttonsTd = createElement('td', tableRow, null, ['btn']);
                    const updateBtn = createElement('button', buttonsTd, 'Update', ['update']);
                    const deleteBtn = createElement('button', buttonsTd, 'Delete', ['delete']);
                    updateBtn.addEventListener('click', loadUpdateFormHandler);
                    deleteBtn.addEventListener('click', deleteProductHandler);
                }
            });
    }

    function loadUpdateFormHandler(event){
        const id = this.parentNode.parentNode.id;
        productToEdit = currentProducts.find((p) => p._id === id);
        for (const key in inputDOMSelectors) {
            inputDOMSelectors[key].value = productToEdit[key];
        }
        otherDOMSelectors.addBtn.setAttribute('disabled', true);
        otherDOMSelectors.updateBtn.removeAttribute('disabled');
        //.find
        
    }

    function updateProductHandler(event){
        event.preventDefault();
        const { product, count, price } = inputDOMSelectors;

        const payload = JSON.stringify({
            product: product.value,
            count: count.value,
            price: price.value
        })
        const httpHeaders = {
            method: 'PATCH',
            body: payload
        }

        fetch(`${BASE_URL}${productToEdit._id}`, httpHeaders)
            .then(() => {
                loadProductHandler();
                otherDOMSelectors.addBtn.removeAttribute('disabled');
                otherDOMSelectors.updateBtn.setAttribute('disabled', true);    
                otherDOMSelectors.form.reset();
            })
            .catch((err) => console.error(err))
    }

    function addProductHandler(event){
        event.preventDefault();
        const { product, count, price } = inputDOMSelectors;
        const payload = JSON.stringify({
            product: product.value,
            count: count.value,
            price: price.value
        });
        const httpHeaders = {
            method: 'POST',
            body: payload
        };
        fetch(BASE_URL, httpHeaders)
            .then(() => { 
                loadProductHandler()
                otherDOMSelectors.form.reset();
            })
            .catch((err) => console.error(err));
    }

    function deleteProductHandler(event){
        const id = this.parentNode.parentNode.id;
        const httpHeaders = {
            method: 'DELETE'
        };
        fetch(`${BASE_URL}${id}`, httpHeaders)
            .then(() => loadProductHandler())
            .catch((err) => console.error(err));
    }

    function createElement(type, parentNode, content, classes, id, attributes, useInnerHtml) {
        const htmlElement = document.createElement(type);
    
        if (content && useInnerHtml) {
          htmlElement.innerHTML = content
        } else {
          if (content && type !== 'input') {
            htmlElement.textContent = content;
          }
    
          if (content && type === 'input') {
            htmlElement.value = content;
          }
        }
    
        if (classes && classes.length > 0) {
          htmlElement.classList.add(...classes);
        }
    
        if (id) {
          htmlElement.id = id;
        }
    
        if (attributes) {
          for (const key in attributes) {
            htmlElement[key] = attributes[key];
          }
        }
    
        if (parentNode) {
          parentNode.appendChild(htmlElement);
        }
    
        return htmlElement;
    }
}

attachEvents();