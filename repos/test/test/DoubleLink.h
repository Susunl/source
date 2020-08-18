
#ifndef DOUBLE_LINK_HXX
#define DOUBLE_LINK_HXX

#include <iostream>
using namespace std;
//һ���ڵ�
template<class T>
struct DNode
{
public:
	T value;
	DNode* prev;
	DNode* next;
public:
	DNode() { }
	DNode(T t, DNode* prev, DNode* next) {
		this->value = t;
		this->prev = prev;
		this->next = next;
	}
};
//˫�������������
template<class T>
class DoubleLink
{
public:
	DoubleLink();
	~DoubleLink();

	int size();//��С
	int is_empty();//�ж��Ƿ�Ϊ��

	T get(int index);//��ȡ�ڵ�
	T get_first();//��ȡ�׽ڵ�
	T get_last();//��ȡβ�ڵ�

	int insert(int index, T t);
	int insert_first(T t);
	int append_last(T t);

	int del(int index);
	int delete_first();
	int delete_last();

private:
	int count;
	DNode<T>* phead;
private:
	DNode<T>* get_node(int index);
};

template<class T>
DoubleLink<T>::DoubleLink() : count(0)
{
	// ��������ͷ����ע�⣺��ͷû�д洢���ݣ�
	phead = new DNode<T>();
	phead->prev = phead->next = phead;
	// �����������Ϊ0
	//count = 0;
}

// ��������
template<class T>
DoubleLink<T>::~DoubleLink()
{
	// ɾ�����еĽڵ�
	DNode<T>* ptmp;
	DNode<T>* pnode = phead->next;
	while (pnode != phead)
	{
		ptmp = pnode;
		pnode = pnode->next;
		delete ptmp;
	}

	// ɾ��"��ͷ"
	delete phead;
	phead = NULL;
}

// ���ؽڵ���Ŀ
template<class T>
int DoubleLink<T>::size()
{
	return count;
}

// ���������Ƿ�Ϊ��
template<class T>
int DoubleLink<T>::is_empty()
{
	return count == 0;
}

// ��ȡ��indexλ�õĽڵ�
template<class T>
DNode<T>* DoubleLink<T>::get_node(int index)
{
	// �жϲ�����Ч��
	if (index < 0 || index >= count)
	{
		cout << "get node failed! the index in out of bound!" << endl;
		return NULL;
	}

	// �������
	if (index <= count / 2)
	{
		int i = 0;
		DNode<T>* pindex = phead->next;
		while (i++ < index) {
			pindex = pindex->next;
		}

		return pindex;
	}

	// �������
	int j = 0;
	int rindex = count - index - 1;
	DNode<T>* prindex = phead->prev;
	while (j++ < rindex) {
		prindex = prindex->prev;
	}

	return prindex;
}

// ��ȡ��indexλ�õĽڵ��ֵ
template<class T>
T DoubleLink<T>::get(int index)
{
	return get_node(index)->value;
}

// ��ȡ��1���ڵ��ֵ
template<class T>
T DoubleLink<T>::get_first()
{
	return get_node(0)->value;
}

// ��ȡ���һ���ڵ��ֵ
template<class T>
T DoubleLink<T>::get_last()
{
	return get_node(count - 1)->value;
}

// ���ڵ���뵽��indexλ��֮ǰ
template<class T>
int DoubleLink<T>::insert(int index, T t)
{
	if (index == 0)
		return insert_first(t);

	DNode<T>* pindex = get_node(index);
	DNode<T>* pnode = new DNode<T>(t, pindex->prev, pindex);
	pindex->prev->next = pnode;
	pindex->prev = pnode;
	count++;

	return 0;
}

// ���ڵ�����һ���ڵ㴦��
template<class T>
int DoubleLink<T>::insert_first(T t)
{
	DNode<T>* pnode = new DNode<T>(t, phead, phead->next);
	phead->next->prev = pnode;
	phead->next = pnode;
	count++;

	return 0;
}

// ���ڵ�׷�ӵ������ĩβ
template<class T>
int DoubleLink<T>::append_last(T t)
{
	DNode<T>* pnode = new DNode<T>(t, phead->prev, phead);
	phead->prev->next = pnode;
	phead->prev = pnode;
	count++;

	return 0;
}

// ɾ��indexλ�õĽڵ�
template<class T>
int DoubleLink<T>::del(int index)
{
	DNode<T>* pindex = get_node(index);
	pindex->next->prev = pindex->prev;
	pindex->prev->next = pindex->next;
	delete pindex;
	count--;

	return 0;
}

// ɾ����һ���ڵ�
template<class T>
int DoubleLink<T>::delete_first()
{
	return del(0);
}

// ɾ�����һ���ڵ�
template<class T>
int DoubleLink<T>::delete_last()
{
	return del(count - 1);
}

#endif