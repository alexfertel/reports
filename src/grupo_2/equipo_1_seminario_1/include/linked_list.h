#ifndef LINKED_LIST_H
#define LINKED_LIST_H

#include "node.h"
#include <vector>

using namespace std;

template<typename T, typename R>
struct function{
    typedef R(*fun)(T);
};



template <typename T>
class linked_list
{
    private:
        node<T> *last;
        node<T> *first;
        int length;
        void delete_all();

    public:
        void add_last(T);
        const int &Length() { return this->length; };
        void remove_last();
        void remove_at(int i);
        T& at(int);
        T& operator[](int i){ return this->at(i); };
        linked_list();
        linked_list(const linked_list<T> * );
        ~linked_list();
        linked_list(std::vector<T>);
        linked_list<T> operator()(int start, int count);
        void operator=(linked_list<T>);
        template<typename X>
        friend ostream& operator<<(ostream& os, const linked_list<X>& l);
        template<typename X>
        friend istream& operator>> (istream& is, linked_list<X>& l);
        template<typename R>
        linked_list<R> map(R(*function)(T)){
        
            linked_list<R> * n = new linked_list<R>();
            
            node<T> * curr = this->first;
            for(int i=0;i<this->length;++i,curr=curr->next)
                n->add_last( function(curr->value) );

            return n;
        }           
        
};

template <typename T>
linked_list<T>::linked_list()
{
    node<T> *n = new node<T>;
    this->first = n;
    this->last = n;
    this->length = 0;
}

template <typename T>
linked_list<T>::linked_list(std::vector<T> v)
{
    node<T> *n = new node<T>;
    this->first = n;
    this->last = n;
    this->length = 0;

    typename std::vector<T>::iterator it;
    for(it = v.begin(); it != v.end(); it++){
        this->add_last(*it);
    }
}

template<typename T>
linked_list<T>::linked_list(const linked_list<T> * src)
{
    node<T> *n = new node<T>;
    this->first = n;
    this->last = n;
    this->length = 0;

    node<T> * curr = src->first;
    for(int i=0;i<src->length;++i){
        this->add_last(curr->value);
        curr = curr->next;
    }

}

template<typename T>
void linked_list<T>::delete_all()
{    
    node<T> *act = this->first;
    while(act != this->last)
    {
        node<T> *next = act->next;
        delete act;
        act = next;
    }

}

template <typename T>
linked_list<T>::~linked_list()
{
    this->delete_all();
}

template <typename T>
void linked_list<T>::add_last(T item)
{
    node<T> *n = new node<T>;
    n->prev = this->last;

    this->last->value = item;
    this->last->next = n;
    this->last = n;

    this->length++;

}

template <typename T>
void linked_list<T>::remove_last()
{
    node<T> *to_delete = this->last->prev;

    if(to_delete == this->first)
    {
        delete to_delete;
        this->first = this->last;
    }
    else
    {
        to_delete->prev->next = this->last;
        this->last->prev = to_delete->prev;
        delete to_delete;
    }
}

template <typename T>
void linked_list<T>::remove_at(int i)
{
    if(i >= length)
    {
        throw "tas inflando";
    }
    if(i == 0)
    {
        delete this->first;
        this->first = this->first->next;
    }
    else
    {
        node<T> *to_delete = this->at(i);

        to_delete->prev->next = to_delete->next;
        to_delete->next->prev = to_delete->prev;
        delete to_delete;
    }
}

template <typename T>
T& linked_list<T>::at(int i)
{
    if(i >= length)
    {
        throw "tas inflando";
    }
    node<T> *act = this->first;
    while(i > 0)
    {
        i--;
        act = act->next;
    }
    T &ret = act->value;
    return ret;
}

template<typename T>
void linked_list<T>::operator=(linked_list<T> y)
{
    delete_all();
    first = y.first;
    last = y.last;
    length = y.length;
} 


template <typename T>
linked_list<T> linked_list<T>::operator()(int start, int count)
{
    if((start + count) > this->length)
    {
        throw "tas inflando again";
    }

    linked_list<T> ret;

    node<T> *act = this->first;
    for(int i = 0; i < start; i++)
    {
        act = act->next;
    }
    while(count > 0)
    {
        ret.add_last(act->value);
        act = act->next;
        count--;
    }

    return ret;
}

template<typename X>
ostream& operator<<(ostream& os, const linked_list<X>& l)
{
    node<X> * n = l.first;
    for(int i=0;i<l.length;i++,n=n->next)
        os<<n->value<<" \n"[i==(l.length-1)];
    
    return os;
}
template<typename X>
istream& operator>> (istream& is, linked_list<X>& l){
    l.delete_all();
    
    node<X> *n = new node<X>;
    l.first = n;
    l.last = n;
    l.length = 0;
    
    int size;
    is>>size;
    X k;
    
    for(int i=0;i<size;i++){
        is>>k;
        l.add_last(k);
    }
    return is;
}

#endif //LINKED_LIST_H