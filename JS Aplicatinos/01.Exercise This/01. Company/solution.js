class Company{
   constructor(){
      this.departments = [];
   }
   addEmployee(username, salary, position, department){
      if (Array.from(arguments).some(x=>x===undefined || x==='' || x=== null)){
         throw new Error("Invalid input!");
      }
      if (salary <0){
         throw new Error("Invalid input!");
      }
      const newEmp ={
         username,
         salary,
         position
      }
      const chDep = this.departments.filter(x=>x.name === department)[0];
      if (chDep === undefined) {
         const newDep = [];
         newDep.name = department;
         this.departments.push(newDep);
      }
      const existDep = this.departments.filter(x=>x.name === department)[0];
      existDep.push(newEmp);
      return `New employee is hired. Name: ${username}. Position: ${position}`;
   }   
   bestDepartment(){
      let res = ''
      const bestDep = this.departments.sort((a,b) =>  this.avSalary(b) - this.avSalary(a))[0];
      res +=`Best Department is: ${bestDep.name}\n`;
      res +=`Average salary: ${this.avSalary(bestDep).toFixed(2)}\n`;

      const sortEmp = bestDep.sort((a,b) => {
         let r = b.salary - a.salary;
         if (r === 0) r = a.username.localeCompare(b.username);
         return r;
      })
      sortEmp.map(x=>res +=`${x.username} ${x.salary} ${x.position}\n`);

      return res.trim();      
   } 
   avSalary(x){
      return x.reduce((a,b) => {
         a += b.salary;
         return a;
      },0)/x.length;
   } 
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
