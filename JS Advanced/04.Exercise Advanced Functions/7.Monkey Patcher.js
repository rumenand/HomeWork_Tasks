function solution(a){
  let com = {
      upvote : () => this.upvotes++,
      downvote : () => this.downvotes++,
      score: () => {
          let obfValue = getRepValue(this.upvotes,this.downvotes);
          return  [ this.upvotes+obfValue,
                    this.downvotes+obfValue,
                    this.upvotes - this.downvotes,
                    getRating(this.upvotes,this.downvotes) ]
                }
  }  
  function getRepValue(a,b){
      if (a+b >50) return Math.ceil(Math.max(a,b)*0.25);
      return 0;
}
    function getRating(a,b){
        if ((a+b)<10) return 'new';
        if (a/(a+b)>0.66) return 'hot';
        if ((a-b)>=0 && (a>100 || b>100)) return 'controversial';
        if ((a-b)<0) return 'unpopular';
        return 'new';
    }
  return com[a]();
}

let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};
solution.call(post, 'upvote');
solution.call(post, 'downvote');
console.log(solution.call(post, 'score')); 
