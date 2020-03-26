#include<bits/stdc++.h>

using namespace std;

class Point{
public:
	double X, Y;
	constexpr Point(double x, double y) : X(x), Y(y) {}
};
int main()
{
	constexpr Point p = Point(2, 3);
	return 0;
}