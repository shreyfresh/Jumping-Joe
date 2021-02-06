using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour
{
    public Sound[] sounds;

    public static MusicPlayer var;

    void Awake(){

        if(var == null){
            var = this;
        }else{
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    void Start(){
        Play("Theme");
    }
    public void Play(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    public void Pause(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Pause();   
    }
    
}
