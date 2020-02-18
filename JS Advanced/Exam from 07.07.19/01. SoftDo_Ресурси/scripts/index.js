
function mySolution(){
    document.querySelector('#inputSection > div > button').addEventListener('click',addPending)
    function addPending(){
        const pendigQ = document.querySelector('#pendingQuestions');
        const text = document.querySelector('#inputSection > textarea').value;
        let name = document.querySelector('#inputSection > div > input[type=username]').value;
        if (name ==='') name = 'Anonymous';
        const newPQ = document.createElement('div');
        newPQ.className = "pendingQuestion";

        const img = document.createElement('img');
        img.src = './images/user.png';
        img.width = '32';
        img.height = '32';
        newPQ.appendChild(img);

        const spName = document.createElement('span');
        spName.textContent = name;
        newPQ.appendChild(spName);

        const pQuest = document.createElement('p');
        pQuest.textContent = text;
        newPQ.appendChild(pQuest);

        const divBtn = document.createElement('div');
        divBtn.className = 'actions';
        const arcBtn = document.createElement('button');
        arcBtn.className = 'archive'
        arcBtn.textContent = 'Archive';
        arcBtn.addEventListener('click',archive);
        divBtn.appendChild(arcBtn);

        const openBtn = document.createElement('button');
        openBtn.className = 'open';
        openBtn.textContent = 'Open';
        openBtn.addEventListener('click',open);
        divBtn.appendChild(openBtn);

        newPQ.appendChild(divBtn);

        pendigQ.appendChild(newPQ);

        function archive(){
            newPQ.remove();
        }
        function open(){
            newPQ.remove();
            addToOpenQuestions(newPQ);
        }
    }

    function addToOpenQuestions(x){
        const opQuContr = document.querySelector('#openQuestions');
        [...x.querySelectorAll('button')].map(x=>x.remove());
        x.className = "openQuestion";

        const replyBtn = document.createElement('button');
        replyBtn.className = 'reply';
        replyBtn.textContent = 'Reply';
        replyBtn.addEventListener('click',replyQuest);
        x.querySelector('.actions').appendChild(replyBtn);

        const rplSection = document.createElement('div');
        rplSection.className = 'replySection';
        rplSection.style.display = 'none';

        const inpText = document.createElement('input');
        inpText.className = 'replyInput';
        inpText.type = 'text';
        inpText.placeholder = 'Reply to this question here...';
        rplSection.appendChild(inpText);

        const inpTextRplBtn = document.createElement('button');
        inpTextRplBtn.className = 'replyButton';
        inpTextRplBtn.textContent = 'Send';
        inpTextRplBtn.addEventListener('click',sendQ);
        rplSection.appendChild(inpTextRplBtn);

        const olList = document.createElement('ol');
        olList.className = 'reply';
        olList.type = '1';
        rplSection.appendChild(olList);

        x.appendChild(rplSection);
        opQuContr.appendChild(x);

        function replyQuest(){
            if (replyBtn.textContent === 'Reply'){
            rplSection.style.display = 'block';
            replyBtn.textContent = 'Back';
            }
            else{
                rplSection.style.display = 'none';
                replyBtn.textContent = 'Reply';
            }
        }
        function sendQ(){
            if (inpText.value !== ''){
                const li = document.createElement('li');
                li.textContent = inpText.value;
                olList.appendChild(li);
            }
        }
    }
}