using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using UnityEngine;
/// <summary>
/// 배열 스터디
/// </summary>
public class ArrayStudy : MonoBehaviour
{   // 배열: 자료형을 여러개 저장할 수 있는 데이터 구조
    // 데이터를 효율적으로 관리하기 위해 사용

    // 배열 키워드
    /*
    int[] numbers; 
    //int a = numbers[0]; ->nullreferenceexption 오류: 인스턴스로 만들어주지 않아 발생
    int[] numbers2 = new int[5];//new 키워드로 인스턴스화, 5개 인수 공간 만들기
    string[] names = new string[3];
    */
    void Start()
    {   /*
        print(numbers2[0]); //0으로 초기화
        // print(numbers2[5]);배열의 범위를 벗어난 인덱스 사용으로 indexoutofrangeexception 발생

        //배열의 속성
        print(numbers2.Length);//배열의 크기
        print(numbers2.Rank); //배열의 차원 수

        //배열의 메서드화
        names[0] = "이솔비";
        names[0] = "안지수";
        names[0] = "손예선";

        Array.Sort(names);
        Array.Sort<string>(names);
        print(names[0]);
        Array.Reverse(names);
        print(names[0]);

        //배열 키워드 - 다차원/2차원 배열
        int[]numbers = new int[5];
        string[]names = new string[3];
        string[] names2 = { "가", "나", "다", "라" };
        string[,] library = new string[2, 2];
        library[0, 0] = "가";
        library[1, 0] = "나";
        library[2, 0] = "다";
        library[0, 1] = "라";
        library[1, 1] = "마";
        library[2, 1] = "바";
        library[0, 2] = "사";
        library[1, 2] = "아";
        library[2, 2] = "자";
        */

        //실습1 : 24년 5월 3일 기온 데이터
        //1. 하루 평균 기온 계산 후 출력{13, 12, 13...} 23개의 데이터(1시~23시)
        //2. 하루 최고 기온 확인 후 출력
        //3. 평균 기온보다 높은 시간대 출력

        int[] arr1 = {24, 26, 26, 27, 26,
                      24, 22, 20, 19, 18,
                      17, 17, 16, 16, 15,
                      15, 14, 14, 16, 18,
                      21, 23, 24}; //3일 1시~ 4일 11시
        int sum = 0;
        int max = 0;
        int min = 0;
        string temp = "";
        float avg = sum / arr1.Length;

        for (int i = 0; i < arr1.Length; i++)
        {
            sum += arr1[i];


            if (arr1[i] > max)
            {
                max = arr1[i];
            }
            if (arr1[i] < min)
            {
                min = arr1[i];
            }
            if (arr1[i] > avg)
            {
                temp += (i + 1).ToString() + "시, ";
            }
        }


        print($"평균: {(int)avg}도");
        print($"최대: {max}도");
        print($"최소: {min}도");
        print($"평균보다 기온이 높은 시간대:{temp}");


        //물품 재고 관리 데이터
        int[] inventory = { 50, 10, 2, 10, 5 };
        string[] name = { "로션", "선크림", "향수", "아이브로우", "스낵" };
        int totalInventory = 0;
        int maxStock = 0;
        int minStock = 100;
        int avgStock = 0;



        //1. 재고가 10개 미만인 모든 아이템과 그 재고
        for (int j = 0; j < inventory.Length; j++)
        {
            if (inventory[j] < 10)
            {
                string lowstock = name[j] + inventory[j].ToString() + "개";
                print($"10개 미만:{lowstock}");
            }
        }

        for (int i = 0; i < inventory.Length; i++)
        {
            //2. 재고량 합계 출력
            totalInventory += inventory[i];

            // 3. 가장 재고량이 많은 아이템 출력
            if (inventory[i] > maxStock)
            {
                maxStock = inventory[i];
            }
            if (inventory[i] < minStock)
            {
                minStock = inventory[i];
            }

            // 4. 평균 재고량 출력

            avgStock = totalInventory / inventory.Length;

            //5. 평균 이하 아이템 / 개수 출력


        }
        for (int k = 0; k < inventory.Length; k++)
        {
            if (inventory[k] < avgStock)
            {
                string avglowstock = name[k] + inventory[k].ToString() + "개";
                print($"평균이하:{avglowstock}");

            }
        }
        print("총 재고: " + totalInventory + "개");
        print("최대: " + maxStock + "개");
        print("최소: " + minStock + "개");
        print("평균: " + avgStock + "개");

    }
}
