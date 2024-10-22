using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Slot_Game : MonoBehaviour
{
    private Button m_btMain;
    [SerializeField]
    private GameObject m_gmLock;
    [SerializeField]
    private Image m_imMain;
    [SerializeField]
    private Text m_txLabel;

    public void Awake()
    {
        m_btMain = GetComponent<Button>();
    }
    public void SetUp(Level_Sc lvl,int index,UnityAction ac,bool active = true)
    {
        if (active)
        {
            m_btMain.onClick.AddListener(ac);
            m_btMain.interactable = true;
            m_gmLock.SetActive(false);

        }
        else
        {
            m_btMain.interactable = false;
            m_gmLock.SetActive(true);
        }
        m_imMain.sprite = lvl.m_sprIco;
        m_txLabel.text = $"Level - {index}";
    }

}
