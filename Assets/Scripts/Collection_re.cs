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
/// 컬렉션 스터디 클래스
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
        {    //1. 새 학생의 이름을 추가(A)
            panel_bt.SetActive(false);
            panel_output.SetActive(true);
            string value = input.text;
            Addnames();
            if (Input.GetKeyDown(KeyCode.X))
            {
                output.text = "3초 후 메인 화면으로 돌아갑니다...";
                Thread.Sleep(300);
                output.text = null;
                panel_bt.SetActive(true);
                panel_output.SetActive(false);
            }

        }

        if (Input.GetKeyDown(KeyCode.D))
        {   //2. 특정 학생을 명단에서 확인하고 삭제(D+space)
            output.text = "삭제하실 성명을 입력해주세요.\n";
            string value = input.text;
            output.text = "\n";
            output.text = "검색중입니다...\n";
            Thread.Sleep(300);
            if (names.Contains(value))
            {
                output.text = $"{value} 님을 명단에서 삭제하였습니다.\n";
                names.Remove(value);
            }
            else
            {    //2-1. 없으면 정보없음 출력
                output.text = "해당 학생은 명단에 없습니다.\n";
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {    //3. 전체 학생 명단을 출력(s+space)
            output.text = "\n명단을 출력합니다...\n";
            names.Sort();
            Thread.Sleep(300);
            for (int i = 0; i < names.Count; i++)
            {
                valList = $"{i}번 | {names[i]} 님\n";
            }
            output.text = $"-----------------------------\n{valList}-----------------------------\n";
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            output.text = "검색하실 성명을 입력해주세요.\n";
            string value = input.text;
            output.text = "\n";
            output.text = "검색중입니다...\n";
            if (names.Contains(value))
            {
                output.text = $"{value}님은 {names.IndexOf(value)}번째에 있습니다.";
            }
            else
            {    //2-1. 없으면 정보없음 출력
                output.text = "해당 학생은 명단에 없습니다.";
            }
        }
    }

    private void Addnames()
    {
        output.text = "등록하실 성명을 입력해주세요.";
        string value = input.text;
        names.Add(value);
        if (value != ""&& Input.GetKeyDown(KeyCode.A))
        {
            output.text = $"{value}님을 추가했습니다.\n\n[X]키를 누르면 메인 화면으로 돌아갑니다.";
            value = null;
        }
    }





}
