using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    [SerializeField]
    protected string m_Name;

    [SerializeField]
    protected AudioClip m_Clip;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    protected float m_Volume = 0.75f;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    protected float m_VolumeVariance = 0.1f;

    [SerializeField]
    [Range(0.1f, 3.0f)]
    protected float m_Pitch = 1.0f;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    protected float m_PitchVariance = 0.1f;

    [SerializeField]
    protected List<string> m_Scenes;

    protected AudioMixerGroup m_Mixer;
    protected AudioSource m_Source;

    public Sound()
    {

    }

    public Sound(string a_Name, float a_Volume, float a_Pitch, string a_Scene, AudioMixerGroup a_Mixer, AudioSource a_Source)
    {
        m_Name = a_Name;
        m_Volume = a_Volume;
        m_Pitch = a_Pitch;
        m_Scenes.Add(a_Scene);
        m_Mixer = a_Mixer;
        m_Source = a_Source;
    }

    public void SetName(string a_Name)
    {
        m_Name = a_Name;
    }

    public void SetVolume(float a_Volume)
    {
        m_Volume = a_Volume;
    }

    public void SetVolumeVariance(float a_Variance)
    {
        m_VolumeVariance = a_Variance;
    }

    public void SetPitch(float a_Pitch)
    {
        m_Pitch = a_Pitch;
    }

    public void SetPitchVariance(float a_Variance)
    {
        m_PitchVariance = a_Variance;
    }

    public void SetMixer(AudioMixerGroup a_Mixer)
    {
        m_Mixer = a_Mixer;
    }

    public void SetSource(AudioSource a_Source)
    {
        m_Source = a_Source;
    }

    public string GetName()
    {
        return m_Name;
    }

    public float GetVolume()
    {
        return m_Volume;
    }

    public float GetVolumeVariance()
    {
        return m_VolumeVariance;
    }

    public float GetPitch()
    {
        return m_Pitch;
    }

    public float GetPitchVariance()
    {
        return m_PitchVariance;
    }

    public List<string> GetScenes()
    {
        return m_Scenes;
    }

    public AudioClip GetClip()
    {
        return m_Clip;
    }

    public AudioSource GetSource()
    {
        return m_Source;
    }
}
