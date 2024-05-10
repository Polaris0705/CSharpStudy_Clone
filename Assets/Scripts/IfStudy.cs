using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class IfStudy : MonoBehaviour
{
    public TMP_Text mainText;
    public TMP_Text subText;
    public string num_oper;
    public string temp;
    public double res;
    List<double> numbers = new List<double>();
    List<string> opers = new List<string>();
    void Start()
    {
        mainText.text = null;
        subText.text = null;
    }
    //함수의 종류

    public void OnCBtnCllick()
    {
        mainText.text = null;
        subText.text = null;
        numbers.Clear();
        opers.Clear();
    }
    public void OnNumButtonClickEvent(string num)
    {

        mainText.text += num;
        subText.text += num;
    }

    public void OnOperButtonClickEvent(string oper)
    {
        subText.text = $"{mainText.text}{oper}";
        opers.Add(oper);
        mainText.text = temp;
    }

    public void OnCalButtonClickEvent()
    {
        char[] oper = {'+','-','*','/'};
        string[] nums = subText.text.Split(oper);

        for (int i = 0; i < nums.Length; i++)
        {
            numbers.Add(double.Parse(nums[i]));
        }
        num_oper = opers[0];
        switch (num_oper)
        {
            case "+":
                res = double.Parse(nums[0])+ double.Parse(nums[1]);
                break;
            case "-":
                res = double.Parse(nums[0]) - double.Parse(nums[1]);
                break;
            case "*":
                res = double.Parse(nums[0]) * double.Parse(nums[1]);
                break;
            case "/":
                res = double.Parse(nums[0]) / double.Parse(nums[1]);
                break;
        }
        subText.text = $"{subText.text}={res}";
        mainText.text = res.ToString();
    }
}