a = new Array(); 
f = (prototype) => { 
     prototype.functionality = () => { 
        console.log(’some fancy stuff’); 
     } 
};
f2 = function(prototype) { 
     prototype.functionality2 = function(){ 
        console.log(’some more cheesy stuff’); 
     }; 
};

f(a);
a.functionality(); 
f2(a); 
a.functionality2()