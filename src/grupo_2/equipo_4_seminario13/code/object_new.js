//funcion constructora

function Car(mark, model, year){
   this.mark = mark; 
   this.model = model; 
   this.year = year;
}

var myCar = new Car("Eagle", "Talon TSi", 1993);

//inicializador de objeto
var obj = {prop_1 : value_1 , // prop_# can by one id 
	   2 : value_2 , // or a number} 
           // ... 
          "property n": value_n // or a chain };

var myMotorcycle = {color : "red", ring : 4, prop: {cylinder : 4, 
		    size: 2.2}};


//Object.create
//Propiedades y metodo de encapsulacion para Animal 
var Animal = {tipo : ’Invertebrados’, //valor por defecto de la propiedad 
	      mostrarTipo: function(){ 
                  //mostrara el tipo de animal 
                  console.log(this.tipo); } }; 

//Crear un nuevo objeto de tipo Animal llamado animal1 
var animal1 = Object.create(Animal); 
animal1.mostrarTipo(); 
//Output : Invertebrados

var pez = Object.create(Animal); 
pez.tipo = ’Pescados’; 
pez.mostrarTipo(); 
//Output: Pescados

//Variables privadas
const Car1 = (function() { 
    const carProps = new WeakMap(); 
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
     return Car; })();