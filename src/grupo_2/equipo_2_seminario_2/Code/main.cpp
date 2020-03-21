//
// Created by tensai on 17/02/20.
//

#include <vector>
#include <memory>
#include <iterator>
#include <iostream>
#include <algorithm>

using namespace std;


// Smart Pointers
//template<typename T>
//using uPTR = unique_ptr<T>;

template<typename T>
using sPTR = shared_ptr<T>;

template<typename T>
using wPTR = weak_ptr<T>;

template<typename R, typename T>
using sFunc = R(*)(T);

// multiples parametros
template<typename R, typename... T>
using mFunc = R(*)(T...);

template <typename T>
class Node{
public:
    T data;
    sPTR<Node<T>> next;
    wPTR<Node<T>> prev;

    Node(){};

    Node(T _data){
        data = _data;
    }
    Node(T _data, sPTR<Node<T>> _prev){
        data = _data;
        prev = _prev;
    }
    Node(T _data, sPTR<Node<T>> _prev, sPTR<Node<T>> _next){
        prev = _prev;
        next = _next;
        data = _data;
    }
};

template <typename T>
class DoubleLinkedList{
private:
    sPTR<Node<T>> first = nullptr;
    sPTR<Node<T>> last = nullptr;

    int length = 0;
public:
    // Default empty constructor
    DoubleLinkedList() { std::cout << "Default Constructor" << std::endl; }

    //One Argument constructor
    DoubleLinkedList(T value) {
        cout << "Constructor de un solo elemento" << endl;
        Add_Last(value);
    }

    // Copy Constructor
    DoubleLinkedList(const DoubleLinkedList& lst){
        cout << "Constructor por Copia: " << endl;
        auto current = lst.first;
        while (current != nullptr){
            Add_Last(current->data);
            current = current->next;
        }
    }

    // Movement Constructor
    DoubleLinkedList(DoubleLinkedList&& lst) noexcept {
        cout << "Constructor por Movimiento" << endl;
        *this = move(lst);
    }

//    Constructor from vector<T>
    DoubleLinkedList(vector<T> V){
        cout << "Constructor a partir de un Vector" << endl;
        for_each(V.begin(), V.end(), [this](T n) { Add_Last(n); });
    }

    //Constructor for List-initialization
     DoubleLinkedList(std::initializer_list<T> a){
        cout << "Constructor con List Initialization" << endl;
         for_each(a.begin(), a.end(), [this](T n) { Add_Last(n); });
     }

    //Override assign operators

    //Assign by copy
    DoubleLinkedList& operator=(DoubleLinkedList& A){
        cout << "Asignacion por copia: " << endl;

        if (this != &A){
            // Si no son el mismo objeto entonces
            first = nullptr;
            last = nullptr;
            length = 0;

            sPTR<Node<T>> temp = A.first;

            while( temp != nullptr) {
                Add_Last(temp->data);
                temp = temp -> next;
            }
        }

        return *this;
    }

    //Assign by movement
    DoubleLinkedList& operator=(DoubleLinkedList&& A) noexcept {
        cout << "Asignacion por movimiento: " << endl;

        if (this != &A){

            first = nullptr;
            last = nullptr;
            length = 0;

            swap(first, A.first);
            swap(last, A.last);
            swap(length, A.length);
        }

        return *this;
    }

    // Better indexer
    T operator[](int index){
        return At(index);
    }

    // Get_ Length
    int Length(){
        return length;
    }

    void Add_Last(T value) noexcept {
        // New node to inset
        auto new_node = make_shared<Node<T>>(value);
        if (length == 0){
            first = last = new_node;
        }else{
            last -> next = new_node;
            new_node -> prev = last;
            last = new_node;
        }
        length += 1;
    }

    void Remove_Last(){
        if (length > 1){
            last = last->prev.lock();
            last->next = nullptr;
        }else if (length == 1){
            first = nullptr;
            last = nullptr;
        }
        length -= 1;
    }

    T At(int index){
        if (index <= length){
            auto result = first;
            for (int i = 0; i < index; ++i){
                result = result->next;
            }
            return result->data;
        }else{
            throw("Invalid index");
        }
    }

    void Remove_At(int index){
        if (index == length - 1){
            Remove_Last();
        } else{
            if (index == 0){
                if (length == 1){
                    first = nullptr;
                    last = nullptr;
                }else{
                    first->next->prev.lock() = nullptr;
                    first = first->next;
                }
            }else{
                auto at = first;
                for (int i = 0; i < index; ++i){
                    at = at->next;
                }
                at->prev.lock()->next = at->next;
                at->next->prev = at->prev;
            }

            length -= 1;
        }
    }

    void print_list(){
        if (length == 0){
            cout << "Empty List Length: " << length << endl;
        }
        else{
            auto current = first;
            cout << "Current list: " << endl;
            for (int i = 0; i < length; i++){
                cout << current->data;
                cout << ", ";
                current = current->next;
            }
            cout << "END" << endl;
        }
    }

    template<typename R>
    DoubleLinkedList<R> Map(mFunc<R, T> f){
        DoubleLinkedList<R> a;

        auto current = first;
        while (current != nullptr){
            Add_Last(f(current->data));
            current = current->next;
        }

        return a;
    }

    // ??
    ~DoubleLinkedList(){
        first = nullptr;
        last = nullptr;
    }
};


int main() {
    // cout << "Hello World! :0" << endl;
    DoubleLinkedList<int> a;
    a.print_list();
    
    // Length()
    std::cout << "Current Length: " << a.Length() << std::endl;
    std::cout << "Adding nodes" << std::endl;

    // Add_Last()
    a.Add_Last(1);
    a.Add_Last(2);
    a.Add_Last(3);
    a.Add_Last(4);
    a.Add_Last(5);
    a.Add_Last(6);
    a.Add_Last(7); 

    a.Remove_Last();
    a.print_list();
    cout << "Removiendo los ultimos 2 elementos" << endl;
    a.Remove_Last();
    // std::cout << "Length: " << a.Length() << std::endl;

    // a.print_list();
    a.Remove_Last();
    a.print_list();
    std::cout << "Length: " << a.Length() << std::endl;

    //At()
    cout << "Testing At()" << endl;
    a.print_list();
    cout << "List At(0): ";
    cout << a.At(0) << endl;
    cout << "List At(1): ";
    cout << a.At(1) << endl;
    cout << "List At(2): ";
    cout << a.At(2) << endl;
    cout << "List At(3): ";
    cout << a.At(3) << endl;
    cout << "List At(4): ";
    cout << a.At(4) << endl;
    // cout << "Trying to index out of range at Length() + 1" << endl;
    // cout << a.At(7).data << endl;

    //Remove_At()
    cout << "Testing Remove_At(): " << endl;
    a.print_list();
    cout << "Removing At(2)" << endl;
    a.Remove_At(2);
    a.print_list();
    cout << "Removing At(3)" << endl;
    a.Remove_At(3);
    a.print_list();
    cout << "Current length: " << a.Length() << endl;
    // a.print_list();

    //Testing Constructor by Copy
    cout << "Probando el constructor por copia" << endl;
    DoubleLinkedList<int> b(a);
    b.print_list();

    DoubleLinkedList<int> b1 = a;
    b1.print_list();

    //Testing Constructor by Movement
    cout << "Probando el constructor por movimiento" << endl;
    DoubleLinkedList<int> b2 = {1, 2, 3};
    DoubleLinkedList<int> b3 = std::move(b2);

    cout << "Probando que se apropio del objeto" << endl;
    DoubleLinkedList<int> b4 = std::move(b3);

    // cout << "List a donde se movio" << endl;
    b4.print_list();
    b2.print_list();
    b3.print_list();
    // cout << "Lista de la cual se movio" << endl;
    // try {
    //     a.print_list();
    // }
    // catch (...) {
    //     cout << "Se capturo una excepcion: " << endl;
    // }

    // Vector Initializer
    vector<int> vec = {1, 2, 3, 4, 5, 6};

    // DoubleLinkedList<int> b5(vec);
    DoubleLinkedList<int> b5 = vec;
    b5.print_list();

    // List Initialization
    // DoubleLinkedList<int> b6 {1, 2, 3, 4, 5, 6};
    DoubleLinkedList<int> b6 = {1, 2, 3, 4, 5, 6};

    b6.print_list();

    // Single Argument constructor
    DoubleLinkedList<int> b7 = 7;

    b7.print_list();

    // Assign by Copy
    DoubleLinkedList<int> b8;

    b8 = b7;

    b8.print_list();
    // Assign by Movement
    DoubleLinkedList<int> b9;

    b9 = std::move(a);
    b9.print_list();
    a.print_list();

}