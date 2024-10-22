using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS.Xcode;
using UnityEngine;
using UnityEngine.UI;

public class ApplyGame_W : Interface_W
{

    [SerializeField]
    private Button m_btNewGame;
    [SerializeField]
    private Text m_txMain;
    [SerializeField]
    private Image m_imMain;
    [SerializeField]
    private Interface_W m_wiGame;

    public void Start()
    {
        m_imMain.sprite = Player_Info.m_scrlHeroes[Player_Info.m_inId].m_spIco;
    }


    public void Inits(Level_Sc lvl,int id)
    {
        m_txMain.text = $"Chapter {id + 1}: {lvl.m_strNameS}";
        m_btNewGame.onClick.AddListener(() =>
        {
            var n = OpenWithReturn(m_wiGame).GetComponent<Game_W>();
            n.Inits(lvl, id);
        });
    }



}
