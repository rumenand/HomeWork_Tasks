function createArticle() {
	const title = document.getElementById('createTitle');
	const content = document.getElementById('createContent');
	if (title.value && content.value){
	let newArticle = makeEl('article');
	newArticle.appendChild(makeEl('h3',title.value));
	newArticle.appendChild(makeEl('p',content.value));		
	document.getElementById('articles').appendChild(newArticle);
	title.value = '';
	content.value = '';
	}
	function makeEl(type,value){
		let result = document.createElement(type);
		if (value) result.innerHTML = value;
		return result;
	}
}