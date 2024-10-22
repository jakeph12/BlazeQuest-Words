using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Player_Info;

public class MainMenu_W : Interface_W
{
    [SerializeField]
    private Text m_txPower, m_txDiamond;
    [SerializeField]
    private Slider m_slMainPower;
    [SerializeField]
    private Image m_imMain;
    [SerializeField]
    private Interface_W m_wiNotPower;

    public GameObject m_gmDot;

    [SerializeField]
    private Interface_W m_wiTutor;


    public void Start()
    {
        if(PlayerPrefs.GetInt("First",1) == 1)
        {
            m_wiTutor.OpenThis();
            PlayerPrefs.SetInt("First", 0);

        }

        var d = PlayerPrefs.GetInt("Day", -1);
        if (d != DateTime.Now.Day)
            m_gmDot.SetActive(true);
        else
            m_gmDot.SetActive(false);

            if (m_imMain)
        {
            OnIdCh(m_inId);
            m_evOnIdCh += OnIdCh;
            m_acOnDellEnd += () =>
            {
                m_evOnIdCh -= OnIdCh;
            };
        }
        if (m_txDiamond)
        {
            OnDiamond(m_inDiamond);
            m_evOnDiamondCh += OnDiamond;
            m_acOnDellEnd += () =>
            {
                m_evOnDiamondCh -= OnDiamond;
            };
        }
        if (m_txPower)
        {
            OnPower(m_inPower);
            m_evOnPowerCh += OnPower;
            m_acOnDellEnd += () =>
            {
                m_evOnPowerCh -= OnPower;
            };
        }

    }

    private void OnIdCh(int id)
    {
        m_imMain.sprite = m_scrlHeroes[id].m_spIco;
    }
    private void OnDiamond(int id)
    {
        m_txDiamond.text = id.ToString();
    }
    private void OnPower(int power)
    {
        m_txPower.text = power.ToString();
        m_slMainPower.value = power;
    }
    public void Play(Interface_W wi)
    {
        if (m_inPower >= 10)
        {
            OpenOtherW(wi);
            m_inPower -= 10;
        }
        else OpenOtherW(m_wiNotPower);
    }

}
