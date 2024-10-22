using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings_W : Interface_W
{
    [SerializeField]
    private Toggle m_tgVibro, m_tgFxs, m_tgMusic;
    void Start()
    {
        m_tgVibro.isOn = AudioController.m_sinThis.m_bVibro;
        m_tgFxs.isOn = AudioController.m_sinThis.m_bFxs;
        m_tgMusic.isOn = AudioController.m_sinThis.m_bMusic;

        m_tgVibro.onValueChanged.AddListener((x) => AudioController.m_sinThis.m_bVibro = x);
        m_tgFxs.onValueChanged.AddListener((x) => AudioController.m_sinThis.m_bFxs = x);
        m_tgMusic.onValueChanged.AddListener((x) => AudioController.m_sinThis.m_bMusic = x);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
