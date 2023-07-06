function solve() {
  const text = document.querySelector('#text').value.split(' ');
  const namingConvention = document.querySelector('#naming-convention').value;
  const res = document.querySelector('#result');

  let out = [];
  if(namingConvention === 'Camel Case'){
    text.forEach((x, i) =>{
      x = x.toLowerCase();
      if(i !== 0){
        out.push(x.charAt(0).toUpperCase() + x.slice(1))
      } else{
        out.push(x.toLowerCase())
      }
    });
  } else if(namingConvention === 'Pascal Case'){
    text.forEach(x=>{
      x = x.toLowerCase();
      out.push(x.charAt(0).toUpperCase() + x.slice(1))
    });
  } else{
    out.push('Error!')
  }
  res.textContent = out.join('');
}