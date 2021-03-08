#include <iostream>
#include <vector>
#include <memory>
#include <functional>
using namespace std;

class MyClass
{
private:
    /* data */
public:
    int val1;
    int val2;
    int val3=4;
    MyClass(int a,int b):val1(a),val2(b){};

    void UsingThis(int val3){

        auto func=[this,val3](int val1){
            cout<<val1<<endl;//parametro val1
            cout<<val2<<endl;//val2 de la clase 
            cout<<MyClass::val1<<endl;//val1 de la clase
            cout<<val3<<endl;//val3 es el parametro que se le pasa al metodo
            cout<<MyClass::val3<<endl;//val3 de la clase;
        };

        func(5);
        val1++;
        val2++;
        MyClass::val3++;
        cout<<"Segundo llamado"<<endl;
        func(5);
    }

    void UsingThisValue(int val3){

        auto func=[*this,val3](int val1){
            cout<<val1<<endl;//parametro val1
            cout<<val2<<endl;//val2 de la clase 
            cout<<MyClass::val1<<endl;//val1 de la clase
            cout<<val3<<endl;//val3 es el parametro que se le pasa al metodo
            cout<<MyClass::val3<<endl;//val3 de la clase;
        };

        func(5);
        val1++;
        val2++;
        MyClass::val3++;
        //en este caso el aumento de uno en los valores no cambia nada y los dos llamados
        //imprimen lo mismo,ya que se paso una copia de la clase
        cout<<"Segundo llamado"<<endl;
        func(5);
    }


    //Poner un ejemplo usando *this y mutable;
   
};




int main (){

//Ejemplo de Capture clausure
int val1=0 ,val2=1 ,val3=2;

auto fun=[&,val1](){ val2++;val3=val1+val2; return val3;};//val 1 es por valor ,val2 y val 3 por referencia
auto fun2=[&](){val1++;val2++;val3=val1+val2; return val3;};//todo por referencia

cout <<fun()<< endl;//imprime 2 val1=0, val2=2,val3=2
cout <<fun2()<< endl;//imprime 4 val1=1,val2=3 val3=4;

val1++;//val1=2
val2++;//val2=4
val3++;//val3=4
cout <<fun()<< endl;//imprime 5  val1=0,val2=5 val3=5 
cout <<fun2()<< endl;//imprime 9 val1=3 val2=6,val3=9

//Mutable

// int var1 = 0;

// auto func = [var1]() mutable
//     {var1++; return var1; // a1 por valor pero mutable};

// cout <<func(); cout <<func() << a1 << endl; // imprime 1 , 2 y 0

//Asignacion de expresion lambda a un function object
function<int(int, int)> f2 = [](int x, int y) { return x + y; };

//ejemplo de una expresion lambda dentro de otra 
int func4= [](int x) { return [](int y) { return y * 2; }(x) + 3; }(5);


 //ejercicio
    cout<<endl;
    cout<<"Ejercicio"<<endl;

   auto funcs = vector<function<int()>>();
   int x = 1;
   funcs.push_back([=] { return x; });
   x = 2;
   funcs.push_back([&] { return x; });
   x++;
   funcs.push_back([x = 4] { return x; });
   for (auto f : funcs)
    {
      int y = f();
      cout << y << endl;                                                       // 1, 3, 4
    }

    cout<<"Probando el this"<<endl;
    cout<<endl;

    MyClass a=MyClass(1,2);
    a.UsingThis(7);

    cout<<"Probando el this por valor"<<endl;
    cout<<endl;

    a.UsingThis(7);

return 0;
}