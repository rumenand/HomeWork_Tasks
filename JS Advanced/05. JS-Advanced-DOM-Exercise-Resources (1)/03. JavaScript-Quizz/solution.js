function solve() {
  let correctAnswerCount = 0;
  let correctAnswers = ['onclick','JSON.stringify()','A programming API for HTML and XML documents'];
  [...document.querySelectorAll('.answer-text')]
  .map(x=>x.addEventListener('click',handler)); 
  let sections = [...document.querySelectorAll('section')];
  
  function handler(e){
    let section = sections.shift();    
   if(correctAnswers.includes(e.target.innerHTML)) correctAnswerCount++;   
   section.style.display = "none";
   if (sections.length>=1) sections[0].style.display = "block";
   else{     
    document.querySelector("#results").style.display = "block";
     let resContainer =  document.querySelector("#results h1");
     (correctAnswerCount===3) 
     ? resContainer.innerHTML = "You are recognized as top JavaScript fan!"
     : resContainer.innerHTML = `You have ${correctAnswerCount} right answers`
   }
  }
}
