function create(words) {
   const content = document.getElementById('content');   
   for (const word of words) {
      const newDiv = document.createElement('div');
      const newParagraph = document.createElement('p');
      newParagraph.textContent = word;
      newParagraph.style.display = 'none';
      newDiv.addEventListener('click', clickEventHandler);
      newDiv.appendChild(newParagraph);
      content.appendChild(newDiv);

      function clickEventHandler(e){
         const div = e.currentTarget;
         const p = div.children[0];
         p.style.display = 'block'
      }
   }
}