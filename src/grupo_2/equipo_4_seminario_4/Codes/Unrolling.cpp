
#include <cstring>
#include <iostream>
#include <string>
using namespace std;

////////////////////////////////////////////////////////
//Loop Unrolling
///////////////////////////////////////////////////////
template<int i>
struct unroll{
	static const int sum = i + unroll<i - 1> :: sum;
};

template<>
struct unroll<1>{
	static const int sum = 1;
};

int main()
{
    
    int sum1 = 0;
    int n = 5;
    for(int i = 1; i <= n; i++)
    {
	    sum1 += i;
    }
    cout <<  sum1 << endl;
    cout << unroll<5>::sum << endl;
	return 0;
}



