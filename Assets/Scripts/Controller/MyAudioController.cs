using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAudioController : MonoBehaviour {

    private AudioSource m_audioSource;

    private void Start() {
        m_audioSource = GetComponent<AudioSource>();
    }

    protected void PlayAudio(AudioClip func_ac) {
        m_audioSource.PlayOneShot(func_ac);
    }
}
