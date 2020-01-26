function subtract() {
    const num1 = document.getElementById('firstNumber').value;
    const num2 = document.getElementById('secondNumber').value;
    const res = document.getElementById('result');
    res.innerHTML = Number(num1)-Number(num2);
}