using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public AudioClip[] sounds;
    AudioSource audioSource;
    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int audioClip) {
        audioSource.PlayOneShot(sounds[audioClip]);
    }

}
