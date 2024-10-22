using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutro_W : Interface_W
{
    public override void OpenOtherWN(Interface_W wi)
    {
        base.OpenOtherWN(wi);

        Close(1f);
    }
}
