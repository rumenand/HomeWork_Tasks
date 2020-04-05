export default {
    register(name,pass){
        return firebase.auth().createUserWithEmailAndPassword(name, pass)
        .then((res=>{
            localStorage.setItem('name',res.user.email);
            firebase.auth().currentUser.getIdToken().then(token=>{
            localStorage.setItem('token',token);
            })
        }));
    },
    login (name,pass){
        return firebase.auth().signInWithEmailAndPassword(name, pass)
                .then((res=>{
                    localStorage.setItem('name',res.user.email);
                    firebase.auth().currentUser.getIdToken().then(token=>{
                    localStorage.setItem('token',token);
                    })
                }));
    },
    logout(){
        return firebase.auth().signOut().then((res)=>{
            localStorage.removeItem('token');
            localStorage.removeItem('name');
        });
    }
};