#include<bits/stdc++.h>

using namespace std;

struct PInt{
	typedef int PseudoInt;
};
template<typename T> int f(typename T::PseudoInt){
	return 1;
}
template<typename T> int f(T){
	return 2;
}
int main(){
	cout << f<PInt>(5) << endl; //imprime 1
	cout << f<int>(5) << endl;  //imprime 2
	return 0;
}