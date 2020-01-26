function toggle() {
    const btn = document.getElementsByClassName("button")[0];
    const hText = document.getElementById('extra');

    if (btn.textContent === 'More'){
        btn.textContent = 'Less';
        hText.style.display = 'block';
    }
    else {
        btn.textContent = 'More';
        hText.style.display = 'none';
    }
}