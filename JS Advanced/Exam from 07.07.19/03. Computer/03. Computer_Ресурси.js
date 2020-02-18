class Computer {
    ramMemory; 
    cpuGHz
    hddMemory;
    taskManager;
    installedPrograms;

    constructor(ramMemory, cpuGHz, hddMemory){
        this.ramMemory = ramMemory;
        this.cpuGHz = cpuGHz;
        this.hddMemory = hddMemory;
        this.taskManager = [];
        this.installedPrograms = [];
    }
    installAProgram(name, requiredSpace){
        if (this.hddMemory<requiredSpace){
            throw new Error('There is not enough space on the hard drive');
        }
        const newPr = {
            name,
            requiredSpace
        }
        this.hddMemory -= requiredSpace;
        this.installedPrograms.push(newPr);
        return newPr;
    }
    uninstallAProgram(name){
        const indexPr = this.installedPrograms.findIndex(x=>x.name===name);
        if (indexPr === -1){
            throw new Error('Control panel is not responding');
        }
        this.hddMemory += this.installedPrograms[indexPr].requiredSpace;
        this.installedPrograms.splice(indexPr,1);
        return this.installedPrograms;
    }
    openAProgram(name){
        const indexPr = this.installedPrograms.findIndex(x=>x.name===name);
        if (indexPr === -1){
            throw new Error(`The ${name} is not recognized`);
        }
        if(this.taskManager.filter(x=>x.name===name).length>0){
            throw new Error(`The ${name} is already open`);
        }
        const ramUsage  = (this.installedPrograms[indexPr].requiredSpace/this.ramMemory)*1.5;
        const cpuUsage  = (this.installedPrograms[indexPr].requiredSpace/this.cpuGHz)/500*1.5;
        const totalRam = this.taskManager.reduce((a,b)=> {
            a += b.ramUsage;
            return a;
        },0);
        const totalCPU = this.taskManager.reduce((a,b)=>{
            a += b.cpuUsage;
            return a;
        },0);
        if ((totalRam + ramUsage) >= 100){
            throw new Error(`${name} caused out of memory exception`);
        }
        if((totalCPU+cpuUsage) >= 100){
            throw new Error(`${name} caused out of cpu exception`);
        }
        const newPr = {
            name,
            ramUsage,
            cpuUsage
        }
        this.taskManager.push(newPr);
        return newPr;
    }
    taskManagerView(){
        if (this.taskManager.length === 0){
            return 'All running smooth so far';
        }
        return this.taskManager.reduce((a,b) =>{
            a += `Name - ${b.name} | Usage - CPU: ${b.cpuUsage.toFixed(0)}%, RAM: ${b.ramUsage.toFixed(0)}%\n`;
            return a;
        },'').trim();
    }
}

let computer = new Computer(4096, 9, 250000);

computer.installAProgram('Word', 7300);
computer.installAProgram('Excel', 10240);
computer.installAProgram('PowerPoint', 230000);
computer.installAProgram('Solitare', 1500);
computer.uninstallAProgram('Word');
computer.uninstallAProgram('Excel');

computer.openAProgram('Excel');

console.log(computer.taskManagerView());


