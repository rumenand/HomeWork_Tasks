function addItem() {
    const dropMenu = document.getElementById('menu');
    const text = document.getElementById('newItemText').value;
    const val = document.getElementById('newItemValue').value;
    var opt = document.createElement('option');
    opt.value = val;
    opt.textContent = text;
    dropMenu.appendChild(opt);
}