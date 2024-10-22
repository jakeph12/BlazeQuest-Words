using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TypeW 
{
    MainW,
    SecondW,
    CloseW
}

public class Controller_W : MonoBehaviour
{
    public static Controller_W m_sinThis;
    [SerializeField]
    private Transform m_gmMain, m_gmSecond, m_gmNone;

    [HideInInspector]
    public GameObject m_gmOldMain, m_gmOldSecond;

    [SerializeField]
    private Interface_W m_wiMain;

    public void Awake()
    {
        m_sinThis = this;

        if(m_wiMain)
            OpenNW(m_wiMain,TypeW.MainW);
    }



    public static GameObject OpenNW(Interface_W wi,TypeW typeW = TypeW.SecondW,float time = 1f)
    {
       
        Transform cur;
        switch (typeW)
        {
            case TypeW.MainW:
                cur = m_sinThis.m_gmMain;
            break;

            case TypeW.SecondW:
                cur = m_sinThis.m_gmSecond;
                break;

            default:
                cur = m_sinThis.m_gmNone;
                break;
        }

        var Nw = Instantiate(wi.gameObject, cur).GetComponent<Interface_W>();
        Nw.Open(time);



        switch(typeW)
        {
            case TypeW.MainW:
                if (m_sinThis.m_gmOldMain)
                    m_sinThis.m_gmOldMain.GetComponent<Interface_W>().Close(time);
                m_sinThis.m_gmOldMain = Nw.gameObject;
                break;

            case TypeW.SecondW:
                if(m_sinThis.m_gmOldSecond)
                    m_sinThis.m_gmOldSecond.GetComponent<Interface_W>().Close(time);

                m_sinThis.m_gmOldSecond = Nw.gameObject;
                break;
        }

        return Nw.gameObject;

    }
}