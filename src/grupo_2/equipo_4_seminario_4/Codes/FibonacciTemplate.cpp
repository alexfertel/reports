//Templates
//Fibonacci
/////////////////////////////////////////////////////////

#include <cstring>
#include <iostream>
#include <string>
using namespace std;

template<int n>
	struct fib{
		static const int result = fib<n - 2>::result + fib<n - 1>::result;
	};

template<>
	struct fib<1>{
		static const int result = 1;
	};

template<>
	struct fib<2>{
		static const int result = 1;
	};

int main()
{
    cout <<  fib<6>::result << endl;
	return 0;
}

