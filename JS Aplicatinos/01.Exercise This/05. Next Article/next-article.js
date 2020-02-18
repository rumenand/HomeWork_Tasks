function getArticleGenerator(articles) {
    const divTxt = document.querySelector('#content');
    return function (){        
        if (articles.length>0){
            const newArt = document.createElement('article');
            newArt.textContent = articles.shift();
            divTxt.appendChild(newArt);         
        }
    }
}
