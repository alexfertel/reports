#include <iostream>
#include <vector>
#include <cstdlib>

using namespace std;


template <class R, class T>
class Function{
public:
    typedef R(*Mapper)(T);
};


template <class T>
class Node{
public:
    T value;
    Node<T> *next, *previous;
    explicit Node(T item): value(item), next(NULL), previous(NULL){}
    Node<T>& operator =(T item) { value = item; return *this; }
};

template <class T>
class LinkedList {
private:
    int length;

    Node<T> *first, *last;

    Node<T> *GetNode(int i) {
        Node<T> *node = first;
        for (int j = 0; j < i; ++j)
            node = node->next;
        return node;
    }
public:
    LinkedList(): length(0), first(NULL), last(NULL) {};

    explicit LinkedList(vector<T> &v) {
        length = 0;
        typename vector<T>::iterator it;
        for (it = v.begin(); it < v.end(); it++)
            AddLast(*it);
    }

    LinkedList(const LinkedList<T> &other){
        length = 0;
        Node<T> *node = other.first;
        for (int i = 0; i < other.length; i++, node = node->next)
            AddLast(node->value);
    }

    int Length() {
        return  length;
    }

    T& At(int i) {
        return GetNode(i)->value;
    }

    void AddLast(T item) {
        Node<T> *node = new Node<T>(item);

        if (length == 0)
            last = first = node;
        else {
            node->previous = last;
            last->next = node;
            last = node;
        }

        length++;
    }

    void RemoveLast() {
        if (length == 0)
            return;
        else if (first == last) {
            delete first;
            first = last = NULL;
        } else {
            Node<T> *node = last->previous;
            delete last;
            last = node;
        }

        length--;
    }

    void RemoveAt(int i) {
        Node<T> *node = GetNode(i);

        if (node == last) {
            Node<T> *prev = last->previous;
            delete last;
            if (length > 1)
                last = prev;
        } else if (node == first) {
            Node<T> *next = first->next;
            delete first;
            if (length > 1)
                first = next;
        } else {
            Node<T> *prev = node->previous;
            Node<T> *next = node->next;
            prev->next = next;
            next->previous = prev;
            delete node;
        }

        length--;
    }

    T& operator[](int i) {
        return At(i);
    }

    LinkedList<T> *operator()(int start, int count){
        LinkedList<T> *linkedList = new LinkedList<T>();
        Node<T> *node = GetNode(start);
        for (int i = 0; i < count; ++i, node = node->next)
            linkedList->AddLast(node->value);
        return linkedList;
    }

    friend ostream& operator<<(ostream& out, LinkedList<T>& linkedList) {
        Node<T>* node = linkedList.first;
        cout << "[";
        for (int i = 0; i < linkedList.Length() - 1; i++) {
            out << node->value << ", ";
            node = node->next;
        }
        cout << linkedList.last->value << "]";
        return out;
    }

    friend istream& operator>>(istream& in, LinkedList<T>& linkedList) {
        T val;
        in >> val;
        linkedList.Add_Last(val);
        return in;
    }

    template <class R>
    static LinkedList<R> *Map(LinkedList<T> &tlist, typename Function<R, T>::Mapper mapper){
        LinkedList<R> *rlist = new LinkedList<R>();
        Node<T> *node = tlist.first;
        for (int i = 0; i < tlist.Length(); ++i, node = node->next)
            rlist->AddLast(mapper(node->value));
        return rlist;
    }
};

void reference_example() {
    Node<int> node(5); // Por Valor
    Node<int> &refNode = node; // Por Referencia
    Node<int> *ptrNode = &node; //Por Puntero
    Node<int> otherNode = refNode;

    node = 8;
    refNode = 10;
    ptrNode->value = 12;

    cout << "node.value      : " << node.value << endl;
    cout << "refNode.value   : " << refNode.value << endl;
    cout << "ptrNode->value  : " << ptrNode->value << endl;
    cout << "otherNode.value : " << otherNode.value << endl;
}

int rounded(double d) {
    return (int)d;
}

void linkedlist_example() {
    LinkedList<double> doubles;
    doubles.AddLast(1.1);
    doubles.AddLast(2.1);
    doubles.AddLast(3.1);
    doubles.AddLast(4.1);
    doubles.AddLast(5.1);

    cout << doubles << endl;

    LinkedList<int> ints = *doubles.Map<int>(doubles, rounded);

    cout << ints << endl;

    LinkedList<int> *subints = ints(1, 3);

    cout << *subints << endl;
}

int main() {
    linkedlist_example();
    reference_example();
    return 0;
}
