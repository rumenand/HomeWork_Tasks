function addItem() {
    const list = document.getElementById('items');
    const text = document.getElementById('newItemText');

    let newItem = document.createElement('li');
    newItem.textContent = text.value;
    list.appendChild(newItem);
}