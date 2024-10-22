using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Interface_W : MonoBehaviour
{
    private CanvasGroup m_cvGroop;
    [SerializeField] protected GameObject m_gameBlock;
    public Action m_acOnInitBegin, m_acOnInitEnd, m_acOnDellBegin, m_acOnDellEnd;



    public void Awake()
    {
        m_gameBlock.SetActive(true);
        m_cvGroop = GetComponent<CanvasGroup>();
    }

    public virtual GameObject OpenThis(float time = 1f, TypeW typeW = TypeW.SecondW) => Controller_W.OpenNW(this, typeW, time);

    public virtual void Open(float time)
    {
        m_acOnInitBegin?.Invoke();
        if (m_gameBlock)
            m_gameBlock.SetActive(true);
        m_cvGroop.alpha = 0;
        m_cvGroop.DOFade(1, time).OnComplete(() => {
            m_gameBlock.SetActive(false);
            m_acOnInitEnd?.Invoke();
        });
    }
    public virtual void Close(float time)
    {
        AudioController.PlayClick();
        if (m_gameBlock)
            m_gameBlock.SetActive(true);
        m_acOnDellBegin?.Invoke();
        m_cvGroop.DOFade(0, time).OnComplete(() => {
            m_acOnDellEnd?.Invoke();
            Destroy(gameObject);
        });
    }
    public virtual void OpenOtherW(Interface_W wi)
    {
        AudioController.PlayClick();
        if (m_gameBlock)
            m_gameBlock.SetActive(true);
        var t = wi.OpenThis(1f).GetComponent<Interface_W>();
        t.m_acOnDellEnd += () =>
        {
            if (m_gameBlock)
                m_gameBlock.SetActive(false);
        };
    }
    public virtual void OpenOtherWN(Interface_W wi)
    {
        AudioController.PlayClick();
        if (m_gameBlock)
            m_gameBlock.SetActive(true);
        var t = wi.OpenThis(1f,TypeW.CloseW).GetComponent<Interface_W>();
        t.m_acOnDellEnd += () =>
        {
            if (m_gameBlock)
                m_gameBlock.SetActive(false);
        };
    }

    public virtual GameObject OpenWithReturn(Interface_W wi)
    {
        AudioController.PlayClick();
        if (m_gameBlock)
            m_gameBlock.SetActive(true);
        var t = wi.OpenThis(1f).GetComponent<Interface_W>();
        t.m_acOnDellEnd += () =>
        {
            if (m_gameBlock)
                m_gameBlock.SetActive(false);
        };
        return t.gameObject;
    }
}
