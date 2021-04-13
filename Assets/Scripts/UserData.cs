using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New User Data", menuName = "User Data")]
public class UserData : ScriptableObject
{
    [SerializeField]
    private string m_userName;

    [SerializeField]
    private string m_currency;

    [SerializeField]
    private int m_coins;

    public string UserName
    {
        get
        {
            return m_userName;
        }

        set
        {
            m_userName = value;
        }
    }


    public string Currency
    {
        get
        {
            return m_currency;
        }
        set
        {
            m_currency = value;
        }
    }

    public int Coins
    {
        get
        {
            return m_coins;
        }

        set
        {
            m_coins = value;
        }
    }

}
