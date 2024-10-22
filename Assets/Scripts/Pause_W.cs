using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_W : Interface_W
{
    public void ToMainMenu()
    {
        Controller_W.m_sinThis.m_gmOldSecond.GetComponent<Interface_W>().Close(1f);
        Close(1f);
    }
}
