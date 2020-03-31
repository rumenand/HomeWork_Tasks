import {getUserData,fetchData,getCurUser,curUserTeam,getIndexOfTeam,applyCommon} from './helpers.js';

export async function homeViewHandler(){
    await applyCommon.call(this);
    if (!!sessionStorage.getItem('token')){
                fetchData('teams',sessionStorage.getItem('token')
                ,{method:"GET"},[(data)=>{
                   let arr = Object.keys(data)
                    .map(x=>{
                        return {
                            '_id':x,
                            'name':data[x].name,
                            'comment':data[x].comment,
                            'members':data[x].members,
                            'author':data[x].author
                        }}); 
                        const userTeam = curUserTeam(arr);
                        if (userTeam !== ''){
                            this.hasTeam = true;
                            this.teamId = userTeam._id;
                        }
                        sessionStorage.setItem('teams',JSON.stringify(arr)); 
                        this.partial('./templates/home/home.hbs');                       
                }]);   
            }
            else this.partial('./templates/home/home.hbs'); 
}
export async function aboutViewHandler(){
    await applyCommon.call(this);
    this.partial('./templates/about/about.hbs');
}
export async function catalogViewHandler(){
    await applyCommon.call(this);
    this.partials.team = await this.load('./templates/catalog/team.hbs');
    this.teams = JSON.parse(sessionStorage.getItem('teams'));
    this.hasNoTeam =(curUserTeam(this.teams) === '');                   
    this.partial('./templates/catalog/teamCatalog.hbs');
}
export async function createViewHandler(){
    await applyCommon.call(this);    
    this.partials.createForm = await this.load('./templates/create/createForm.hbs');
    await this.partial('./templates/create/createPage.hbs');
    const formCtn = document.querySelector('#create-form');
    formCtn.addEventListener('submit',(e)=>{
        e.preventDefault();
        const team = getUserData(formCtn,['name','comment']);
        team.author = getCurUser();
        team.members = getCurUser();
        fetchData('teams',sessionStorage.getItem('token'),{method: 'POST',
            body: JSON.stringify(team)},[(res)=>{
                team._id = res.name;
                const teams = JSON.parse(sessionStorage.getItem('teams'));
                teams.push(team);
                sessionStorage.setItem('teams',JSON.stringify(teams));
                this.redirect(`#/catalog/:${team._id}`);
            }]); 
    })
}
export async function teamViewHandler(){
    await applyCommon.call(this);
    this.partials.teamMember = await this.load('./templates/catalog/teamMember.hbs');
    this.partials.teamControls = await this.load('./templates/catalog/teamControls.hbs');
    const teams = JSON.parse(sessionStorage.getItem('teams'));
    const curTeam = teams.filter(x=>x._id === this.params.id.slice(1))[0];
    this.teamId = curTeam._id;
    this.name = curTeam.name;
    this.comment = curTeam.comment;
    this.members = curTeam.members.split(', ').map(x=>{
        return {'username':x};
    });
    this.isAuthor = (curTeam.author === getCurUser());
    this.isOnTeam = curTeam.members.split(', ').includes(getCurUser());
    await this.partial('./templates/catalog/details.hbs');
}
export function leaveHandler(){   
    const teams = JSON.parse(sessionStorage.getItem('teams'));
    const cTeamId = getIndexOfTeam(teams,this.params.id.slice(1));    
    if(confirm(`Do you want to leave team ${teams[cTeamId].name}`) === true){
        let membArr = teams[cTeamId].members.split(', ');       
        let found = membArr.indexOf(getCurUser());
        membArr.splice(found, 1).join(', ');
        teams[cTeamId].members = membArr.join(', ');
        fetchData(`teams/${teams[cTeamId]._id}`,sessionStorage.getItem('token'),
        {method: "PUT",body: JSON.stringify(teams[cTeamId])},
        [()=>{
            sessionStorage.setItem('teams',JSON.stringify(teams));
            this.redirect(`#/catalog/:${teams[cTeamId]._id}`);
        }]);
    }
    else this.redirect(`#/catalog/:${teams[cTeamId]._id}`);
}
export function joinHandler(){
    const teams = JSON.parse(sessionStorage.getItem('teams'));
    const userTeam = curUserTeam(teams);
    if (userTeam ===''){
    const cTeamId = getIndexOfTeam(teams,this.params.id.slice(1));
        if(confirm(`Do you want to join team ${teams[cTeamId].name}`) === true){
            let membArr = teams[cTeamId].members.split(', ');       
            membArr.push(getCurUser());
            teams[cTeamId].members = membArr.join(', ');
            fetchData(`teams/${teams[cTeamId]._id}`,sessionStorage.getItem('token'),
            {method: "PUT",body: JSON.stringify(teams[cTeamId])},
            [()=>{
                sessionStorage.setItem('teams',JSON.stringify(teams));
                this.redirect(`#/home/:${teams[cTeamId]._id}`);
            }]);
        }
        else this.redirect(`#/catalog/:${teams[cTeamId]._id}`); 
    }
    else{
        alert(`You cannot join this team because you are a memder of team: ${userTeam.name}`);
        this.redirect(`#/catalog/:${this.params.id.slice(1)}`);
    }
}
export async function editHandler(){
    await applyCommon.call(this);
    this.partials.editForm = await this.load('./templates/edit/editForm.hbs');
    await this.partial('./templates/edit/editPage.hbs'); 
    const formCtn = document.querySelector('#edit-form');
    formCtn.addEventListener('submit',(e)=>{
        e.preventDefault();
        const newTeam = getUserData(formCtn,['name','comment']);
        const teams = JSON.parse(sessionStorage.getItem('teams'));
        const cTeamId = getIndexOfTeam(teams,this.params.id.slice(1));
        if(confirm(`Do you want to edit team ${teams[cTeamId].name}`) === true){
            teams[cTeamId].name = newTeam.name;
            teams[cTeamId].comment = newTeam.comment;
            fetchData(`teams/${teams[cTeamId]._id}`,sessionStorage.getItem('token'),
            {method: "PUT",body: JSON.stringify(teams[cTeamId])},
            [()=>{
                sessionStorage.setItem('teams',JSON.stringify(teams));
                this.redirect(`#/catalog/:${teams[cTeamId]._id}`);
            }]);
        }
        else this.redirect(`#/catalog/:${teams[cTeamId]._id}`); 
    })}