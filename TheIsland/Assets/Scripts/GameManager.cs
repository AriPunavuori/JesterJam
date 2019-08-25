using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

    int health = 3;
    public AudioClip[] sounds;
    AudioSource audioSource;
    public Slider healthBar;
    GameObject player;
    public Transform checkpoint;
    TextMeshProUGUI uiText;
    float textTimer = 5f;
    float textTime = 2f;
    public GameObject completeLevelUi;

    private void Start() {
        uiText = GameObject.Find("UIText").GetComponent<TextMeshProUGUI>();
        player = GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>();
        //checkpoint.position = GameObject.Find("StartPoint").transform.position;
        healthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
    }

    private void Update() {
        textTimer -= Time.deltaTime;
        if(textTimer < 0) {
            SetUIText("");
        }
    }

    public void PlaySound(int audioClip) {
        audioSource.PlayOneShot(sounds[audioClip]);
    }

    public void SetHealth(int add) {
        health += add;
        healthBar.value = health;
        if (health < 1) {
            player.transform.position = checkpoint.position;
            SetHealth(3);
        }
    }

    public void SetUIText(string text) {
        textTimer = textTime;
        uiText.text = text;

    }

    public void CompleteLevel()
    {
        completeLevelUi.SetActive(true);
    }
}
