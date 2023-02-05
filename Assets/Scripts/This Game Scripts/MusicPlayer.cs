using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer Instance;
    public AudioClip sound;

    public AudioSource gameAudio;

    void Start()
    {
        Debug.Log("Play song");
        playSongLoop();
    }

    void playSongLoop()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        gameAudio.clip = sound;
        gameAudio.Play();
        Invoke("PlaySongLoop", gameAudio.clip.length);   
    }
    void Awake()
    {
        this.InstantiateController();
    }

    private void InstantiateController() {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if(this != Instance) {
            Destroy(this.gameObject);
        }
    }
}

