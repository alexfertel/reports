#include <iostream>
#include<memory>
#include <vector>

using namespace std;

template<typename T>
class Node
    {
    public:
        T value;
        using sp=shared_ptr<Node<T>>;
        sp previous;
        sp next;

        Node(const T &_value):value{_value},previous{nullptr},next{nullptr}{}

		//Copy constructor
		Node(const Node &nodeToCopy) : value{nodeToCopy.value},
				previous{nodeToCopy.previous}, next{nodeToCopy.next} { }

		//Move constructor
		Node(Node &&nodeToBeMoved) : value{nodeToBeMoved.value},
				previous{nodeToBeMoved.previous}, next{nodeToBeMoved.next} {
				nodeToBeMoved.previous = nullptr;
				nodeToBeMoved.next = nullptr;
		}

		~Node() = default;

    };



template<typename T>
class Linked_List
{

    private:
        using shrpt=shared_ptr<Node<T>>;
        shrpt first;
        shrpt last;
        long cant;

    public:
        Linked_List():cant(0),first(nullptr),last(nullptr){}


        Linked_List(const Linked_List<T> &ListToCopy):cant{0},first{nullptr},last{nullptr}
        {
            shrpt current=ListToCopy.first;

            while(current!=nullptr)
            {
                Add_Last(current->value);
                current=current->next;

            }
        }

        Linked_List(Linked_List<T> &&listToBeMoved) :cant{0}, first{nullptr}, last{nullptr}
        {
			swap(first, listToBeMoved.first);
			swap(last, listToBeMoved.last);
			swap(cant, listToBeMoved.cant);
		}

		//Constructor by List
		Linked_List(initializer_list<T> list) :cant{0}, first{nullptr}, last{nullptr}
		{
			for (const auto &element : list)
				Add_Last(element);
		}

		//Constructor by vector
		Linked_List(const vector<T> &list) :cant{0}, first{nullptr}, last{nullptr}
		{
			for_each(list.begin(), list.end(),
				[this](T value) {
					Add_Last(value);
				}
			);
		}

		//Operators
		//Assignment by Movement
		Linked_List<T>& operator = (Linked_List<int> &&other)
		 {
			cant = 0;
			first = last = nullptr;
			swap(first, other.first);
			swap(last, other.last);
			swap(cant, other.cant);

			return *this;
		}

		//Destructor
		~Linked_List() = default;

		//Assignment by Copy
		Linked_List<T>& operator = (const Linked_List<int> &other)
{
			last = first = nullptr;
			cant = 0;

			shrpt current = other.first;

			while (current != nullptr) {
				Add_Last(current->value);
				current = current->next;
			}

			return *this;
		}
		size_t Length() { return cant; }

		private:
		bool _InRange(size_t index){ return index >= 0 && index < cant; }

		shrpt _NodeAt(int index)
        {
			shrpt current = first;

			for (int i = 0; i < index; i++)
				current = current->next;
			return current;
		}

        void Add_Last(T toAdd)
        {
            shrpt n(new Node<T>(toAdd));

            if(cant==0)
            {
               first=last=n;
            }
            else
            {
                n->previous=last;
                last->next=n;
                last=n;
            }
            cant++;

        }

        void Remove_Last()
		{
			auto temp = last->previous;
			last->previous = nullptr;
			last = temp;
			last->next = nullptr;
			cant--;
		}

		T At(size_t index)
		{
			if(_InRange(index))
			{
				shrpt current = first;
				for (size_t i = 0; i < index; i++)
					current = current->next;
				return current->value;
			}
			else
				throw out_of_range("IndexOutOfRangeException");
		}

        void Remove_At(size_t index)
		{

			if(_InRange(index))
			{
				if(index == cant - 1) {
					Remove_Last();
					return;
				}

				shrpt current = _NodeAt(index);

				if(index == 0)
				{
					shrpt temp = first->next;
					first->next = nullptr;
					temp->previous = nullptr;
					last = temp;
				}
				else
				{
					current->previous->next = current->next;
					current->next->previous = current->previous;
				}
				cant--;
			}
			else
				throw out_of_range("IndexOutOfRangeException");
		}



};

template<typename R, typename... T>
using Function = R(*)(T...);

template<typename R, typename T>
Linked_List<R> Map(Function<R, T> trans, Linked_List<T> &lista) {
	Linked_List<R> new_list;
	for (size_t k = 0; k < lista.Length(); ++k) {
		new_list.Add_Last(trans(lista.At(k)));
	}
	return new_list;
}

int main()
{

    return 0;
}



