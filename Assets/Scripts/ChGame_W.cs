using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChGame_W : Interface_W
{
    [SerializeField]
    private GameObject m_gmPrefab,m_gmPanelOfPrefabs;
    [SerializeField]
    private Interface_W m_wiGame;

    public void Start()
    {
        var t = Player_Info.m_scrlHeroes[Player_Info.m_inId].m_lvlAllLevel;
        for(int i = 0; i < t.Count;i++)
        {
            int c = i;
            var n = Instantiate(m_gmPrefab, m_gmPanelOfPrefabs.transform).GetComponent<Slot_Game>();
            var ts = PlayerPrefs.GetInt($"Id{Player_Info.m_inId}Lvl{c}",0);
            bool ou = false;
            if (c == 0)
                ou = true;
            else
            {
                ou = ts == 1;
            }
            n.SetUp(t[c], c+1, () => 
            {
                var tss = OpenWithReturn(m_wiGame).GetComponent<ApplyGame_W>();
                tss.Inits(t[c], c);
                
            }, ou);

        }
    }
}
