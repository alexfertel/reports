#include <cstring>
#include <iostream>
#include <string>
#include <bits/stdc++.h>
using namespace std;
/////////////////////////////////
//SFINAE


template<typename T, typename U>
T cast(U x){
	return static_cast<T>(x);
}


/////////////////////////////////////

template<typename T, typename U>
T cast(typename U :: other_type x){
	return static_cast<T>(x);
}
int main (){
	std :: cout << cast<int,float>(12.56) << "\n";
	return 0;
}

/////////////////////////////////////


template<typename T, typename U>
U cast(T x){
	return static_cast<U>(x);
}

////////////////////////////////////

void f(int i){
	std :: cout << "int" << "\n";
}
void f(char c){
	std :: cout << "char" << "\n";
}


////////////////////////////////////////
