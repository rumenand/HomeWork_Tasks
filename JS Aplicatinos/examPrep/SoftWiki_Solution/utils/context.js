export default function(context){
    context.name = localStorage.getItem('name');
    context.loggedIn = (!!localStorage.getItem('name'));     
        return context.loadPartials({
            header:"../views/common/header.hbs",
            footer:"../views/common/footer.hbs"
        })
}