class Vehicle { 
     constructor() { 
         this.passengers = []; 
         console.log("Vehicle created"); } 
     addPassenger(p) { this.passengers.push(p); } 
} 
class Car extends Vehicle { 
      constructor() { 
          super(); 
          console.log("Car created"); } 
      deployAirbags() { console.log("BWOOSH!"); } 
}

const v = new Vehicle(); 
v.addPassenger("Frank"); 
v.addPassenger("Judy"); 
v.passengers; // ["Frank", "Judy"] 
const c = new Car(); 
c.addPassenger("Alice"); 
c.addPassenger("Cameron"); 
c.passengers; // ["Alice", "Cameron"] 
v.deployAirbags(); // error 
c.deployAirbags(); // "BWOOSH!"

var o = { 
       a : 2, 
       m : function(b){ 
          return this.a + 1; 
       } 
}; 

console.log(o.m()); // 3 
// cuando en este caso se llama a o.m, <this > se refiere a o

var p = Object.create(o); 
//p es un objeto que hereda de o

p.a = 12; //crea una propiedad <a> en <p> 
console.log(p.m()) // 13 
//Cuando se llama a p.m(), <this > se refiere a p, 
//De esta manera , cuando p hereda la funci\’on <m> de <o>, 
//<this.a> significa <p.a>