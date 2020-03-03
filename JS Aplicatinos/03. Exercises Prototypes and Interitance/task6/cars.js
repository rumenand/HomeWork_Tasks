function solve(data){
    const arr = {};
    const comMap = {
        create: function(args){
            arr[args[0]] = [];
            if (args[1] === 'inherit') arr[args[0]].inherit = args[2];
        },
        set: function(args){
            arr[args[0]].push({k:args[1],v:args[2]});
        },
        print: function(args){
                   const out = [];
                    let parObj = args[0];
                    while (parObj !== undefined){                        
                        arr[parObj].forEach(x=>{
                            if (x.k !== undefined) out.push(`${x.k}:${x.v}`)
                        })
                        parObj = arr[parObj].inherit;
                    }
                    console.log(out.join(', '));
        }
    }
    data.forEach(el => {
        const tokens = el.split(' ');
        comMap[tokens[0]](tokens.slice(1));
    });
}

solve(['create c1',
'create c2 inherit c1',
'set c1 color red',
'set c2 model new',
'print c1',
'print c2'])
