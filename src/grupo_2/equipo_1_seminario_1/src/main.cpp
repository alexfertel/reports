#include <iostream>
#include <cstdio>
#include <vector>
#include "../include/linked_list.h"
// #include "../include/node.h"

using namespace std;
typedef linked_list<int> ll_int;


//esto lo estoy usando para testear cosas durante la implementacion
struct A {
    int a;

    A(int v) : a(v) {
        std::cout << "contructor" << std::endl;
    }

    A(int &v) : a(v) {
        std::cout << "constructor 2" << std::endl;
    }

    A() : a(0) {
        std::cout << "default constructor" << std::endl;
    }

    A(A &a) : a(a.a) {
        std::cout << "copy constructor lvalue" << std::endl;
    }

    A(A &&a) : a(a.a) {
        std::cout << "copy constructor rvalue" << std::endl;
    }

    void operator=(A &&a) {
        this->a = a.a;
        std::cout << "operator= overload rvalue" << std::endl;
    }

    void operator=(A &a) {
        this->a = a.a;
        std::cout << "operator= overload lvalue" << std::endl;
    }

    ~A() {
        std::cout << "destructor" << std::endl;
    }
};



string Map(int a){
    return to_string(a) + "hola";
}




template<typename T>
class B{
    
    T x;
    public:
        B(T a){
            x = a + 0.1;
        }
        
        double get(){return x;}
        
        template<typename R>
        void Mapper(R (*ptr)(T)  ){
            R a = ptr(x);
            cout<<a<<endl;
        }
};


void f(int data){
    cout<<"Base case: "<<data<<endl;
}

template<typename first, typename... rest>
void f(int data, first value, rest... args){
    cout<<"Recursive calls: "<<value<<endl;
    f(data,args...);
}




struct Z{
    int a;
};

int a =10;

int ff(int b){
    int a=20;
    cout<<a<<endl;
    cout<<::a<<endl;
    return b;
}

int main() 	 	
{

  
    // node<int> a = node<int>(5);
    // std::cout << a.value << std::endl;
    /*ll_int l;
    std::cout << l.Length() << std::endl;
    l.add_last(0);
    l.at(0) = 6;
    ll_int l1(l);
    std::cout << l.Length() << std::endl;
    std::cout << l[0] << std::endl;*/
    
    vector<int> v ={1,2,3,4,5,6};
    linked_list<int> l(v);
    linked_list<string> l2 = l.map(Map);
    
    cout<<l2;
    
    //cin>>l;
    //cout<<l;
    /*int a =10;
    int & b = a;
    b = 20;
    cout<<a<<endl;*/


    //f(5,"Hola",true);

    
    //cout<<(a==b)<<endl;

    

    return 0;
}