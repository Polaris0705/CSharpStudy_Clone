using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Class_Study;

/*
public class Person //생성자
{

    //접근 제어자, 한정자, 지정자, public,private, protected->캡슐화(은닉, 보안, 안정성)
    public string name; //클래스 안에있는 변수 -> 필드(데이터 저장)
    public int age; 


    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }   
    
    //메서드
    //접근지정자(public), 리턴형(void), 클래스 이름(Speak)
    public void Speak()
    {

    }

    public string Speak(string message) //메서드 오버로드: 다형성 예
    {
        return message;
    }
}

public class vehicle
{
    public void Honk()
    {

    }

}

public class car : vehicle
{
    public car() { }
    public void accel()
    {
        this.Honk();
    }
}

public class truck : vehicle
{
    public void br()
    {
        this.Honk();
    }
}

public class seat: car
{
    public void leather()
    {
        this.Honk();
    }
}
*/
public class Class_Study : MonoBehaviour
{   // MonoBehaviour를 상속받은 ClassStudy 
    //Monobegavior(부모 클래스)를 상속받은 classstudy(하위 클래스)
    //C#에서는 상속이 하나밖에 안됨
    // 클래스: (1) 데이터를 저장하기 위한 컨테이너
    //        (2) 기능을 정의하기 위해 사용(캡슐화, 상속, 추상화, 다형성)
    //        (3) 상속의 장점: 코드 재사용, 유지보수 용이 / 다형성 구현 다능

[SerializeField] TMP_InputField vehicleNumberInput;
[SerializeField] Button inBtn;
[SerializeField] Button outBtn;
[SerializeField] TMP_Text carInfo;
[SerializeField] TMP_Text carList;
[SerializeField] Image carImage;

    /*
    Person p1 = new Person("김병철", 40);
    p1.name = "김병철"; //필드에 값을 대입
    p1.age = 40;

    print(p1.Speak("Hello"));//다른 클래스의 메서드를 사용할 수 있음
    car car1 = new car();*/

    //실습2 : 주차장 관리시스템
    //1. Car class -> 차량번호, 입차시간을 필드로 가지는 클래스
    //2. Parkinglot 클래스: Car class를 넣을 수 있는 컬렉션(list, queue, stack)으로 자동차를 관리
    //2-1. 차량 입차, 출차 기능(메서드). 현재 주차된 차량 목록 출력 기능
    // UI- 52가 5345와 같이 차 번호를 inputfield에 입력 시 번호와 입차시간을 가지는 객체 컬렉션
    //-> parkinglot class에 저장됨

    //순서 -> play 버튼을 누르면 start 함수에서 parkinglot class 할당(new)
    // -> 등록 버튼 클릭 시 클릭 이벤트 메서드 실행->parkinglot class의 차량 입차 메서드 실행-> input 내용 기반으로 차량 등록
    //     동시에 현재 주차된 차량 목록 출력(업데이트)

    //5138 입력 후 등록버튼 클릭 -> 차량번호, 입차시간을 가지고있는 carclass를 new로 만듬

    ParkingLot parkingLot;

    void Start()
    {
        parkingLot = new ParkingLot();
        parkingLot.ShowList();
        
    }

    public class Car 
    {
        public string carID;
        public DateTime inTime;

        public Car(string carID, DateTime inTime) 
        {
            carID = this.carID;
            inTime = this.inTime;
        }
    }

    public class ParkingLot
    {
        public List<Car> cars = new List<Car>();
        public List<string> inlists = new List<string>();
        public void CarIn(string carID)
        {
            if(carID == "")
            {
                Debug.Log("자동차 번호를 입력해주세요.");
                return;
            }

            Car car = new Car(carID, DateTime.Now);
            cars.Add(car);
            string login = $"CarID : {car.carID} \n InTime: {car.inTime}";
            inlists.Add(login);
        }
        public void CarOut(string carID)
        {
            if (carID == "")
            {
                Debug.Log("자동차 번호를 입력해주세요.");
                return;
            }
            Car findCar = cars.Find(x => x.carID == carID);
            if(findCar == null)
            {
                Debug.Log("찾으시는 차가 없습니다.");
                return;
            }
            cars.Remove(findCar);
            string logout = $"CarID : {findCar.carID} \n inTime: {findCar.inTime}";
            inlists.Remove(logout);

        }
        public void ShowList() 
        {
            List<Car> list = cars;
            if (list.Count != 0)
            {
                /*
                for (int i = 0; i < list.Count; i++)
                {
                    Car car = list[i];
                    string info = car.carID + " | " + car.inTime;
                    Debug.Log(info);
                    carInfo.text = info;
                }
                */
                foreach (string logs in inlists)
                {
                    Debug.Log($"{ logs }\n");
                }

            }
            else { return; }
        }
    }
    
    public void OnInBtnClickEvent()
    {
        if (parkingLot == null)
        {
            return;
        }
        else
        {
            parkingLot.CarIn(vehicleNumberInput.text);
        }
    }
    public void OnOutBtnClickEvent()
    {
        if (parkingLot == null)
        {
            return;
        }
        parkingLot.CarOut(vehicleNumberInput.text);
    }

    public void Update()
    {
        foreach(string i in parkingLot.inlists)
        {
            carInfo.text = i;
        }
        carList.text += carInfo.text;
    }
}
