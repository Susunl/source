
#include<iostream>
using namespace std;

class A  //大小为4
{
public:
	int a;
};
class B :virtual public A  //大小为12，变量a,b共8字节，虚基类表指针4
{
public:
	int b;
};
class C :virtual public A //与B一样12
{
public:
	int c;
};
class D :public B, public C //24,变量a,b,c,d共16，B的虚基类指针4，C的虚基类指针
{
public:
	int d;
};

int main()
{
	A a;
	B b;
	C c;
	D d;
	cout << sizeof(a) << endl;
	cout << sizeof(b) << endl;
	cout << sizeof(c) << endl;
	cout << sizeof(d) << endl;
	system("pause");
	return 0;
}