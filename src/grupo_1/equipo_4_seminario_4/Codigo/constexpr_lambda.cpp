#include<bits/stdc++.h>

using namespace std;

auto identity = [](int n) constexpr { return n; };

constexpr auto sum = [](int x, int y){
	auto X = [=] { return x; };
	auto Y = [=] { return y; };

	return X() + Y();
};
int main()
{
	static_assert(sum(2, 3) == 5, "ERROR");
	static_assert(identity(3) == 3, "ERROR");
	return 0;
}