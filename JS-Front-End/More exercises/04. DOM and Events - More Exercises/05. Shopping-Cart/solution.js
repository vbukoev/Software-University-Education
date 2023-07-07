function solve() {
   const addBtns = Array.from(document.querySelectorAll('.add-product'));
   const checkBtn = document.querySelector('.checkout');
   const cartTextArea = document.querySelector('textarea');
   let cart = [];
   let totalPrice = 0;

   function addCart(productName, price){
      cart.push({name: productName, price: price});
      totalPrice += price;
      cartTextArea.value += `Added ${productName} for ${price.toFixed(2)} to the cart.\n`;
   }

   function checkout(){
      let uniqueProducts = [...new Set(cart.map(p => p.name))];
      let list = uniqueProducts.join(', ');
      cartTextArea.value += `You bought ${list} for ${totalPrice.toFixed(2)}.\n`    
      
      addBtns.forEach(b=>{
         b.disabled = true;
      });
      checkBtn.disabled = true;
   }

   addBtns.forEach(b=>{
      b.addEventListener('click', e=>{
         let productDiv = e.target.parentElement.parentElement;
         let productName = productDiv.querySelector('.product-title').textContent;
         let price = parseFloat(productDiv.querySelector('.product-line-price').textContent)
         addCart(productName, price);
      });
   })

   checkBtn.addEventListener('click', checkout);
}