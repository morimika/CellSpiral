using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMSEManager : MonoBehaviour
{
    public static BGMSEManager BSInstance;

    public static GameObject Bsingle;

    [SerializeField]
    private AudioSource bgmAudioSource;
    [SerializeField]
    private List<AudioClip> bgmClipLists;

    [SerializeField]
    private AudioSource seAudioSource;
    [SerializeField]
    private List<AudioClip> seAudioClipLists;

    public static AudioClip PlayingAudio;

    private void Awake()
    {
        if (Bsingle == null)
        {
            Bsingle = this.gameObject;
            PlayingAudio = null;
            BSInstance = this;
        }
    }

    public void BGMPlayer(int bgmNumber)
    {
        bgmAudioSource.clip = bgmClipLists[bgmNumber];
        bgmAudioSource.Play();
        PlayingAudio = bgmClipLists[bgmNumber];
    }

    public void BGMStoper(int bgmNumber)
    {
        bgmAudioSource.Stop();
        PlayingAudio = null;
    }

    public void SEPlayer(int seNumber)
    {
        seAudioSource.PlayOneShot(seAudioClipLists[seNumber]);
    }
}
