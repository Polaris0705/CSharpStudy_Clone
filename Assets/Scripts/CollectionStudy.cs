using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;
/// <summary>
/// 컬렉션 스터디 클래스
/// </summary>
public class CollectionStudy : MonoBehaviour
{
    //컬렉션의 특징 및 장점
    //1. 데이터 관리를 효율적으로 할 수 있음(가변형 데이터 구조)
    //2. 데이터 검색 및 정렬을 위한 메서드(기능)들이 존재
    //3. 다양한 데이터 유형을 저장할 수 있다.
    List<string> names = new List<string>(); //객체화 필요
    Dictionary<string, int> library = new Dictionary<string, int>(); //Key, value가 한 쌍, 중복이 안되는 Key
    Stack<string> exeStack = new Stack<string>(); //순서대로 쌓은 후 마지막 아이템부터 꺼낸다.
    Queue<string> exeQueue = new Queue<string>(); //순서대로 쌓은 후 넣은 순서대로 꺼낸다.
    HashSet<string> names2 = new HashSet<string>(); // List와 같은 역할, 내용은 중복 불가

    // Start is called before the first frame update
    void Start()
    {
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
        string st = exeStack.Pop();//컬렉션 꺼내기
        exeStack.Peek(); //마지막으로 넣은 값 확인
        exeStack.TryPeek(out st); //마지막으로 넣은 값 확인하고 변경

        //Queue
        exeQueue.Enqueue("김철수"); //컬렉션 추가
        string name2 = exeQueue.Dequeue(); //처음 넣은 값 꺼내기
        exeQueue.TryPeek(out name2); //마지막 값 반환
        exeQueue.TryDequeue(out name2); //처음 값 반환 및 제거

        //Hashset
        names2.Add("김철수");
        HashSet<string> newNames = new HashSet<string> {"김철수", "김철수철수","김병철"};
        names2.IntersectWith(newNames); //교집합
        newNames.IsSubsetOf(names2); //부분집합
        newNames.IsSupersetOf(names2); // 진부분집합인지 확인(비슷하지만 같지않음)


    }
}
