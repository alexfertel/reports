#include<bits/stdc++.h>

using namespace std;

constexpr int Fibbonacci(int n){
	return n == 0 || n == 1 ? 1 : Fibbonacci(n - 1) + Fibbonacci(n - 2);
}
int main()
{
	cout << Fibbonacci(7) << endl; //imprime 21
	return 0;
}