using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    GameObject target;

    private void Start() {
        target = GameObject.Find("Player");
    }

    void Update() {
        Vector2 targetPos;
        targetPos.x = target.transform.position.x;
        targetPos.y = target.transform.position.y;
        transform.position = new Vector3(targetPos.x, targetPos.y, -10);
    }
}
