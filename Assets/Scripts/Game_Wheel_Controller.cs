using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Game_Wheel_Controller : MonoBehaviour
{
    [SerializeField]
    private List<Text> m_txMain = new List<Text>();
    [SerializeField]
    private GameObject m_gmPrefab,m_gmPannel;
    public Level_Sc m_lsCur;
    private string m_strCur;
    [SerializeField] private Game_W m_gameMain;

    public void Sh()
    {
        Rer();
        var l = m_lsCur;
        var ch = l.m_strMainWord.ToCharArray();
        foreach (var c in m_txMain) {


            c.text = "";
            c.GetComponent<Button>().interactable = false;
            c.GetComponent<Button>().onClick.RemoveAllListeners();


         }

        List<char> cr = ch.ToList();
        List<Text> tx = new List<Text>(m_txMain);

        for (int i = 0; i < ch.Length; i++)
        {
            var r = Random.Range(0, cr.Count);
            var rR = Random.Range(0, tx.Count);
            tx[rR].text = cr[r].ToString();
            var rss = cr[r].ToString();
            var b = tx[rR].GetComponent<Button>();

            b.interactable = true;
            b.onClick.AddListener(() => 
            {
                Set(rss);
                b.interactable = false;
            });
            cr.RemoveAt(r);
            tx.RemoveAt(rR);
        }
    }

    public void Start()
    {
    }
    public void Set(string st)
    {
        if (m_gmPannel.transform.childCount >= m_lsCur.m_strMainWord.ToCharArray().Length) return;
        var Sl = Instantiate(m_gmPrefab,m_gmPannel.transform);
        Sl.GetComponentInChildren<Text>().text = st;
        m_strCur += st;
        if (m_gmPannel.transform.childCount > 0)
        {
            m_gmPannel.transform.parent.gameObject.SetActive(true);

        }
    }

    public void Rer()
    {

        m_strCur = "";
        var ct = m_gmPannel.transform.childCount;
        for (int i = 0;i < ct; i++)
        {
            Destroy(m_gmPannel.transform.GetChild(i).gameObject);
        }
        foreach(var t in m_txMain)
        {
            if(t.text != "") t.GetComponent<Button>().interactable = true;
        }
        m_gmPannel.transform.parent.gameObject.SetActive(false);
    }
    public void Ch()
    {
        if (!m_gameMain.Ex(m_strCur))
        {
            Rer();
            m_gameMain.m_inErrol++;
            AudioController.DoVibro();
        }
        else
        {
            m_gameMain.ShowWord(m_strCur.ToLower());
            Rer();
        }
    }

}
