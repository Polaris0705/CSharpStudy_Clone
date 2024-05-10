using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IterationStudy : MonoBehaviour
{
    [SerializeField] TMP_Dropdown interestOption;
    [SerializeField] TMP_InputField balanceInput;
    [SerializeField] TMP_InputField interestRateInput;
    [SerializeField] TMP_InputField yearInput;
    [SerializeField] TMP_InputField monthInput;
    [SerializeField] Text logText;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        /*반복문 스터디
        //for //초기화 //조건 //증감
        string[] names = { "갑", "을", "병", "정", "무" };
        for (int i = 0; i < names.Length; i++)
        {
            print(i);
            print(names[i]); //0~배열의 길이까지 반복(+)
        }

        for (int i = (names.Length-1); i>=0; i--)
        {
            print(i);
            print(names[i]); //배열의 길이~0까지 반복(-)
        }

        for (int i = 0; i <10; i++)
        {
            if(i%2==0)
            { print(i);}
            else { print("홀"); }
        }

        //foreach // 조건을 입력할 필요가 없음

        foreach (string name in names)
        {
            print(name);
        }

        //while - 무한반복
        int num = 0;
        while (num< 10)
        {
            num++;
        }
        while (true)
        {
            if (num == 8)
            {
                break;//반복문 종료
            }
        }
        int m0 = 0;
        while(m0 == 0)
        {
            break;
        }

        int m1 = 0;
        do
        {
            print(m1);
            m1++;
            print("최소 한번(거짓이어도) 실행한 후 조건을 확인->반복");
        }
        while (m1<10);
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 실습 1: 은행 적금 이자 계산(단리, 복리)
    // 열거형으로 단리, 복리
    // 입력: 초기 금액, 연이율, 기간
    // (1) dropdown UI에서 단리 / 복리 선택
    // (2) 금액 입력
    // (3) 연이율 입력
    // (4) 기간 입력
    //
    //  출력예시 - 3년만기 정기예금

    //  [단리]
    //         년차  입금액  이자율  총액
    //        1년차  10만원   10%  11만원
    //        2년차  10만원   10%  22만원

    //  [복리]
    //         년차  입금액  이자율  총액
    //        1년차  10만원   10%  11만원
    //        2년차  10만원   11%  23.1만원

    public void Calc()
    {
        if ((balanceInput != null || interestRateInput != null))
        {
            double bal = double.Parse(balanceInput.text);
            double rate = double.Parse(interestRateInput.text)/100;
            double year = double.Parse(yearInput.text);
            double month = double.Parse(monthInput.text);

            switch (interestOption.value)
            {
                case 0: //연단리
                    logText.text = null;
                    for(double i = bal, j = 1; j <=year; i =(bal*j)*(1+rate),j++)
                    {
                        string log = $"{j}년차 | {bal}원 | {rate*100}% | {i}원\n";
                        print(log);
                        logText.text += log;
                    }
                break;

                case 1: //연복리
                    logText.text= null;
                    for (double i = bal, j = 1; j <= year; i = (bal*j) + (j*i * rate),j++)
                    {
                        string log = $"{j}년차 | {bal}원 | {(int)i/(rate*100)}% | {(int)i}원\n";
                        print(log);
                        logText.text += log;
                    }
                    break;

                case 2: //월단리
                    logText.text = null;
                    for(double i = bal, j=0; j<=month; i = (bal * j) + j * (bal * rate),j++)
                    {
                        string log = $"{j}개월차 | {bal}원 | {(int)(i * rate / 10)}% | {(int)i}원\n";
                        logText.text += log;
                    }
                    break;
            }

        }
        else
        {
            return;
        }
    }
}

