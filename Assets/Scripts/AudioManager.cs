using UnityEngine.Audio;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private Sound[] sounds;

    public static AudioManager instance;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        if (instance == null) instance = this;
        else {
            Destroy(gameObject);
            return;
        }
        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }  
    }
    public void Play(string name){
        Sound s = Array.Find(sounds,s => s.name == name);
        if(s == null) return;
        s.source.Play();
    }
    public void Stop(string name){
        Sound s = Array.Find(sounds,s => s.name == name);
        if(s == null) return;
        s.source.Stop();
    }

}
