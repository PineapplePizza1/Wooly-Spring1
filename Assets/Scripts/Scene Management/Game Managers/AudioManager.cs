using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

//MAY BE OUTDATED WITH UNITY
//MAY NOT WORK WITH UNITY 3D


/*
 * source tutorial
 * https://www.youtube.com/watch?v=6OT43pvUyfY
 * 
 * 
 * WIP: Still need to work on pausing sound, and maybe delete playclone, or a single version, playsingle? 
 * though we honestly can just update what's playing via dbg log, or just what's visible in the AM. maybe display that instead.
 */

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] SoundLoader = null;


    //AudioSource Pool
    public int maxAudioSources = 7;
    private Stack<AudioSource> PlayerStack;
    private List<AudioSource> ActiveRecordPlayers;
    private List<AudioSource> PausedRecordPlayers;

    [SerializeField] private Dictionary<string, Sound> RecordLibrary;

    private bool pausedAllAudio;

    // Use this for initialization
    void Awake()
    {
        RecordLibrary = new Dictionary<string, Sound>();

        //Loading Sounds
        if (SoundLoader != null)
        {
            foreach (Sound s in SoundLoader)
            {
                RecordLibrary[s.name] = s;
            }
        }

        //initialize AudioSources
        //Initialize OptionsList
        PlayerStack = new Stack<AudioSource>();
        ActiveRecordPlayers = new List<AudioSource>();
        for (int i = 0; i < maxAudioSources; i++)
        {
            initAudioSource();
        }

    }

    #region Public Methods (Sound Loading Methods)

    public Sound Find(string name)
    {
        //Dictionary Search
        if (RecordLibrary.TryGetValue(name, out Sound temp))
        {
            return temp;
        }
        else Debug.LogWarning("AUDIOM: Error, Sound" + name + " not Found!");
        return null;

    }

    public void Play(string name)
    {
        Sound play = Find(name);
        if (play != null) PlayAudioSource(play);
    }

    public void Stop(string name)
    {
        Sound play = Find(name);
        if (play != null) unloadSound(play);
    }


    #endregion


    //Region for AudioSource Pooling--------------------------------


    #region Initialize Pooling

    //Set AudioSource Variables
    private void SetSource(AudioSource source, Sound s)
    {
        //Set variables for audio source.
        source.clip = s.clip;
        source.volume = s.volume;
        source.pitch = s.pitch;
        source.loop = s.loop;

    }


    //Create new audio source, add to stack.
    private void initAudioSource()
    {
        AudioSource loading = gameObject.AddComponent<AudioSource>();
        loading.enabled = false;
        PlayerStack.Push(loading);
        
    }

    //Set Audio Source to sound, play.
    private void PlayAudioSource(Sound s)
    {
        if (PlayerStack.Count <= 0) initAudioSource();

        //Switch collections
        AudioSource temp = PlayerStack.Pop();
        ActiveRecordPlayers.Add(temp);

        //set source
        SetSource(temp, s);
        temp.Play();

        //invoke deactivate
        if (!temp.loop) StartCoroutine(AutoEndSource(temp));
    }

    //Automaticcaly unloads source when it's done playing.
    IEnumerator AutoEndSource(AudioSource source)
    {
        while (source.isPlaying || pausedAllAudio || source.time < source.clip.length)
        {
            //yield .1 second so it doesn't break
            yield return new WaitForSeconds(.1f);
        }
        if (!source.isPlaying) unloadSource(source);
    }

    #endregion

    #region Unloading

    //Deactivation by source
    private void unloadSource(AudioSource source)
    {
        int findID = ActiveRecordPlayers.FindIndex(search => search == source);
        ActiveRecordPlayers.RemoveAt(findID);

        //Always stop source.
        if (source.isPlaying)
        {
            Debug.Log("AM: Unloaded source that is playing " + source.clip.name);
            source.Stop();
        }

        PlayerStack.Push(source);
    }

    //Deactivate Sound, only first instance
    private void unloadFirstSound(Sound s)
    {
        int findID = ActiveRecordPlayers.FindIndex(search => search.clip == s.clip);

        //Always stop source.
        ActiveRecordPlayers[findID].Stop();

        PlayerStack.Push(ActiveRecordPlayers[findID]);

        ActiveRecordPlayers.RemoveAt(findID);
    }

    //Deactivate all sources matching a Sound
    private void unloadSound(Sound s)
    {
        for (int i = 0; i < ActiveRecordPlayers.Count; i++)
        {
            if (ActiveRecordPlayers[i].clip == s.clip)
            {
                //Always stop source.
                ActiveRecordPlayers[i].Stop();

                PlayerStack.Push(ActiveRecordPlayers[i]);

                ActiveRecordPlayers.RemoveAt(i);
            }
        }
    }

    //deactivate all sounds
    private void unloadAllSources()
    {
        for(int i = 0; i < ActiveRecordPlayers.Count; i++)
        {
            ActiveRecordPlayers[i].Stop();
            PlayerStack.Push(ActiveRecordPlayers[i]);
            ActiveRecordPlayers.RemoveAt(i);
        }
    }

    #endregion



    #region Pausing

    private void pauseAllSources()
    {
        foreach (AudioSource source in ActiveRecordPlayers)
        {
            source.Pause();
            PausedRecordPlayers.Add(source);
        }
    }

    private void pauseSound(Sound s)
    {
        for (int i = 0; i < ActiveRecordPlayers.Count; i++)
        {
            if (ActiveRecordPlayers[i].clip == s.clip)
            {
                ActiveRecordPlayers[i].Pause();

                PausedRecordPlayers.Add(ActiveRecordPlayers[i]);
            }
        }
    }

    private void unpauseSound(Sound s)
    {
        foreach (AudioSource source in PausedRecordPlayers)
        {
            if (source.clip == s.clip) source.UnPause();
        }
    }

    private void unpauseAllSources()
    {
        foreach (AudioSource source in PausedRecordPlayers)
        {
            source.UnPause();
        }
    }


    #endregion

}

//Wrapper sound class that holds all relevant info to make a sound.
[System.Serializable]
public class Sound
{
    //A class that holds all the information for a sound.

    //Dictionary Key
    public string name;

    //Audio Source Variables.
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;
}