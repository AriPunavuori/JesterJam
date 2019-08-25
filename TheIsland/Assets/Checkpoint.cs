using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    GameManager gm;
    bool checkpointVisited;
    public string text;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!checkpointVisited) {
            if (collision.tag == "Player") {
                gm.checkpoint = transform;
                gm.SetUIText(text);
                checkpointVisited = true;
            }
        }
    }
}
