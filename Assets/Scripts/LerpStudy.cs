using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Lerp(Linear Interporlation, 선형 보간): 값 A와 값 B 사이의 값을 계산하는 방법
/// (1) 3D object의 움직임을 부드럽게 표현하기 위해 사용
/// (2) 숫자A와 숫자B의 값 사이를 Blending(천천히 변형)
/// </summary>
public class LerpStudy : MonoBehaviour
{
    public Light light;
    public Color colorA;
    public Color colorB;
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public Transform pointD;
    public Transform pointE;
    public Transform obj;
    public float numA = 0;
    public float numB = 3;
    public float duration = 5;
    public float currentTime = 0;
    Vector3 newVector;
    Vector3 newVector1;
    Vector3 newVector2;
    Vector3 newVector3;
    Vector3 newVector4;
    public bool isDirectionchanged = false;

    private void Start()
    {
        //obj.position = pointA.position;
    }


    void Update()
    {
        currentTime += Time.deltaTime;
        /*
        if (currentTime > duration)
        {
            currentTime = 0; // duration 범위가 0~d이기때문
            float temp = numA;
            numA = numB;
            numB = temp; //a와 b를 바꿔 페이드인/아웃 구현

            Color tempColor = colorA;
            colorA = colorB;
            colorB = tempColor; //a와 b를 바꿔 페이드인/아웃 구현

            Vector3 tempv = pointA.position;
            pointA.position = pointB.position;
            pointB.position = tempv;
        }
        //조도 변경
        float value = Mathf.Lerp(numA, numB, currentTime / duration);
        //print(value);//2초동안 이동
        light.intensity = value;

        //컬러 변경
        Color newcolor = Color.Lerp(colorA, colorB, currentTime / duration);
        light.color = newcolor;

        //위치 이동
        Vector3 newVector = Vector3.Lerp(pointA.position, pointB.position, currentTime / duration);
        obj.position = newVector;
        */

/*        //실습1. 이어달리기
        //5개 포인트 A,B,C,D,E 로 순차적으로 obj를 이동반복(각이동의 duration은 1초)
        
        if (currentTime > duration)
        {
            currentTime = 0;
        }
        Vector3[] positions = {pointA.position, pointB.position, pointC.position, pointD.position, pointE.position};
        for(int i=0; i<positions.Length; i++)
        {
            switch (i)
            {
                case 0:
                    Vector3 newVector = Vector3.Lerp(positions[0], positions[1], currentTime / duration);
                    obj.position = newVector;
                    print("a->b");
                    break;

                case 1:
                    Vector3 newVector1 = Vector3.Lerp(positions[1], positions[2], currentTime / duration);
                    obj.position = newVector1;
                    print("b->c");
                    break;
                case 2:

                    Vector3 newVector2 = Vector3.Lerp(positions[2], positions[3], currentTime / duration);
                    obj.position = newVector2;
                    print("c->d");
                    break;

                case 3:
                    Vector3 newVector3 = Vector3.Lerp(positions[3], positions[4], currentTime / duration);
                    obj.position = newVector3;
                    print("d->e");
                    break;

                case 4:
                    Vector3 newVector4 = Vector3.Lerp(positions[4], positions[0], currentTime / duration);
                    obj.position = newVector4;
                    print("e->a");
                    break;
            }
        }*/

                // 실습2. 물체간의 거리를 계산해 특정 거리 이내일 때 방향 바꾸기
                Vector3 positionA = new Vector3(0,0,0);
                Vector3 positionB = new Vector3(3, 3, 3);
                //Vector3 newVec3 = positionB - positionA;


                Vector3 moveVector = Vector3.Lerp(positionA, positionB, currentTime / duration);
                obj.position = moveVector;
                Vector3 newVec3 = positionB - obj.position;
                float distance = newVec3.magnitude;


                if(distance < 0.05f)//거리가 0.5이내면 방향전환
                {
                    print(distance);
            currentTime = 0;

                        Vector3 temp = positionA;
                        positionA = positionB;
                        positionB = temp;
                }

            }
    }
