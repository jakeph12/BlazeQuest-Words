using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Lvl", menuName = "Game/New Lvl")]
public class Level_Sc : ScriptableObject
{
    public string m_strNameS;
    public Sprite m_sprIco;
    public string m_strMainWord;
    public List<string> m_strWords = new List<string>();
}
