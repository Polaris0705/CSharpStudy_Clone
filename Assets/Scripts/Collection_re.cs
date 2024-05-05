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
    public GameObject panel_bt;
    public GameObject panel_output;
    public string valList = "";

    List<string> names = new List<string>();

    private void Start()
    {
        panel_bt.SetActive(true);
    }

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.A))
        {    //1. �� �л��� �̸��� �߰�(A)
            panel_bt.SetActive(false);
            panel_output.SetActive(true);
            string value = input.text;
            Addnames();
            if (Input.GetKeyDown(KeyCode.X))
            {
                output.text = "3�� �� ���� ȭ������ ���ư��ϴ�...";
                Thread.Sleep(300);
                output.text = null;
                panel_bt.SetActive(true);
                panel_output.SetActive(false);
            }

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
            output.text = "\n����� ����մϴ�...\n";
            names.Sort();
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

    private void Addnames()
    {
        output.text = "����Ͻ� ������ �Է����ּ���.";
        string value = input.text;
        names.Add(value);
        if (value != ""&& Input.GetKeyDown(KeyCode.A))
        {
            output.text = $"{value}���� �߰��߽��ϴ�.\n\n[X]Ű�� ������ ���� ȭ������ ���ư��ϴ�.";
            value = null;
        }
    }





}
