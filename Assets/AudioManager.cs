using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start() {
        if (clips == null) {
            names = new List<string>();
            samples = new List<int>();
            current = new List<int>();
            clips = new List<List<AudioClip>>();

            LoadClips(7, "bad-keyboard-input");
            LoadClips(6, "delete-keyboard-input");
            LoadClips(4, "explosion");
            LoadClips(32, "good-keyboard-input");
            LoadClips(4, "gui");
            LoadClips(9, "level");
            LoadClips(4, "power-up");
            LoadClips(4, "shoot");
            LoadClips(6, "skill");
        }
    }

    void LoadClips(int roundRobins, string name) {
        names.Add(name);
        samples.Add(roundRobins);
        current.Add(0);

        List<AudioClip> list = new List<AudioClip>();
        for(int i = 0; i < roundRobins; ++i) {
            list.Add(Resources.Load<AudioClip>(name + "/" + (i + 1).ToString("00")));
        }
        clips.Add(list);
    }

    static List<string> names;
    static List<int> samples;
    static List<int> current;
    static List<List<AudioClip>> clips;

    public void Play(AudioSource audioSource, string sound) {
        if (audioSource == null) {
            audioSource = GetComponent<AudioSource>();
        }
        for (int i = 0; i < clips.Count; ++i) {
            if (!names[i].Equals(sound)) {
                continue;
            }

            audioSource.PlayOneShot(clips[i][current[i]++]);
            current[i] %= samples[i];

            break;
        }
    }
}
