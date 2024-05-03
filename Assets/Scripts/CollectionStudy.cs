using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;
/// <summary>
/// �÷��� ���͵� Ŭ����
/// </summary>
public class CollectionStudy : MonoBehaviour
{
    //�÷����� Ư¡ �� ����
    //1. ������ ������ ȿ�������� �� �� ����(������ ������ ����)
    //2. ������ �˻� �� ������ ���� �޼���(���)���� ����
    //3. �پ��� ������ ������ ������ �� �ִ�.
    List<string> names = new List<string>(); //��üȭ �ʿ�
    Dictionary<string, int> library = new Dictionary<string, int>(); //Key, value�� �� ��, �ߺ��� �ȵǴ� Key
    Stack<string> exeStack = new Stack<string>(); //������� ���� �� ������ �����ۺ��� ������.
    Queue<string> exeQueue = new Queue<string>(); //������� ���� �� ���� ������� ������.
    HashSet<string> names2 = new HashSet<string>(); // List�� ���� ����, ������ �ߺ� �Ұ�

    // Start is called before the first frame update
    void Start()
    {
        names.Clear();
        library.Clear();
        exeStack.Clear();
        exeQueue.Clear();
        names2.Clear();

        names.Add("��ö��");
        names.Remove("��ö��");
        int length = names.Capacity; // ĳ�۽�Ƽ: ����Ʈ ũ��
        names.RemoveAt(0); //�ش� �ε���(��ȣ)�� ã�� �ش� �ε����� ���� ����
        names.Contains("��ö��"); // �ش� ���� �ִ��� Ȯ��
        names.AddRange(names2); // Ư�� �ڷ����� �÷����� �߰�(������ ����)
        names.Sort(); //�������� ����
        names.Reverse();//�������� ����
        names.Insert(0, "���Ѽ�"); //Ư�� ��ġ�� �� �߰�
        names.InsertRange(0, names2); //Ư�� ��ġ�� Ư�� �ڷ����� �÷����� �߰�
        // ���� ��ġ�� ���� ���� �ִ� �ֵ��� �з�����

        //list
        names.Add("��μ�");
        names.Insert(0, "��μ�");
        print(names[0]);
        print(names[1]);

        //dictionary
        library.Add("å1", 1);
        bool isExist = library.TryAdd("å1", 2);
        library.ContainsKey("å1");
        library.ContainsValue(1);

        //stack
        exeStack.Push("å1"); //�÷��� �߰�
        string st = exeStack.Pop();//�÷��� ������
        exeStack.Peek(); //���������� ���� �� Ȯ��
        exeStack.TryPeek(out st); //���������� ���� �� Ȯ���ϰ� ����

        //Queue
        exeQueue.Enqueue("��ö��"); //�÷��� �߰�
        string name2 = exeQueue.Dequeue(); //ó�� ���� �� ������
        exeQueue.TryPeek(out name2); //������ �� ��ȯ
        exeQueue.TryDequeue(out name2); //ó�� �� ��ȯ �� ����

        //Hashset
        names2.Add("��ö��");
        HashSet<string> newNames = new HashSet<string> {"��ö��", "��ö��ö��","�躴ö"};
        names2.IntersectWith(newNames); //������
        newNames.IsSubsetOf(names2); //�κ�����
        newNames.IsSupersetOf(names2); // ���κ��������� Ȯ��(��������� ��������)


    }
}
