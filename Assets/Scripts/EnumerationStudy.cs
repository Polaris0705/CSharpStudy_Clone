using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumerationStudy : MonoBehaviour
{
    enum Days 
    {
        Mon, Tue, Wed, Thu, Fri, Sat, Sun
    }
    Days day = Days.Mon;

    enum CoffeeSize
    {
        Shorts, Tall, Grande, Venti
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (day)
            {
                case Days.Mon:
                    break;
                case Days.Tue:
                    break;
                case Days.Wed:
                    break;
                case Days.Thu:
                    break;
                case Days.Fri:
                    break;
                case Days.Sat:
                    break;
                case Days.Sun:
                    break;

            }
        }
    }
}