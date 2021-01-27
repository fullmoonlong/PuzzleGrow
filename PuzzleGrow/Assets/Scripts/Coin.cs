using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    private static Coin Inst = null;

    public Text cointext;
    static int m_coin;

    private void Start()
    {
        Inst = this;
    }

    //가지고 있는 코인 갯수
    public static int GetCoin()
    {
        if (PlayerPrefs.HasKey("Coin"))
            m_coin = PlayerPrefs.GetInt("Coin");
        else
            m_coin = 0;

        return m_coin;
    }

    //value만큼 더하기
    public static void SetCoin(int value)
    {
        if (PlayerPrefs.HasKey("Coin"))
            m_coin = PlayerPrefs.GetInt("Coin");
        else
            m_coin = 0;

        m_coin += value;

        PlayerPrefs.SetInt("Coin", m_coin);
    }

    //value만큼 빼기
    public static void UseCoin(int value)
    {
        if (PlayerPrefs.HasKey("Coin"))
            m_coin = PlayerPrefs.GetInt("Coin");
        else
            m_coin = 0;

        m_coin -= value;
        PlayerPrefs.SetInt("Coin", m_coin);
    }

    //100원씩 돈 더하기
    public void AddCoin()
    {
        if (PlayerPrefs.HasKey("Coin"))
            m_coin = PlayerPrefs.GetInt("Coin");
        else
            m_coin = 0;

        m_coin += 100;

        PlayerPrefs.SetInt("Coin", m_coin);
    }

    //100원씩 돈 더하기
    public void SubCoin()
    {
        if (PlayerPrefs.HasKey("Coin"))
            m_coin = PlayerPrefs.GetInt("Coin");
        else if(!PlayerPrefs.HasKey("Coin"))
            m_coin = 0;

        if(m_coin >= 100)
            m_coin -= 100;

        PlayerPrefs.SetInt("Coin", m_coin);
    }

    void Update()
    {
        if (PlayerPrefs.HasKey("Coin"))
            m_coin = PlayerPrefs.GetInt("Coin");
        cointext.text = "Coin: " + m_coin.ToString();
    }
}
