using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Lottery : MonoBehaviour
{
    public GameObject Stuff;
    public GameObject Basket;
    [Space]
    [Space]
    public GameObject[] StraightStuff = new GameObject[10];
    public GameObject Basket_10;

    public GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            StraightStuff[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bright");
            StraightStuff[i].transform.localScale = new Vector3(0.2f, 0.2f, 1f);
        }

        Basket.SetActive(false);
        Basket_10.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Random_Lotto()
    {
        if (PlayerPrefs.GetInt("Coin") >= 100)
        {
            Coin.UseCoin(100);
            Basket.SetActive(true);
            Basket_10.SetActive(false);

            int random = Random.Range(0, 10000);

            Debug.Log(random);

            //확률 - 1성 70%, 2성 25%, 3성 5%
            if (0 <= random && random <= 7000)
            {
                Stuff.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("stuff1");
            }
            else if (7001 <= random && random <= 9500)
            {
                Stuff.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("stuff2");
            }
            else if (9501 <= random && random <= 9999)
            {
                Stuff.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("stuff3");
            }

            Stuff.transform.localScale = new Vector3(0.55f, 0.55f, 1f);
        }

        else
        {
            Panel.SetActive(true);
            Basket.SetActive(false);
        }
    }

    //10연속 뽑기 용
    public void Straight_Random_Lotto()
    {
        if (PlayerPrefs.GetInt("Coin") >= 1000)
        {
            Coin.UseCoin(1000);
            Basket.SetActive(false);
            Basket_10.SetActive(true);

            for (int i = 0; i < 10; i++)
            {
                int random = Random.Range(0, 10000);

                Debug.Log(random);

                //확률 - 1성 70%, 2성 25%, 3성 5%
                if (0 <= random && random <= 7000)
                {
                    StraightStuff[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("stuff1");
                }
                else if (7001 <= random && random <= 9500)
                {
                    StraightStuff[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("stuff2");
                }
                else if (9501 <= random && random <= 9999)
                {
                    StraightStuff[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("stuff3");
                }

                StraightStuff[i].transform.localScale = new Vector3(0.3f, 0.3f, 1f);
            }
        }

        else
        {
            Panel.SetActive(true);
            Basket_10.SetActive(false);
        }
    }
}
