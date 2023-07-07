function search() {
   const towns = Array.from(document.querySelectorAll('li'));
   const res = document.querySelector('#result');
   const text = document.querySelector('#searchText').value;
   
   let matches = 0;
   towns.forEach(t => {
      if(t.textContent.includes(text)){
         matches++;
         t.style.fontWeight = 'bold';
         t.style.textDecoration = 'underline';
      }
   });
   res.textContent = `${matches} matches found`;
}
