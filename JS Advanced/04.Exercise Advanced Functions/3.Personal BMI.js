function solve(name,age,weight,height){
    let calcBMI = (a,b) => Math.round((a/(b/100)**2));
    let getStatus = (a) =>{
        switch (true)
        {
            case a<18.5: return 'underweight';
            case a<25: return 'normal';
            case a<30: return 'overweight';
            default: return 'obese';       
        }
    }
let result = {name,
            personalInfo: { age,
                            weight,
                            height},
            BMI: calcBMI(weight,height)                     
            };
result.status = getStatus(result.BMI);
if (result.status === 'obese') result.recommendation = 'admission required';
return result;
}
console.log(solve('Peter', 29, 75, 182));