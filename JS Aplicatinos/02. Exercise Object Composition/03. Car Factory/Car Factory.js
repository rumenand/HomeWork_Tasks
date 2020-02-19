function solve (data){
    const engTypes = [{power: 90,volume: 1800},
                      {power: 120,volume: 2400},
                      {power: 200,volume: 3500}];
    function getWheels(x){
        let size = Math.floor(x);
        if (size%2 !== 0) size -= 1;
        return [size,size,size,size];
    }
    return Object.assign({},{
        model:data.model,
        engine: engTypes.filter(x=>x.power>=data.power)[0],
        carriage: {type: data.carriage,color: data.color},
        wheels: getWheels(Number(data.wheelsize))
    });
}

console.log(solve({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 }
));