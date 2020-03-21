//
// Created by tensai on 19/02/20.
//

#include <memory>
#include <iostream>

using namespace std;

// Para explicar mejor el && (rvalue reference)

class F {
private:
    int size;
    int* data;
public:
    // Constructor por defecto
    F(int b) {
        cout << "Default Constructor: " << endl;
        data = new int[b];
        size = b;
    }
    // Constructor por Copia
    F(const F& b) {
        cout << "Copy Constructor: " << endl;
        data = new int[b.size];
        copy(b.data, b.data + b.size, data);
        size = b.size;
    }
    // Constructor por Movimiento
    // F(F&& b) {
    //     cout << "Move Semantics Constructor: " << endl;
    //     data = b.data;
    //     size = b.size;
    //     b.data = nullptr;
    //     b.size = 0;
    // }

    // Asignador por copia
    F& operator=(const F& b){
        cout << "Assign by Copy" << endl;
        if (this != &b){
            delete[] data;
            data = new int[b.size];
            copy(b.data, b.data + b.size, data);
            size = b.size;
        }

        return *this;
    }
    // Asignador por Movimiento
    // F& operator=(F&& b){
    //     cout << "Assign by Movement" << endl;
    //     if (this != &b){
    //         delete[] data;

    //         data = b.data;
    //         size = b.size;
    //         b.data = nullptr;
    //         b.size = 0;
    //     }

    //     return *this;
    // }

    // Destructor
    ~F(){
        delete[] data;
    }
};

F
create_F(int value)
{
    return F(value);
}

int main(){
    // Copy constructor
    // F a(1000); // Default
    // F b(a); // Copy
    // F c = a;

    // Copy Assignment
    // F a(10000);
    // F b(20000);
    // a = b;

    // Constructor example
    F a = create_F(20000);

    // Copy Example
    a = create_F(30000);

    // F c = create_F(2000); // Move
    // F d = F(1948);

    // c = a; // Assign by Copy
    // b = create_F(3849); // Assign by Movement
}



