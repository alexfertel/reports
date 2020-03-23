#include<bits/stdc++.h>

using namespace std;

template<int a, int b> struct Add{
	enum { result = a + b };
};
int main()
{
	cout << Add<2, 3>::result << endl; //imprime 5
	return 0;
}