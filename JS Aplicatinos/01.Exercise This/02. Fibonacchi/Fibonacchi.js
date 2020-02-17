function getFibonator(){
    let index =0;
    let fib = [1,1];
    return function (){
      if (fib[index] === undefined) fib[index] = fib[index-2]+fib[index-1];
      index++;
      return fib[index-1];
    }
}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
