using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName ="New herou",menuName ="Game/New Herou")]
public class Heroes_Sc : ScriptableObject
{
    public string m_strName,m_strDescr;
    public Sprite m_spIco;
    public List<Level_Sc> m_lvlAllLevel = new List<Level_Sc>();
}
