#include<bits/stdc++.h>

using namespace std;

template<int n> struct Fibbonacci{
	static const int value = Fibbonacci<n - 1>::value + Fibbonacci<n - 2>::value;
};
template<> struct Fibbonacci<0>{
	static const int value = 1;
};
template<> struct Fibbonacci<1>{
	static const int value = 1;
};
int main()
{
	cout << Fibbonacci<7>::value << endl; //imprime 21
	return 0;
}