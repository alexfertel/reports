#ifndef NODE_H
#define NODE_H

template <typename T>
struct node
{
    T value;
    node<T> *next;
    node<T> *prev;
    node();
    node(T);
    node(T&);
    void operator=(T);
};

template <typename T>
node<T>::node()
{
}

template <typename T>
node<T>::node(T t)
{
    this->value = t;
}

template <typename T>
node<T>::node(T& t)
{
    this->value = t;
}

template <typename T>
void node<T>::operator=(T t)
{
    this->value = t;
}

#endif //NODE_H