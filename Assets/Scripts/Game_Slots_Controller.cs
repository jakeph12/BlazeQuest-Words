using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;

public class Game_Slots_Controller : MonoBehaviour
{
    [SerializeField]
    private GameObject m_gmOredabSlot;
    [SerializeField]
    private string m_strCurWorld;
    [SerializeField]
    private Sprite m_spMain;
    public bool m_bShowed;



    public void SetWord(string st)
    {
        if (st == null || m_strCurWorld.Equals(st) || st.Equals("")) return;

        m_strCurWorld = st;
        var ch = st.ToCharArray();

        for(int i = 0;i < ch.Length; i++)
        {
           Instantiate(m_gmOredabSlot, transform);
        }

    }
    public bool ShowWord()
    {
        if (m_strCurWorld == "" || m_bShowed ) return false;

        m_bShowed = true;
        var ch = m_strCurWorld.ToCharArray();
        for(int i = 0;i < ch.Length; i++)
        {
            transform.GetChild(i).GetComponent<Game_Slot>().SetL(ch[i],m_spMain);
        }
        return true;
    }
    public bool ShowRandom()
    {
        var ch = m_strCurWorld.ToCharArray();
        var rr = Random.Range(0,ch.Length);
        int cou = 0;
        while(transform.GetChild(rr).GetComponent<Game_Slot>().m_txMain.text != "")
        {
            rr = Random.Range(0, ch.Length);
            if (cou >= 6) return false;
        }
        transform.GetChild(rr).GetComponent<Game_Slot>().SetL(ch[rr], m_spMain);
        return true;
    }
}
