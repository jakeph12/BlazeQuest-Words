using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player_Info
{
    private static bool m_bInit;
    private static void Init()
    {
        if (m_bInit) return;
        m_bInit = true;

        _m_inId = PlayerPrefs.GetInt("IdPlayer", 2);
        _m_inDiamond = PlayerPrefs.GetInt("DiamondPlayer", 20);
        _m_inPower = PlayerPrefs.GetInt("PowerPlayer", 45);
        _m_scrlHeroes = Resources.LoadAll<Heroes_Sc>("Heroes").ToList();


    }

    private static int _m_inId;
    public static int m_inId
    {
        get 
        {
            Init();
            return _m_inId;
        } 
        set
        {
            Init();
            _m_inId = value;
            m_evOnIdCh?.Invoke(_m_inId);
            PlayerPrefs.SetInt("IdPlayer", _m_inId);
        }
    }
    public delegate void OnValueCh(int amount);
    public static event OnValueCh m_evOnIdCh;

    private static int _m_inPower;
    public static OnValueCh m_evOnPowerCh;
    private static int _m_inDiamond;
    public static OnValueCh m_evOnDiamondCh;


    public static int m_inPower
    {
        get 
        {
            Init();
            return _m_inPower;
        }
        set
        {
            Init();
            _m_inPower = value;
            if (_m_inPower > 100) _m_inPower = 100;
            m_evOnPowerCh?.Invoke(_m_inPower);
            PlayerPrefs.SetInt("PowerPlayer", _m_inPower);
        }
    }

    public static int m_inDiamond
    {
        get
        {
            Init();
            return _m_inDiamond;
        }
        set
        {
            Init();
            _m_inDiamond = value;
            m_evOnDiamondCh?.Invoke(_m_inDiamond);
            PlayerPrefs.SetInt("DiamondPlayer", _m_inDiamond);
        }
    }


    private static List<Heroes_Sc> _m_scrlHeroes = new List<Heroes_Sc>();
    public static List<Heroes_Sc> m_scrlHeroes
    {
        get
        {
            Init();
            return _m_scrlHeroes;
        }
    }

}
