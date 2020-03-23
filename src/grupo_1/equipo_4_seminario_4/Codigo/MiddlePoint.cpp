#include<bits/stdc++.h>

using namespace std;

class Point{
public:
	double X, Y;
	constexpr Point(double x, double y) : X(x), Y(y) {}
};
constexpr Point MiddlePoint(Point p1, Point p2){
	return Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
}
int main()
{
	constexpr Point p1 = Point(2, 3);
	constexpr Point p2 = Point(1, 2);
	constexpr Point m = MiddlePoint(p1, p2);
	cout << "(" << m.X << ", " << m.Y << ")" << endl; //imprime (1.5, 2.5)
	return 0;
}