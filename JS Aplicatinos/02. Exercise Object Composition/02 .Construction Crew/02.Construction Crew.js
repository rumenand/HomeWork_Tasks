function solve(data){
    const calculateHydr = (x,y) => 0.1*x*y;
    if (data.dizziness === true){
        const newData = {
            levelOfHydrated: data.levelOfHydrated + calculateHydr(data.weight,data.experience),
            dizziness: false
        }
        Object.assign(data,newData);
    }
    return data;
}
console.log(solve({ weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true }
  ))