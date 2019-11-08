using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip start_main_BGM;

    private static SoundManager instance = null;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(SoundManager)) as SoundManager;

                if (instance == null)
                {
                    Debug.LogError("SoundManager is not exist in this game");
                }
            }

            return instance;
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBackgroundSound(string soundName, bool isLoop)
    {
        audioSource.Stop();
        audioSource.clip = Soundlist(soundName);
        audioSource.loop = isLoop;
        audioSource.time = 0f;
        audioSource.Play();
    }

    public void PlayEffectSound(string soundName)
    {
        audioSource.PlayOneShot(Soundlist(soundName));
    }

    public void setVolume(float volume)
    {
        audioSource.volume = volume;
    }

    private AudioClip Soundlist(string soundName)
    {
        AudioClip findedSound;
        switch (soundName)
        {
            case "start_main_BGM":
                findedSound = start_main_BGM;
                break;
            default:
                findedSound = start_main_BGM;
                break;
        }
        return findedSound;
    }
}
