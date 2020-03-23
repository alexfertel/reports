#include<bits/stdc++.h>

using namespace std;

template<int start, int end, int inc> struct _for{
	static void run(){
		//code here
		_for<start + inc, end, inc>::run;
	}
};
template<int end, int inc> struct _for<end, end, inc>{
	static void run(){
		return ;
	}
};
int main()
{
	_for<0, 10, 1>::run();
	return 0;
}