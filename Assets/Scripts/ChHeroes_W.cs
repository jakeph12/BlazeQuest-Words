using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChHeroes_W : Interface_W
{

    [SerializeField]
    private Image m_imMain;
    [SerializeField]
    private Text m_txDescr,m_strName;
    [SerializeField]
    private Image[] m_immAllSlot;
    [SerializeField]
    private Sprite m_spActive,m_spDesactive;

    private int _m_inMain = -1;
    private int m_inMain
    {
        get => _m_inMain;
        set
        {
            if(_m_inMain != -1)
            {
                m_immAllSlot[_m_inMain].sprite = m_spDesactive;
            }
            _m_inMain = value;
            m_immAllSlot[_m_inMain].sprite = m_spActive;
            m_imMain.sprite = Player_Info.m_scrlHeroes[_m_inMain].m_spIco;
            m_txDescr.text = Player_Info.m_scrlHeroes[_m_inMain].m_strDescr;
            m_strName.text = Player_Info.m_scrlHeroes[_m_inMain].m_strName;

        }
    }

    public void Start()
    {
        m_inMain = Player_Info.m_inId;
    }


    public void Setin(int i)=> m_inMain = i;

    public override void Close(float time)
    {
        Player_Info.m_inId = m_inMain;
        base.Close(time);
    }

}
