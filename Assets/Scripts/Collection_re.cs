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
public class Collection_re : MonoBehaviour
{
    public InputField input;
    public Text output;
    public Text output1;

    public GameObject panel_bt;
    public GameObject panel_output;
    public GameObject panel_output1;
    public string valList;

    List<string> names = new List<string>();

    private void Start()
    {
        panel_bt.SetActive(true);
    }

    private void Update()
    {


        if (Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.A))
        {    //1. �� �л��� �̸��� �߰�(A)
            panel_bt.SetActive(false);
            panel_output.SetActive(true);
            string value = input.text;
            Addnames();
        }

        if (Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.X))
        {   // ���� ȭ������
            input.text = null;
            output.text = null;
            output1.text = null;
            panel_bt.SetActive(true);
            panel_output.SetActive(false);
            panel_output1.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.D))
        {   //2. Ư�� �л��� ��ܿ��� Ȯ���ϰ� ����(D+space)
            panel_bt.SetActive(false);
            panel_output.SetActive(true);
            string value = input.text;
            Deletenames();

        }

        if (Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.S))
        {    //3. ��ü �л� ����� ���(s+space)
            panel_bt.SetActive(false);
            panel_output1.SetActive(true);
            string value = input.text;
            Sortnames();
        }


        if (Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.C))
        {
            panel_bt.SetActive(false);
            panel_output.SetActive(true);
            string value = input.text;
            Checknames();
        }
    }

    private void Addnames()
    {
        output.text = "����Ͻ� ������ �Է� �� [Space]+[A]Ű�� �����ּ���.";
        string value = input.text;
        names.Add(value);
        if (value != ""&& Input.GetKeyDown(KeyCode.A))
        {
            output.text = $"{value}���� �߰��߽��ϴ�.\n\n[Space]+[X]Ű�� ������ ���� ȭ������ ���ư��ϴ�.";
            value = null;
        }
    }

    private void Deletenames()
    {
        output.text = "�����Ͻ� ������ �Է����ּ���.\n";
        string value = input.text;
        if(value!=""&& Input.GetKeyDown(KeyCode.D))
        {
            if (names.Contains(value))
            {
                output.text = $"{value} ���� ��ܿ��� �����Ͽ����ϴ�.\n\n[X]Ű�� ������ ���� ȭ������ ���ư��ϴ�.\n";
                names.Remove(value);
            }
            else
            {    //2-1. ������ �������� ���
                output.text = "�ش� �л��� ��ܿ� �����ϴ�.\n\n[X]Ű�� ������ ���� ȭ������ ���ư��ϴ�.\n";
            }
        }

    }

    private void Sortnames()
    {
        names.Sort();
        for (int i = 1; i < names.Count; i++)
        {
            valList += $"{i+1}�� | {names[i+1]} ��\n";
        }
        output1.text = $"---\n{valList}---\n";
    }

    private void Checknames()
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
