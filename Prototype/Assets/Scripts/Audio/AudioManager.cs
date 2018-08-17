using System;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    #region Persistent Singleton

    public static AudioManager m_Instance;

    private void Awake()
    {
        if(m_Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            m_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    #endregion

    [Header("Volume")]
    [SerializeField]
    private float m_MainVolume = 1.0f;

    [SerializeField]
    private float m_MusicVolume = 1.0f;

    [SerializeField]
    private float m_SoundVolume = 1.0f;

    [SerializeField]
	private AudioMixerGroup m_Mixer;

    [Header("Sound effects")]
    [SerializeField]
    private Sound[] m_Sounds;

    [Header("Music")]
    [SerializeField]
    private Music[] m_Music;

    private void Start()
    {
        foreach(Sound sound in m_Sounds)
        {
            sound.SetSource(gameObject.AddComponent<AudioSource>());
            sound.GetSource().clip = sound.GetClip();
            sound.GetSource().loop = sound.GetLoop();
            sound.GetSource().outputAudioMixerGroup = m_Mixer;
        }

        foreach(Music music in m_Music)
        {
            music.SetSource(gameObject.AddComponent<AudioSource>());
            music.GetSource().clip = music.GetClip();
            music.GetSource().loop = music.GetLoop();
            music.GetSource().outputAudioMixerGroup = m_Mixer;
        }
    }

    public void PlaySound(string a_Name)
    {
        Sound sound = Array.Find(m_Sounds, item => item.GetName() == a_Name);

        if(sound == null)
        {
            Debug.LogWarning("Sound: " + name + " was not found!");
            return;
        }

        if(sound.GetScenes().Count > 0)
        {
            if(sound.GetScenes().Contains("") == false && sound.GetScenes().Contains(SceneManager.GetActiveScene().name) == false)
            {
                Debug.LogWarning("Music: " + name + " was not set for this scene!");

                return;
            }

            return;
        }

        sound.GetSource().volume = sound.GetVolume() * m_MainVolume * m_SoundVolume * (1.0f + UnityEngine.Random.Range(-sound.GetVolumeVariance() / 2.0f, sound.GetVolumeVariance() / 2.0f));
        sound.GetSource().pitch = sound.GetVolume() * (1.0f + UnityEngine.Random.Range(-sound.GetPitchVariance() / 2.0f, sound.GetPitchVariance() / 2.0f));
        sound.GetSource().Play();

        Debug.Log("AudioManager: now playing " + sound.GetName());
    }

    public void PlayMusic(string a_Name)
    {
        Music music = Array.Find(m_Music, item => item.GetName() == a_Name);

        if(music == null)
        {
            Debug.LogWarning("Music: " + name + " was not found!");

            return;
        }

        if(music.GetScenes().Count > 0)
        {
            if(music.GetScenes().Contains("") == false && music.GetScenes().Contains(SceneManager.GetActiveScene().name) == false)
            {
                Debug.LogWarning("Music: " + name + " was not set for this scene!");

                return;
            }

            return;
        }

        music.GetSource().volume = music.GetVolume() * m_MainVolume * m_MusicVolume * (1.0f + UnityEngine.Random.Range(-music.GetVolumeVariance() / 2.0f, music.GetVolumeVariance() / 2.0f));
        music.GetSource().pitch = music.GetVolume() * (1.0f + UnityEngine.Random.Range(-music.GetPitchVariance() / 2.0f, music.GetPitchVariance() / 2.0f));
        music.GetSource().Play();

        Debug.Log("AudioManager: now playing " + music.GetName());
    }

    public void UpdateSoundVolume()
    {
        foreach(Sound item in m_Sounds)
        {
            item.GetSource().volume = item.GetVolume() * m_MainVolume * m_SoundVolume * (1.0f + UnityEngine.Random.Range(-item.GetVolumeVariance() / 2.0f, item.GetVolumeVariance() / 2.0f));
        }
    }

    public void UpdateMusicVolume()
    {
        foreach(Music item in m_Music)
        {
            item.GetSource().volume = item.GetVolume() * m_MainVolume * m_MusicVolume * (1.0f + UnityEngine.Random.Range(-item.GetVolumeVariance() / 2.0f, item.GetVolumeVariance() / 2.0f));
        }
    }

    public void SetMainVolume(float a_Volume)
    {
        m_MainVolume = a_Volume;
        UpdateSoundVolume();
        UpdateMusicVolume();
    }

    public void SetSoundVolume(float a_Volume)
    {
        m_SoundVolume = a_Volume;
        UpdateSoundVolume();
    }

    public void SetMusicVolume(float a_Volume)
    {
        m_MusicVolume = a_Volume;
        UpdateMusicVolume();
    }

    public void SetMainVolume(Slider a_Slider)
    {
        m_MainVolume = a_Slider.value;
        UpdateSoundVolume();
        UpdateMusicVolume();
    }

    public void SetSoundVolume(Slider a_Slider)
    {
        m_SoundVolume = a_Slider.value;
        UpdateSoundVolume();
    }

    public void SetMusicVolume(Slider a_Slider)
    {
        m_MusicVolume = a_Slider.value;
        UpdateMusicVolume();
    }

    public Sound[] GetSounds()
    {
        return m_Sounds;
    }

    public Sound GetRandomSound()
    {
        int id = UnityEngine.Random.Range(0, m_Sounds.Length);

        return m_Sounds[id];
    }

    public Music[] GetMusic()
    {
        return m_Music;
    }

    public Music GetRandomMusic()
    {
        int id = UnityEngine.Random.Range(0, m_Music.Length);

        return m_Music[id];
    }
}