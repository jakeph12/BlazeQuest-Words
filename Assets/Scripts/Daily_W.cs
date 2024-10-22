using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Daily_W : Interface_W
{
    [SerializeField]
    private Button m_btMain;
    [SerializeField]
    private List<Image> m_imlsAllSp = new List<Image>();

    private int[] m_inmAmountP =
    {
        20,
        5,
        5
    };

    void Start()
    {
        var d = PlayerPrefs.GetInt("Day",-1);
        if(d != DateTime.Now.Day)
            m_btMain.onClick.AddListener(Roll);
        else
            Non();
    }
    private void Roll()
    {
        AudioController.PlayClick();
        m_btMain.onClick.RemoveListener(Roll);
        m_btMain.interactable = false;
        var r = UnityEngine.Random.Range(0,m_imlsAllSp.Count);
        PlayerPrefs.SetInt("Day", DateTime.Now.Day);
        m_imlsAllSp[r].DOFade(1, 1f).OnComplete(() =>
        {
            Player_Info.m_inPower += m_inmAmountP[r];
            Controller_W.m_sinThis.m_gmOldMain.GetComponent<MainMenu_W>().m_gmDot.SetActive(false);
            Non();
        });
    }
    private bool m_bPlaing;
    public void Non()
    {
        m_btMain.GetComponentInChildren<Text>().text = $"Continue";
        m_btMain.interactable = true;
        m_btMain.onClick.AddListener(() => Close());

    }
    public override void Close(float time = 1f)
    {
        if (m_bPlaing) return;
        base.Close(time);
    }
}
