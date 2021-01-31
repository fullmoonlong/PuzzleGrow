using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//list를 바로 저장할 수 없어서 만듬
[System.Serializable]
public class Serialization<T>
{
    public Serialization(List<T> _target) => target = _target;
    public List<T> target;
}


[System.Serializable]
public class Animal
{
    public Animal(string _Type, string _Name, string _Level, string _Hungry, string _Happy, string _Clean, bool _IsHaving)
    {
        Type = _Type; Name = _Name; Level = _Level; Hungry = _Hungry; Happy = _Happy; Clean = _Clean; IsHaving = _IsHaving;
    }
    public string Type, Name, Level, Hungry, Happy, Clean;
    public bool IsHaving;
}

public class AnimalScript : MonoBehaviour
{
    public TextAsset AnimalDatabase;
    public List<Animal> AllAnimalList, CurAnimalList, MyAnimalList;
    public string curType = "Dog";

    string filePath;

    public Text m_type;
    public Text m_hungry;
    public Text m_happy;
    public Text m_clean;
    public Text m_level;
    int AnimalCount = 0;

    void Start()
    {
        //storedatabase에 있는 텍스트를 allitemlist에 대입
        string[] line = AnimalDatabase.text.Substring(0, AnimalDatabase.text.Length - 1).Split('\n');
        for (int i = 0; i < line.Length; i++)
        {
            string[] row = line[i].Split('\t');

            AllAnimalList.Add(new Animal(row[0], row[1], row[2], row[3], row[4], row[5], row[6] == "TRUE"));
        }
        filePath = Application.persistentDataPath + "/AllAnimal.txt";
        print(filePath);
        LoadFile();
    }

    void Update()
    {
        print(AnimalCount);
        MyAnimalList = AllAnimalList.FindAll(x => x.IsHaving);
        if (MyAnimalList != null && m_hungry!= null && m_happy != null && m_clean != null && MyAnimalList.Count != 0)
        {
            m_type.text = "종류 : " + MyAnimalList[AnimalCount].Type.ToString();
            m_level.text = "레벨 : " + MyAnimalList[AnimalCount].Level.ToString();
            m_hungry.text = "배고픔 : " + MyAnimalList[AnimalCount].Hungry.ToString();
            m_happy.text = "행복 : " + MyAnimalList[AnimalCount].Happy.ToString();
            m_clean.text = "청결 : " + MyAnimalList[AnimalCount].Clean.ToString();
        }
    }

    public void NextBtn()
    {
        AnimalCount += 1;
        if (AnimalCount >= MyAnimalList.Count)
        {
            AnimalCount = 0;
        }
    }

    public void BackBtn()
    {
        AnimalCount -= 1;
        if (AnimalCount < 0)
        {
            AnimalCount = MyAnimalList.Count - 1;
        }
    }
    public void TabAnimalMenu()
    {
        print("click");
        GameObject tempBtn = EventSystem.current.currentSelectedGameObject;

        switch (tempBtn.transform.GetChild(0).GetComponent<Text>().text)
        {
            case "Dog":
                {
                    print("강아지가 생성되었습니다.");
                    CurAnimalList = AllAnimalList.FindAll(x => x.Type == "Dog");
                    CurAnimalList[0].IsHaving = true;
                    SaveFile();
                    break;
                }

            case "Bird":
                {
                    print("새가 생성되었습니다.");
                    CurAnimalList = AllAnimalList.FindAll(x => x.Type == "Bird");
                    CurAnimalList[0].IsHaving = true;
                    SaveFile();
                    break;
                }

            case "Cat":
                {
                    print("고양이가 생성되었습니다.");
                    CurAnimalList = AllAnimalList.FindAll(x => x.Type == "Cat");
                    CurAnimalList[0].IsHaving = true;
                    SaveFile();
                    break;
                }

        }
    }
    void SaveFile()
    {
        //MyCollectionList 직렬화
        string jdata = JsonUtility.ToJson(new Serialization<Animal>(AllAnimalList));
        File.WriteAllText(filePath, jdata);

        //TabItemMenu(curStoreType);
        //TabCollectionMenu(curCollectionType);
    }

    void LoadFile()
    {
        if (!File.Exists(filePath))
        {
            ResetItem();
        }
        string jdata = File.ReadAllText(filePath);

        AllAnimalList = JsonUtility.FromJson<Serialization<Animal>>(jdata).target;
    }

    public void ResetItem()
    {
        string jdata = JsonUtility.ToJson(new Serialization<Animal>(AllAnimalList));
        File.WriteAllText(filePath, jdata);
        LoadFile();
    }
}
