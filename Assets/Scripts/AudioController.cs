using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public static AudioController m_sinThis;
    [SerializeField]
    private AudioSource m_audMusic,m_audFxs;
    [SerializeField]
    private AudioClip m_clClick,m_clMaitThem;

    private bool _m_bVibro,_m_bMusic,_m_bFxs;
    public bool m_bVibro
    {
        get => _m_bVibro;
        set
        {
            _m_bVibro = value;
            PlayerPrefs.SetInt("Vibro", _m_bVibro ? 1 : 0);
        }
    }
    public bool m_bMusic
    {
        get => _m_bMusic;
        set
        {
            _m_bMusic = value;
            m_audMusic.volume = _m_bMusic ? 1 : 0;
            if(_m_bMusic) m_audMusic.Play();
            else m_audMusic.Stop();
            PlayerPrefs.SetInt("Music", _m_bMusic ? 1 : 0);
        }
    }
    public bool m_bFxs
    {
        get => _m_bFxs;
        set
        {
            _m_bFxs = value;
            m_audFxs.volume = _m_bFxs ? 1 : 0;
            PlayerPrefs.SetInt("Fxs", _m_bFxs ? 1 : 0);
        }
    }

    public void Awake()
    {
        m_sinThis = this;
        m_bFxs = PlayerPrefs.GetInt("Fxs", 1) == 1;
        m_audMusic.clip = m_clMaitThem;
        m_bMusic = PlayerPrefs.GetInt("Music", 1) == 1;
        m_bVibro = PlayerPrefs.GetInt("Vibro", 1) == 1;
    }


    public static void DoVibro()
    {
        if(m_sinThis.m_bVibro)
            Handheld.Vibrate();
    }
    public static void PlaySound(AudioClip aud) => m_sinThis.m_audFxs.PlayOneShot(aud);
    public static void PlayMusc(AudioClip aud)
    {
        if(m_sinThis.m_audMusic.isPlaying)
            m_sinThis.m_audMusic.Stop();

        m_sinThis.m_audMusic.clip = aud;

        if (m_sinThis.m_bMusic)
            m_sinThis.m_audMusic.Play();

    }

    public static void PlayClick()
    {
        PlaySound(m_sinThis.m_clClick);
        //DoVibro();
    }
}
