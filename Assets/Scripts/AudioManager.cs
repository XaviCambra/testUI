using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        if(instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InitializeMusic(FModEvents.instance.music);
    }

    private EventInstance musicEventInstance;

    public void PlayOneShot(EventReference sound)
    {
        RuntimeManager.PlayOneShot(sound);
    }

    public void PlayOneShot(string sound)
    {
        RuntimeManager.PlayOneShot(sound);
    }

    void InitializeMusic(EventReference musicEventReference)
    {
        musicEventInstance = CreateInstance(musicEventReference);
        OnOffMusic();
    }

    bool m_MusicPlaying = false;

    public void OnOffMusic()
    {
        if (m_MusicPlaying)
            musicEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        else
            musicEventInstance.start();
        m_MusicPlaying = !m_MusicPlaying;
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }
}
