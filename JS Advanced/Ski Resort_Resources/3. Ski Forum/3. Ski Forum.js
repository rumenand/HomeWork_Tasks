class Forum {
    _users;
    _questions;
    _id;
    constructor(){
        this._users=[];
        this._questions = [];
        this._id=1;
    }
    register(username,password,repeatPassword,email){
        if (username ==='' || password ==='' || repeatPassword ==='' || email === ''){
            throw new Error('Input can not be empty');            
        }
        if (password !== repeatPassword){
            throw new Error('Passwords do not match'); 
        }
        const chUser = this._users.filter(x=>x.username===username);
        const chEmail = this._users.filter(x=>x.email === email);
        if (chEmail.length>0 || chUser.length>0){
            throw new Error('This user already exists!');
        }
        const newUser = {
            username,
            password,
            email,
            logged: false
        }
        this._users.push(newUser);
        return `${username} with ${email} was registered successfully!`;
    }
    login(username,password){
        const curUser = this._users.filter(x=>x.username===username);
        if (curUser.length===0 || curUser[0].password !== password){
            throw new Error('There is no such user');
        }
        curUser[0].logged = true;
        return "Hello! You have logged in successfully";  
    }
    logout(username,password){
        const curUser = this._users.filter(x=>x.username===username);
        if (curUser.length ===0 || curUser[0].password !== password){
            throw new Error('There is no such user');
        }
        if (curUser[0].logged === true){
        curUser[0].logged = false;
        return "You have logged out successfully"; 
        }
    }
    postQuestion(username, question){
        const curUser = this._users.filter(x=>x.username===username);
        if (curUser.length ===0 || !curUser[0].logged){
            throw new Error('You should be logged in to post questions');
        }
        if (question ===''){
            throw new Error('Invalid question');
        }
        const newQ = {
            id: this._id,
            username,
            question,
            answers: []
        }
        this._questions.push(newQ);
        this._id++;
        return "Your question has been posted successfully";
    }
    postAnswer(username, questionId, answer){
        const curUser = this._users.filter(x=>x.username===username);
        if (curUser.length ===0 || !curUser[0].logged){
            throw new Error('You should be logged in to post answers');
        }
        if (answer ===''){
            throw new Error('Invalid answer');            
        }
        const q = this._questions.filter(x=>x.id===questionId);
        if (q.length ===0){
            throw new Error('There is no such question');
        }
        const answ = {
            username,
            answer
        }
        q[0].answers.push(answ);
        return "Your answer has been posted successfully";
    }
    showQuestions(){
        let res ='';
        this._questions.map(x=>{
            res += `Question ${x.id} by ${x.username}: ${x.question}\n`;
            x.answers.map(y=>res += `---${y.username}: ${y.answer}\n`)
        })
        return res.trim();
    }
}


let forum = new Forum();

forum.register('Jonny', '12345', '12345', 'jonny@abv.bg');
forum.register('Peter', '123ab7', '123ab7', 'peter@gmail@.com');
forum.login('Jonny', '12345');
forum.login('Peter', '123ab7');

forum.postQuestion('Jonny', "Do I need glasses for skiing?");
forum.postAnswer('Peter',1, "Yes, I have rented one last year.");
forum.postAnswer('Jonny',1, "What was your budget");
forum.postAnswer('Peter',1, "$50");
forum.postAnswer('Jonny',1, "Thank you :)");

console.log(forum.showQuestions());


