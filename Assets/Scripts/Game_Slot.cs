using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Slot : MonoBehaviour
{
    [SerializeField]
    public Text m_txMain;
    private Image m_imMain;

    private void Awake()
    {
        m_imMain = GetComponent<Image>();
    }


    public void SetL(char ch,Sprite sp)
    {
        m_txMain.text = ch.ToString();
        m_imMain.sprite = sp;
    }
}
