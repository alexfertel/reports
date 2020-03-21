#include <cstring>
#include <iostream>
#include <string>
using namespace std;
/////////////////////////////////////////
//Constexpr

constexpr int product(int x, int y) {
	return (x * y);
}
int main(){
	const int x = product(10, 20);
	cout <<  x;
	return 0;
}


/////////////////////////////////////////////////

constexpr int six() { return 6;}
int arrayten[six() + 4];

///////////////////////////////////////////////

constexpr float exp(float x, int n){
	return n == 0 ? 1 : n % 2 == 0 ? exp(x * x, n/2) : exp(x * x, (n - 1) / 2) * x;
}
float doble(float x){
	return 2 * x;
}
int main(){
	float a = doble(1);
	constexpr float exp1 = exp(2, 10);
	constexpr float exp2 = exp(a, 10);
	cout << exp1 << endl;
	cout << exp2 << endl;
	return 0;
}

///////////////////////////////////////

int main(){
	float a = doble(1);
	constexpr float exp1 = exp(2, 10);
 	float exp2 = exp(a, 10);
	cout << exp1 << endl;
	cout << exp2 << endl;
	return 0;
}


//////////////////////////////////////
/////////Fibonacci usando constexpr


#include <iostream>
using namespace std;
constexpr long int fib(int n){
	return (n < = 1)? n : fib(n - 1) + fib(n - 2);
}
int main(){
	const long int result1 = fib(30);
	cout << result1 << endl;
	long int result2 = fib(30);
	cout << result2 << endl;
	return 0;
}


/////////////////////////////

#include <bits/stdc++.h>
using namespace std;
class Rectangle{
	int _h,_w;
public:
	constexpr Rectangle(int h, int w) : _h(h), _w(w) {}
	constexpr int getArea() const { return _h  * _w; }
};
int main(){
	constexpr Rectangle rectangle(10, 20);
	cout << rectangle.getArea();
	return 0;
}


/////////////////////////////////

class Point{
	double _x, _y;
public:
	constexpr Point(double x = 0, double y = 0) noexcept : _x(x), _y(y) {}
	constexpr double getX() const noexcept { return _x; }
	constexpr double getY() const noexcept { return _y; }
};
int main(){
	constexpr Point p(6,10);
	cout << p.getX();
	return 0;
}

///////////////////////////////////////////

constexpr Point intpoint(const Point& p1, const Point& p2) {
	return Point((p1.getX() + p2.getX())/2, (p1.getY() + p2.getY())/2);
};
int main(){
	constexpr Point p1(6,10);
	constexpr Point p2(12,20);
	constexpr Point p3 = intpoint(p1,p2);
	cout << "X: " << p3.getX() << endl;
	cout << "Y: "<< p3.getY() << endl;
	return 0;
}

/////////////////////////////////
//C==11 vs C==14

constexpr int my_charcmp( char c1, char c2 ) {
   	return (c1 == c2) ? 0 : (c1 < c2) ? : -1 : 1;
}
constexpr float exp(float x, int n){
	return n == 0 ? 1 : n % 2 == 0 ? exp(x * x, n/2) : exp(x * x, (n - 1) / 2) * x;
}

///////////////////////////////////////////

constexpr int my_strcmp( const char* str1, const char* str2 ) {
	int i = 0;
	for( ; str1[i] && str2[i] && str1[i] == str2[i]; ++i ){ }
	if( str1[i] == str2[i] ) return 0;
	if( str1[i] < str2[i] ) return -1;
	return 1;
}

///////////////////////////

class Point{
	double _x, _y;
public:
	constexpr Point(double x = 0, double y = 0) noexcept : _x(x), _y(y) {}
	constexpr double getX() const noexcept { return _x; }
	constexpr double getY() const noexcept { return _y; }
	constexpr void setX(double X) noexcept {x = X;}
	constexpr void setY(double Y) noexcept {y = Y;}
};


/////////////////////////////////
