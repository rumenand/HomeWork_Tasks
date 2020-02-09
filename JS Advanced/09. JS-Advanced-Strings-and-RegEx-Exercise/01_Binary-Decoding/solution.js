function solve() {
	let input = document.querySelector('input').value,
		sum = input;

	while (sum > 9) {
		sum = sum.toString()
			.split('')
			.map(x => +x)
			.reduce((a, b) => a + b);
	}
	input = input.slice(sum, input.length - sum)
		.split(/(.{1,8})/g).filter(part => part !== '');

	let output = input.map(x => String.fromCharCode(parseInt(x, 2)));
	output = output.filter(x => /[A-Za-z\s]/.test(x)).join('');

	document.querySelector('#resultOutput').textContent = output;
}