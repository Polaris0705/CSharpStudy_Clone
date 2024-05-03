using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 240503_자료형과 형변환에 대한 스터디 클래스입니다.
/// </summary>

public class DataTypeStudy : MonoBehaviour
{   // 값(value)형 변수
    // 자료형 | 변수명 | 값
    bool    isEnable   = false;    //1바이트, true/false 저장
    int     number     = 0;        //32비트 = 4바이트, 정수형 값 저장 최대 0~4,294,967,295, -2,147,483,648 ~ +2,147,483,648
    uint    numberunit = 165484; //부호가 없는 정수 자료형
    float   number2    = 35.5f;    // 4바이트, 실수/자료형 변수. 소수점 표현이 가능함
    double  number3    = 35.5;     //64비트 = 8바이트, 보다 정밀한 수 표현 가능. 실수/자료형
    char    data       = 'c';      //하나의 문자를 저장
    string  name       = "CSharp"; // 문자열, 문자의 크기에 따라 크기가 변하는 자료형

    int number4;//값을 할당하지 않는 경우 0으로 자동 초기화

    const int age = 5;//상수 : runtime 시 변경 불가 / 글로벌 네임스페이스에도 적용됨

    // Start is called before the first frame update
    void Start()
    {
        print(isEnable);
        print(typeof(bool));
        print(number4);

        //age = 60; <-오류남

        //형변환(Type Cashing)
        int myInt = 10;
        double myDouble = 55.4;

        //형변환 방식 1 - 암시적, 명시적 형변환
        myDouble = myInt; // 암시적 형변환
        //myInt = myDouble; // 암시적 형변환 불가(double이 크기가 더 커서)

        myInt = (int)myDouble; //명시적 형변환: 크기가 큰 변수를 작은 변수로 변환 -> 55

        //형변환 방식 2 - 
        myInt.ToString(); // int형 변수를 string형으로 변환
        string age2 = "36";
        //age.ToIntArray();
        int.Parse(age2); //string->int형으로 변환
        float.Parse(age2);//string->float형으로 변환
        double.Parse(age2);//string->double형으로 변환
        bool.Parse(age2);//string->bool형으로 변환
    }

    // Update is called once per frame
    void Update()
    {

    }
}
