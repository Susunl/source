
#include <iostream>
#include "DoubleLink.h"
using namespace std;

// 双向链表操作int数据
void int_test()
{
	int iarr[4] = { 10, 20, 30, 40 };//定义一个数组

	cout << "\n开始测试 int数据" << endl;
	// 创建双向链表
	DoubleLink<int>* pdlink = new DoubleLink<int>();

	pdlink->insert(0, 20);        // 将 20 插入到第一个位置
	pdlink->append_last(10);    // 将 10 追加到链表末尾
	pdlink->insert_first(30);    // 将 30 插入到第一个位置

	// 双向链表是否为空
	cout << "is_empty()=" << pdlink->is_empty() << endl;
	// 双向链表的大小
	cout << "size()=" << pdlink->size() << endl;

	// 打印双向链表中的全部数据
	int sz = pdlink->size();
	for (int i = 0; i < sz; i++)
		cout << "pdlink(" << i << ")=" << pdlink->get(i) << endl;
}


int main()
{
	int_test();        // 演示向双向链表操作“int数据”。
	system("pause");
	return 0;
}