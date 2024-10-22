using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_W : Interface_W
{
    [SerializeField]
    private GameObject m_gmPrefabOfPanel, m_gmPanel;
    private Dictionary<string, Game_Slots_Controller> m_dcSlots = new Dictionary<string, Game_Slots_Controller>();
    [SerializeField]
    private Game_Wheel_Controller m_wheelController;
    private Level_Sc m_rcCurLvl;
    private int m_inCurId;
    [SerializeField]
    private Text m_txMainErro,m_txDiamond;
    [SerializeField]
    private Button m_btShowRandom;
    [SerializeField]
    private Interface_W m_wiLose, m_wiWin;
    [SerializeField]
    private Text m_txMain;

    private int _m_inAmount;
    private Image m_imMain;

    private int m_inAmount
    {
        get => _m_inAmount;
        set
        {
            _m_inAmount = value;
            if (m_inAmount >= m_rcCurLvl.m_strWords.Count) Win();
        }
    }
    private int _m_inErrol;
    private int m_inMaxErr;
    public int m_inErrol
    {
        get => _m_inErrol;
        set
        {
            _m_inErrol = value;
            if (_m_inErrol >= m_inMaxErr) Lose();
            m_txMainErro.text = $"{_m_inErrol}/{m_inMaxErr}";
        }
    }


    public void Start()
    {
        AudioController.DoVibro();
        OnDiamondCh(Player_Info.m_inDiamond);

        Player_Info.m_evOnDiamondCh += OnDiamondCh;
        m_acOnDellEnd += () =>
        {

            Player_Info.m_evOnDiamondCh -= OnDiamondCh;

        };
    }

    public void OnDiamondCh(int ch)
    {
        m_txDiamond.text = ch.ToString();
        if (ch < 5) m_btShowRandom.interactable = false;
    }

    public void Inits(Level_Sc lvl,int id)
    {
        m_dcSlots.Clear();
        if(m_imMain == null) m_imMain = GetComponent<Image>();
        m_imMain.sprite = lvl.m_sprIco;
        var cur = lvl;
        m_inCurId = id;
        m_rcCurLvl = lvl;
        m_wheelController.m_lsCur = cur;
        m_inMaxErr = Random.Range(7, 16);
        m_inErrol = 0;
        m_inAmount = 0;
        m_txMain.text = $"Chapter {id+1}: {lvl.m_strNameS}";
        foreach (var item in cur.m_strWords)
        {
            var i = Instantiate(m_gmPrefabOfPanel, m_gmPanel.transform).GetComponent<Game_Slots_Controller>();
            m_dcSlots.Add(item, i);
            i.SetWord(item);
        }
        m_wheelController.Sh();
    }

    public void ShowWord(string word)
    {
        AudioController.DoVibro();
        if (m_dcSlots.ContainsKey(word))
        {
            m_dcSlots[word].ShowWord();
            m_inAmount++;
        }
    }
    public void ShowRandom()
    {
        AudioController.DoVibro();
        var rr = Random.Range(0, m_gmPanel.transform.childCount);
        int cou = 0;
        while (m_gmPanel.transform.GetChild(rr).GetComponent<Game_Slots_Controller>().m_bShowed)
        {
            rr = Random.Range(0, m_gmPanel.transform.childCount);
            cou++;
            if (cou >= 6) return;
        }
        if(m_gmPanel.transform.GetChild(rr).GetComponent<Game_Slots_Controller>().ShowRandom())
            Player_Info.m_inDiamond -= 5;
        if (Player_Info.m_inDiamond < 5) m_btShowRandom.interactable = false;
    }
    public bool Ex(string st)
    {
        var r = st.ToLower();
        if (!m_dcSlots.ContainsKey(r) || m_dcSlots[r].m_bShowed) return false;



        return true;
    }
    private void Lose()
    {
        AudioController.DoVibro();
        m_gameBlock.SetActive(true);
        var o = m_wiLose.OpenThis(1,TypeW.CloseW).GetComponent<You_Lose_w>();
        o.Inits(() =>
        {
            var t = m_gmPanel.transform.childCount;
            for (int i = 0; i < t; i++)
            {
                Destroy(m_gmPanel.transform.GetChild(i).gameObject);

            }
            if (Player_Info.m_inPower < 10) Close(1f);
            else
            {
                Inits(m_rcCurLvl, m_inCurId);
                m_gameBlock.SetActive(false);
                Player_Info.m_inPower -= 10;
            }

        });

    }
    private void Win()
    {
        AudioController.DoVibro();
        OpenOtherWN(m_wiWin);
        PlayerPrefs.SetInt($"Id{Player_Info.m_inId}Lvl{m_inCurId+1}", 1);
        Player_Info.m_inDiamond += 10;
    }
}
