
#include<iostream>
using namespace std;

class A  //��СΪ4
{
public:
	int a;
};
class B :virtual public A  //��СΪ12������a,b��8�ֽڣ�������ָ��4
{
public:
	int b;
};
class C :virtual public A //��Bһ��12
{
public:
	int c;
};
class D :public B, public C //24,����a,b,c,d��16��B�������ָ��4��C�������ָ��
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