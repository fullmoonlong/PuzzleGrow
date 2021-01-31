using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnOff : MonoBehaviour
{
    //추가창 넣을 것들
    public GameObject MenuSet;
    //public GameObject MenuTuto;
    //public GameObject MenuGame;

    //public AudioSource audioSource;

    //public Text musictext;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    musictext.text = "Music ON";
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    //메뉴 온오프
    public void OnClickMenu()
    {
        //SoundScript.Inst.ClickMenu();
        if (MenuSet.activeSelf)
        {
            MenuSet.SetActive(false);
        }
        else
        {
            MenuSet.SetActive(true);
        }
    }

    ////노래 온오프
    //public void OnClickMusic()
    //{
    //    SoundScript.Inst.ClickMenu();
    //    if (audioSource.isPlaying)
    //    {
    //        audioSource.Pause();
    //        musictext.text = "Music OFF";
    //    }

    //    else
    //    {
    //        audioSource.Play();
    //        musictext.text = "Music ON";
    //    }
    //}

    ////나가기
    //public void OnClickExit()
    //{
    //    SoundScript.Inst.ClickMenu();
    //    Application.Quit();
    //}

    ////튜토 온오프
    //public void OnClickTuto()
    //{
    //    SoundScript.Inst.ClickMenu();
    //    if (MenuTuto.activeSelf)
    //    {
    //        MenuTuto.SetActive(false);
    //    }
    //    else
    //    {
    //        MenuTuto.SetActive(true);
    //    }
    //}

    ////게임 온오프
    //public void OnClickGame()
    //{
    //    SoundScript.Inst.ClickMenu();
    //    if (MenuGame.activeSelf)
    //    {
    //        MenuGame.SetActive(false);
    //    }
    //    else
    //    {
    //        MenuGame.SetActive(true);
    //    }
    //}

    public void OnClickAnimal()
    {
        //클릭한 버튼의 텍스트가 뭐일경우
      
        //클릭한 버튼 오브젝트
        GameObject tempBtn = EventSystem.current.currentSelectedGameObject;

        switch (tempBtn.transform.GetChild(0).GetComponent<Text>().text)
        {
            case "Dog":
                {
                    print("강아지가 생성되었습니다.");
                    //AnimalScript Dog = new AnimalScript();
                    //Dog.m_type = "Dog";
                    //Dog.m_level = 1;
                    //Dog.m_hungry = 0;
                    //Dog.m_happy = 100;
                    //Dog.m_clean = 100;
                    //AnimalList.Add(Dog);
                    break;
                }

            case "Bird":
                {
                    print("새가 생성되었습니다.");
                    //AnimalScript Bird = new AnimalScript();
                    //Bird.m_type = "Bird";
                    //Bird.m_level = 1;
                    //Bird.m_hungry = 0;
                    //Bird.m_happy = 100;
                    //Bird.m_clean = 100;
                    //AnimalList.Add(Bird);
                    break;
                }

            case "Cat":
                {
                    print("고양이가 생성되었습니다.");
                    //AnimalScript Cat = new AnimalScript();
                    //Cat.m_type = "Cat";
                    //Cat.m_level = 1;
                    //Cat.m_hungry = 0;
                    //Cat.m_happy = 100;
                    //Cat.m_clean = 100;
                    //AnimalList.Add(Cat);
                    break;
                }

        }

    }
}
