class Ave(){
    vuela() {}
}

function func(ave){ 
     ave.vuela(); 
} 

//en ambos funciona
var paloma = new Ave(); 
func(paloma);

func({vuela: () => 1});