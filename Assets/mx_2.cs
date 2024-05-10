using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ActUtlType64Lib;
using JetBrains.Annotations;
using TMPro;
using UnityEngine.UI; //mxcomponent library 사용

public class mx_2 : MonoBehaviour
{
    public Button pb1;
    public Transform cyA;
    public Transform cyA_S;
    public Transform cyA_E;
    public Transform cyB;
    public Transform cyB_S;
    public Transform cyB_E;
    public GameObject CoroutineStudy;
    public int Y0 = 0;
    public int Y1 = 0;
    public int Y2 = 0;
    public int Y3 = 0;

    enum Connection
    {
        Connected,
        Disconnected,
    }

    ActUtlType64 mxComponent;
    Connection connection = Connection.Disconnected;

    void Start()
    {
        mxComponent = new ActUtlType64();
        mxComponent.ActLogicalStationNumber = 1;
    }

/*    IEnumerator CoListener()
    {   while(true) 
        {
            Y0 = GetDevice("Y0");
            Y1 = GetDevice("Y1");
            Y2 = GetDevice("Y2");
            Y3 = GetDevice("Y3");

            yield return WaitForSeconds(Time.deltaTime);
        }
    }

    IEnumerator CoRunIPS()
    {
        while(true)
        {
            if(Y0 == 1)
            {
                yield return StartCoroutine(MoveCyl(cyA, cyA_S, cyA_E, 2));
            }
        }
    }*/

}

