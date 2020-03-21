#include <iostream>

using namespace std;

void foo1(int a){
    a = 100;
    cout << "Durantes : a = " << a << endl;
}

void foo2(int *arr){
    arr = new int [1];
    arr[0] = 100;
    cout << "Durantes : b[0] = " << arr[0] << endl;
}

void foo3(int *& arr){
    arr = new int [1];
    arr[0] = 100;
    cout << "Durantes : c[0] = " << arr[0] << endl;
}

int main() {
    int a = 1;
    cout << "Por valor :" << endl;
    cout << "Antes   : a = " << a << endl;
    foo1(a);
    cout << "Despues : a = " << a << endl << endl;

    int *b = new int [1];
    b[0] = 1;
    cout << "Por puntero :" << endl;
    cout << "Antes   : a[0] = " << b[0] << endl;
    foo2(b);
    cout << "Despues : a[0] = " << b[0] << endl << endl;

    int *c = new int [1];
    c[0] = 1;
    cout << "Por referencia :" << endl;
    cout << "Antes   : a[0] = " << c[0] << endl;
    foo3(c);
    cout << "Despues : a[0] = " << c[0] << endl;

    return 0;
}
