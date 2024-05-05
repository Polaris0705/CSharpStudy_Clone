using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UI;
using UnityEngine.Windows;
using Input = UnityEngine.Input;
using System.Threading;
/// <summary>
/// �÷��� ���͵� Ŭ����
/// </summary>
public class CollectionStudy : MonoBehaviour
{
    public InputField input;
    public Text output;
    public GameObject panel_bt;
    public GameObject panel_output;
    public string valList = "";

    // �÷����� Ư¡ �� ����
    //1. ������ ������ ȿ�������� �� �� ����(������ ������ ����)
    //2. ������ �˻� �� ������ ���� �޼���(���)���� ����
    //3. �پ��� ������ ������ ������ �� �ִ�.
    /*
    List<string> names = new List<string>(); //��üȭ �ʿ�
    Dictionary<string, int> library = new Dictionary<string, int>(); //Key, value�� �� ��, �ߺ��� �ȵǴ� Key
    Stack<string> exeStack = new Stack<string>(); //������� ���� �� ������ �����ۺ��� ������.
    Queue<string> exeQueue = new Queue<string>(); //������� ���� �� ���� ������� ������.
    HashSet<string> names2 = new HashSet<string>(); // List�� ���� ����, ������ �ߺ� �Ұ�
    */


    //�ǽ�: �б� ��� ����
    //1. �� �л��� �̸��� �߰�(A+space)
    //2. Ư�� �л��� ��ܿ��� Ȯ���ϰ� ����(D+space)
    //2-1. ������ �������� ���
    //3. ��ü �л� ����� ���(s+space)
    //4. Ư�� �л��� ��� ���°�� �ִ���  ��ġ Ȯ��(c+space)

    List<string> names = new List<string>();


    private void Start()
    {
        panel_bt.SetActive(true);
    }


    // Start is called before the first frame update
    private void Update()
    {/*
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
        exeStack.Push("å2"); //�÷��� �߰�
        exeStack.Push("å3"); //�÷��� �߰�
        string st = exeStack.Pop();//�÷��� ������
        exeStack.Peek(); //���������� ���� �� Ȯ��
        exeStack.TryPeek(out st); //���������� ���� �� Ȯ���ϰ� ����

        //Queue
        exeQueue.Enqueue("��ö��"); //�÷��� �߰�
        exeQueue.Enqueue("�迵��"); //�÷��� �߰�
        string name2 = exeQueue.Dequeue(); //ó�� ���� �� ������
        exeQueue.TryPeek(out name2); //������ �� ��ȯ
        exeQueue.TryDequeue(out name2); //ó�� �� ��ȯ �� ����

        //Hashset
        names2.Add("��ö��");
        HashSet<string> newNames = new HashSet<string> {"��ö��", "��ö��ö��","�躴ö"};
        names2.IntersectWith(newNames); //������
        newNames.IsSubsetOf(names2); //�κ�����
        newNames.IsSupersetOf(names2); // ���κ��������� Ȯ��(��������� ��������)
*/
        names.Sort();

        if (Input.GetKeyDown(KeyCode.A))
        {    //1. �� �л��� �̸��� �߰�(A+space)
            panel_bt.SetActive(false);
            panel_output.SetActive(true);
            string value = input.text;
            do
            {
                output.text = "����Ͻ� ������ �Է����ּ���.";
                names.Add(value);
                if (value != "")
                {
                    output.text = $"{value}���� �߰��߽��ϴ�.\n\n[X]Ű�� ������ ���� ȭ������ ���ư��ϴ�.";
                    value = null;
                }
            }
            while (Input.GetKeyDown(KeyCode.X));

            output.text = "3�� �� ���� ȭ������ ���ư��ϴ�...";
            Thread.Sleep(300);
            output.text = null;
            panel_bt.SetActive(true);
            panel_output.SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.D))
        {   //2. Ư�� �л��� ��ܿ��� Ȯ���ϰ� ����(D+space)
            output.text = "�����Ͻ� ������ �Է����ּ���.\n";
            string value = input.text;
            output.text = "\n";
            output.text = "�˻����Դϴ�...\n";
            Thread.Sleep(300);
            if (names.Contains(value))
            {
                output.text = $"{value} ���� ��ܿ��� �����Ͽ����ϴ�.\n";
                names.Remove(value);
            }
            else
            {    //2-1. ������ �������� ���
                output.text = "�ش� �л��� ��ܿ� �����ϴ�.\n";
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {    //3. ��ü �л� ����� ���(s+space)
            output.text = "\n";
            output.text = "����� ����մϴ�...\n";            
            Thread.Sleep(300);
            for (int i = 0; i < names.Count; i++)
            {
                valList = $"{i}�� | {names[i]} ��\n";
            }
            output.text = $"-----------------------------\n{valList}-----------------------------\n";
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            output.text = "�˻��Ͻ� ������ �Է����ּ���.\n";
            string value = input.text;
            output.text = "\n";
            output.text = "�˻����Դϴ�...\n";
            if (names.Contains(value))
            {
                output.text = $"{value}���� {names.IndexOf(value)}��°�� �ֽ��ϴ�.";
            }
            else
            {    //2-1. ������ �������� ���
                output.text = "�ش� �л��� ��ܿ� �����ϴ�.";
            }
        }
    }
}
