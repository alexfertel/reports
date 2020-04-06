class Car { 
     constructor(make , model) { 
         this.make = make; 
         this.model = model; 
         this._userGears = [’P’, ’N’, ’R’, ’D’]; 
         this._userGear = this._userGears[0]; } 
     get userGear() { return this._userGear; } 
     set userGear(value) { 
        if(this._userGears.indexOf(value) < 0)
	     throw new Error(‘Invalid gear: ${value}‘); 
        this._userGear = vaule; } 
     shift(gear) { this.userGear = gear; }
}

// class Car as defined previously , with shift method 
const car1 = new Car(); 
const car2 = new Car(); 
car1.shift === Car.prototype.shift; // true 
car1.shift(’D’); 
car1.shift(’d’); // error 
car1.userGear; // ’D’ 
car1.shift === car2.shift // true 
car1.shift = function(gear) { this.userGear = gear.toUpperCase(); } 
car1.shift === Car.prototype.shift; // false 
car1.shift === car2.shift; // false
car1.shift(’d’); 
car1.userGear; // ’D’
