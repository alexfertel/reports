var myCar = new Object(); 

myCar.mark = "Ford"; 
myCar.model = "Mustang"; 
myCar.year = 1969;

myCar.color; //undefined

//otra via
//myCar["mark"] = "Ford"; 
//myCar["model"] = "Mustang"; 
//myCar["year"] = 1969;

//otra via
//var nameProperty = "mark"; 
//myCar[nameProperty] = "Ford"; // idem model
//var nameProperty1 = "model";
//myCar[nameProperty1] = "Mustang";
//var nameProperty2 = "year";
//myCar[nameProperty2] = 1969;


var myObject = new Object(), 
    myChain = "myChain", 
    myRandom = Math.random(), 
    obj = new Object(); 
myObject.type = "Syntax at point"; 
myObject["Date_ Creation"] = "Chain at spaces and accent"; 
myObject[myChain] = "String_ Value"; 
myObject[myRandom] = "Random number_"; 
myObject[obj] = "Object_"; 
myObject[""] = "Within empty chain";

console.log(myObject);

//listar propiedades
function lookProperties(obj, nameObj){
    var result = '';
    for(var i in obj){
        if(obj.hasOwnProperty(i)){
            result += '${nameObj}.${i} = ${obj[i]}\n';
        }
    }	
    return result;
}

console.log(lookProperties(myCar, "myCar"));
console.log(lookProperties(myObject, "myObject"));