using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;

    void Update() {
        Vector2 targetPos;
        targetPos.x = target.position.x;
        targetPos.y = target.position.y;

        transform.position = new Vector3(targetPos.x, targetPos.y, -10);
    }
}
