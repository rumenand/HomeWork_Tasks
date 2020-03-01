comp = require('./6.Computer.js')();

function createMixins() {
    function computerQualityMixin(clToExt){
        clToExt.prototype.getQuality = function(){
            return (Number(this.processorSpeed)
                 +Number(this.ram)
                 +Number(this.hardDiskSpace))/3;
        }
        clToExt.prototype.isFast = function(){
            return (Number(this.processorSpeed)>(Number(this.ram)/4));
                
        }
        clToExt.prototype.isRoomy = function(){
            return (Number(this.hardDiskSpace)>
            Math.floor(Number(this.ram)*Number(this.processorSpeed)));
        }
    }
    function styleMixin(clToExt){
        clToExt.prototype.isFullSet = function (){
            return (this.manufacturer === this.keyboard.manufacturer && 
                this.manufacturer === this.monitor.manufacturer);
        }
        clToExt.prototype.isClassy = function (){
            return (this.battery.expectedLife >= 3 
                && (this.color === 'Black' || this.color ==='Silver')
                && this.weight <3);
        }
    }
    return {
        computerQualityMixin,
        styleMixin
    }
}

let mixins = createMixins();
let computerQualityMixin = mixins.computerQualityMixin;
let styleMixin = mixins.styleMixin;
let keyboard = new comp.Keyboard('Logitech',70);
let monitor = new comp.Monitor('Logitech',28,18);
let desktop = new comp.Desktop("Logitech",3.3,8,1,keyboard,monitor);

computerQualityMixin(comp.Desktop);
styleMixin(comp.Desktop);
styleMixin(comp.Laptop);
console.log(desktop.getQuality());
console.log(desktop.isRoomy());
console.log(desktop.isFullSet());
let battery = new comp.Battery('Energy',3);
let laptop = new comp.Laptop("Hewlett Packard",2.4,4,0.5,2.99,"Silver",battery);
let laptop2 = new comp.Laptop("Hewlett Packard",2.4,4,12,3.12,"Silver",battery);

console.log(laptop.isClassy())