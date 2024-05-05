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
public class CollectionStudy : MonoBehaviour
{
    public InputField input;
    public Text output;
    public GameObject panel_bt;
    public GameObject panel_output;
    public string valList = "";

    // 컬렉션의 특징 및 장점
    //1. 데이터 관리를 효율적으로 할 수 있음(가변형 데이터 구조)
    //2. 데이터 검색 및 정렬을 위한 메서드(기능)들이 존재
    //3. 다양한 데이터 유형을 저장할 수 있다.
    /*
    List<string> names = new List<string>(); //객체화 필요
    Dictionary<string, int> library = new Dictionary<string, int>(); //Key, value가 한 쌍, 중복이 안되는 Key
    Stack<string> exeStack = new Stack<string>(); //순서대로 쌓은 후 마지막 아이템부터 꺼낸다.
    Queue<string> exeQueue = new Queue<string>(); //순서대로 쌓은 후 넣은 순서대로 꺼낸다.
    HashSet<string> names2 = new HashSet<string>(); // List와 같은 역할, 내용은 중복 불가
    */


    //실습: 학급 명단 관리
    //1. 새 학생의 이름을 추가(A+space)
    //2. 특정 학생을 명단에서 확인하고 삭제(D+space)
    //2-1. 없으면 정보없음 출력
    //3. 전체 학생 명단을 출력(s+space)
    //4. 특정 학생이 명단 몇번째에 있는지  위치 확인(c+space)

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

        names.Add("김철수");
        names.Remove("김철수");
        int length = names.Capacity; // 캐퍼시티: 리스트 크기
        names.RemoveAt(0); //해당 인덱스(번호)로 찾고 해당 인덱스의 값을 제거
        names.Contains("김철수"); // 해당 값이 있는지 확인
        names.AddRange(names2); // 특정 자료형의 컬렉션을 추가(엑셀의 필터)
        names.Sort(); //오름차순 정렬
        names.Reverse();//내림차순 정렬
        names.Insert(0, "김한수"); //특정 위치에 값 추가
        names.InsertRange(0, names2); //특정 위치에 특정 자료형의 컬렉션을 추가
        // 같은 위치에 들어가면 원래 있던 애들은 밀려버림

        //list
        names.Add("김민수");
        names.Insert(0, "김민수");
        print(names[0]);
        print(names[1]);

        //dictionary
        library.Add("책1", 1);
        bool isExist = library.TryAdd("책1", 2);
        library.ContainsKey("책1");
        library.ContainsValue(1);

        //stack
        exeStack.Push("책1"); //컬렉션 추가
        exeStack.Push("책2"); //컬렉션 추가
        exeStack.Push("책3"); //컬렉션 추가
        string st = exeStack.Pop();//컬렉션 꺼내기
        exeStack.Peek(); //마지막으로 넣은 값 확인
        exeStack.TryPeek(out st); //마지막으로 넣은 값 확인하고 변경

        //Queue
        exeQueue.Enqueue("김철수"); //컬렉션 추가
        exeQueue.Enqueue("김영수"); //컬렉션 추가
        string name2 = exeQueue.Dequeue(); //처음 넣은 값 꺼내기
        exeQueue.TryPeek(out name2); //마지막 값 반환
        exeQueue.TryDequeue(out name2); //처음 값 반환 및 제거

        //Hashset
        names2.Add("김철수");
        HashSet<string> newNames = new HashSet<string> {"김철수", "김철수철수","김병철"};
        names2.IntersectWith(newNames); //교집합
        newNames.IsSubsetOf(names2); //부분집합
        newNames.IsSupersetOf(names2); // 진부분집합인지 확인(비슷하지만 같지않음)
*/
        names.Sort();

        if (Input.GetKeyDown(KeyCode.A))
        {    //1. 새 학생의 이름을 추가(A+space)
            panel_bt.SetActive(false);
            panel_output.SetActive(true);
            string value = input.text;
            do
            {
                output.text = "등록하실 성명을 입력해주세요.";
                names.Add(value);
                if (value != "")
                {
                    output.text = $"{value}님을 추가했습니다.\n\n[X]키를 누르면 메인 화면으로 돌아갑니다.";
                    value = null;
                }
            }
            while (Input.GetKeyDown(KeyCode.X));

            output.text = "3초 후 메인 화면으로 돌아갑니다...";
            Thread.Sleep(300);
            output.text = null;
            panel_bt.SetActive(true);
            panel_output.SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.D))
        {   //2. 특정 학생을 명단에서 확인하고 삭제(D+space)
            output.text = "제명하실 성명을 입력해주세요.\n";
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
            output.text = "\n";
            output.text = "명단을 출력합니다...\n";            
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
}
