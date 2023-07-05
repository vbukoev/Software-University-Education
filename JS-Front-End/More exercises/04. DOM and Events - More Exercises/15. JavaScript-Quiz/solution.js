function solve() {
  let correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];
  let rightAnswers = 0;
  let i = 0;

  Array.from(document.querySelectorAll('.answer-text')).map((x) => x.addEventListener('click', e=>{

    if(correctAnswers.includes(e.target.textContent)){
      rightAnswers++;
    }

    let currentSection = document.querySelectorAll('section')[i];
    currentSection.style.display = 'none';

    if(document.querySelectorAll('section')[i + 1] !== undefined){
      let next = document.querySelectorAll('section')[i + 1];
      next.style.display = 'block';
      i++;
    } else{
      document.querySelector('#results').style.display = 'block';
      if(rightAnswers === 3){
        document.querySelector('#results h1').textContent = "You are recognized as top JavaScript fan!"       
      } else{
        document.querySelector('#results h1').textContent = `You have ${rightAnswers} right answers`
      }
    }
  }))
}
