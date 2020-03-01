function solve(){
    class Post{
        title;
        content;
        constructor(title, content){
            this.title = title;
            this.content = content;
        }
        toString(){
            return `Post: ${this.title}\nContent: ${this.content}\n`
        }
    }
    class SocialMediaPost extends Post{        
        constructor(title, content,likes,dislikes){
            super(title,content);
            this._comments = [];
            this._likes = likes;
            this._dislikes = dislikes;
        }
        addComment(comment){
            this._comments.push(comment);
        }
        toString(){ 
            let str = super.toString();
            str += `Rating: ${this._likes - this._dislikes}`; 
            str += (this._comments.length>0) 
            ?this._comments.reduce((a,b)=>{
                a += `\n * ${b}`;
                return a; 
            },'\nComments:')
            :'';
            return str;    
        }
    }
    class BlogPost extends Post {
        constructor(title, content,views){
            super(title,content);
            this._views = views;
        }
        view(){
            this._views++;
            return this;
        }
        toString(){
            return super.toString()+
            `Views: ${this._views}`
        }
    } 
    return{
        Post,SocialMediaPost,BlogPost
    }   
}
let p = solve();
let post = new p.Post("Post", "Content");

console.log(post.toString());

let scm = new p.SocialMediaPost("TestTitle", "TestContent", 25, 30);

scm.addComment("Good post");
scm.addComment("Very good post");
scm.addComment("Wow!");

console.log(scm.toString());

