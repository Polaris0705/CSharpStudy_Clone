using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineStudy : MonoBehaviour
{
    /*public Transform redS;
    public Transform yellowS;
    public Transform greenS;
    public float duration = 3f;
    public MeshRenderer redmeshRenderer;
    public MeshRenderer yellowmeshRenderer;
    public MeshRenderer greenmeshRenderer;
    public Light redLight;
    public Light greenLight;
    public Light yellowLight;
    public bool isloopActive = true;*/


    /*    /// <summary>
        /// 1초 시간 간격으로 현재 시간을 콘솔에 입력
        /// </summary>
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(CoInput());
            StartCoroutine(CoSequence(obj));
        }

        // Update is called once per frame
        void Update()
        {
            // 물체 A를 Vector3.Lerp를 사용하여 이동시킨다
            // 물체 B를 vector3.lerp를 사용하여 이동시킨다
        }

        IEnumerator CoInput()
        {
            while(true)
            {
                print(DateTime.Now);
                yield return new WaitForSeconds(1); //1초에 한번씩 실행
            }
        }

        IEnumerator CoSequence(Transform obj)
        {
            float currentTime = 0;
            //obj A->B로 이동
            while (true)
            {
                currentTime += Time.deltaTime;
                if (currentTime > 2)
                {
                    currentTime = 0;
                }
                obj.position = Vector3.Lerp(Vector3.zero, new Vector3(3, 3, 3), currentTime / 2);

                if(obj.position ==new Vector3(3, 3, 3))
                {
                    break;
                }

                yield return new WaitForSeconds(Time.deltaTime); //delay
            }

            yield return new WaitForSeconds(2); //2s delay후 특정 기능 실행
            yield return CoSequence(obj2);
        }*/
    /*//실습1: 신호등 - 빨강, 노랑, 초록 신호등을 1초간격으로 깜빡이기
    //Sphere로 진행함
    //coroutine 아래에 trafficlight 만들어서 아래에 sphere 3개 생성

    private void Start()
    {
        redmeshRenderer.material.color = Color.clear; //초기: 검정색
        yellowmeshRenderer.material.color = Color.clear;
        greenmeshRenderer.material.color = Color.clear;
        redLight.intensity = 0;
        redLight.color = Color.red;
        yellowLight.intensity = 0;
        yellowLight.color = Color.yellow;
        greenLight.intensity = 0;
        greenLight.color = Color.green;
        StartCoroutine(CoTrafficLight());
    }

    IEnumerator CoTrafficLight()
    {
        while (isloopActive)
        {
            yield return new WaitForSeconds(1);
            redmeshRenderer.material.color = Color.red;
            redLight.intensity = 1;

            yield return new WaitForSeconds(5);
            redmeshRenderer.material.color = Color.clear;
            redLight.intensity = 0;

            yield return new WaitForSeconds(1);
            yellowmeshRenderer.material.color = Color.yellow;
            yellowLight.intensity = 1;

            yield return new WaitForSeconds(5);
            yellowmeshRenderer.material.color = Color.clear;
            yellowLight.intensity = 0;

            yield return new WaitForSeconds(1);
            greenmeshRenderer.material.color = Color.green;
            greenLight.intensity = 1;

            yield return new WaitForSeconds(5);
            greenmeshRenderer.material.color = Color.clear;
            greenLight.intensity = 0;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isloopActive = false;
        }
    }*/
    // 실습2: 공급 실린더(a) 전진, 후진 후 송출실린더 전진 후진.
    // 작동시간은 1초
    // LERP 사용- 실린더 A를 A-end로 이동 -> A-start로 이동
    // LERP 사용- 실린더 B를 B-end로 이동 -> B-start로 이동

    public Transform sCy;
    public Transform dCy;
    public Transform obj;
    public bool isActive = true;
    public float duration = 2;
    public Transform scy_s;
    public Transform scy_e;
    public Transform dcy_s;
    public Transform dcy_e;

    void Start()
    {
        StartCoroutine(MoveCyl(sCy, scy_s.position, scy_e.position));
        StartCoroutine(MoveCyl(sCy, scy_e.position, scy_s.position));
        StartCoroutine(MoveCyl(dCy, dcy_s.position, dcy_e.position));
        StartCoroutine(MoveCyl(dCy, dcy_e.position, dcy_s.position));
    }

    IEnumerator MoveCyl(Transform cylinder, Vector3 startP, Vector3 endP)
    {
        float currentTime = 0;
        while (isActive)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= duration)
            {
                currentTime = 0;
                break;
            }

            cylinder.position = Vector3.Lerp(startP, endP, currentTime / duration);
            yield return new WaitForSeconds(5);
            Vector3 temp = scy_s.position;
            scy_e.position = scy_s.position;

        }
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            print("긴급 정지");
            isActive = false;
        }
    }
}


