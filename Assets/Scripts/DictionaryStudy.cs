using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Dictionary study
/// - 실습 : 책 내용을 미리 등록한 후, 책의 정보를 이용하여 책을 검색하는 도서검색 서비스
/// (1) 5권 정도 책 등록(자료명, 도서위치(0.0)~)
/// (2) Library Dictionary
///      - 책 제목 또는 위치를 입력하여 도서 등록->검색해 결과 출력
///      /// </summary>
/// 
// 퓨어클래스 - 책의 정보를 담는 컨테이너 클래스
public class DictionaryStudy : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public InputField input;
    public InputField input_t;
    public InputField input_l;
    public Text output_main;
    public Text output_bookList;
    public Text output_search;
    public GameObject panel_main;
    public GameObject panel_register;
    public GameObject panel_search;
    public Button searchBtn;
    public Button registerBtn;


    Dictionary<string, string> library = new Dictionary<string, string>();

    public void Start()
    {
        panel_main.SetActive(true);
        panel_search.SetActive(false);
        panel_register.SetActive(false);
        output_main.text = "원하시는 기능을 선택해주세요.";
    }

    // Start is called before the first frame update
    public void RegisterBook()
    {
        panel_main.SetActive(false);
        panel_search.SetActive(false);
        panel_register.SetActive(true);

        string title = input_t.text;
        string location = input_l.text;

        if (title == "" || location == "")
        {
            return;
        }

        library.Add(location, title);
        foreach(KeyValuePair<string, string> pair in library)
        {
            string input_list = $"\n{title} | {location}\n";
            output_bookList.text += input_list;
        }


    }

    public void SearchBook()
    {
        panel_main.SetActive(false);
        panel_search.SetActive(true);
        panel_register.SetActive(false);
        input.text = "";
        input_t.text = "";
        input_l.text = "";
        output_main.text = "";

        string title = "";
        string location = "";

        switch (dropdown.value)
        {
            case 0:
            title = input.text;
                if (title == "")
                {
                    return;
                }
                if(library.ContainsKey(title))
                {
                    location = library[title];
                    output_search.text = $"{title}은 {location}에 있습니다.";
                }
                else
                {
                    output_search.text = "존재하지 않는 도서명입니다.";
                }
                    break;
            case 1:
                location = input.text;
                if(location == "")
                {
                    return;
                }
                if(library.ContainsValue(location))
                {
                    string key = library.FirstOrDefault(x => x.Key == location).Key;
                    output_search.text = $"{key}은 {location}에 있습니다.";
                }
                else
                {
                    output_search.text += "해당 위치에는 도서가 존재하지 않습니다.";
                }
                break;
        }
    }
}
