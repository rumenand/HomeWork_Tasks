function createComputerHierarchy() {
   class Keyboard{
       constructor(manufacturer, responseTime){
           this.manufacturer = manufacturer;
           this.responseTime = responseTime;
       }
   }
   class Monitor{
       constructor(manufacturer,width,height){
           this.manufacturer = manufacturer;
           this.width = width;
           this.height = height;
       }
   }
   class Battery{
       constructor(manufacturer,expectedLife){
           this.manufacturer = manufacturer;
           this.expectedLife = expectedLife;
       }
   }
   class Computer{
       constructor(manufacturer,processorSpeed,ram,hardDiskSpace){
        if (new.target === Computer){
            throw new Error('Abstract class cannot be instantiated directly');
        }
        this.manufacturer = manufacturer;
        this.processorSpeed = processorSpeed;
        this.ram = ram;
        this.hardDiskSpace = hardDiskSpace;
       }
   }
   class Laptop extends Computer{
       _battery;
       constructor(manufacturer,processorSpeed,ram,hardDiskSpace,weight,color,battery){
           super(manufacturer,processorSpeed,ram,hardDiskSpace);
           this.weight = weight;
           this.color = color;
            this.battery = battery;
       }
       get battery(){ return this._battery; }
       set battery(value){
           if (value.constructor.name !== 'Battery') 
                throw new TypeError('Item is not a Battery');
            this._battery = value;
       }

   }
   class Desktop extends Computer{
       _keyboard;
       _monitor;
    constructor(manufacturer,processorSpeed,ram,hardDiskSpace,keyboard,monitor){
        super(manufacturer,processorSpeed,ram,hardDiskSpace);
        this.keyboard = keyboard;
        this.monitor = monitor;
    }
    get keyboard(){ return this._keyboard; }
       set keyboard(value){
           if (value.constructor.name !== 'Keyboard') 
                throw new TypeError('Item is not a Keyboard');
            this._keyboard = value;
       }   
   get monitor(){ return this._monitor; }
       set monitor(value){
           if (value.constructor.name !== 'Monitor') 
                throw new TypeError('Item is not a Monitor');
            this._monitor = value;
       }
    }

    return {
        Battery,
        Keyboard,
        Monitor,
        Computer,
        Laptop,
        Desktop
    }
}

module.exports = createComputerHierarchy;