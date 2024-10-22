using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class You_Lose_w : Pause_W
{
    private Action m_acCallback;
    public void Inits(Action ac)
    {
        m_acCallback = ac;
    }
    public void Closee()
    {
        m_acCallback?.Invoke();
        Close(1f);
    }
}
