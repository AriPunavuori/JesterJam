using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaPlant : MonoBehaviour {
    public GameObject banana;
    bool bananaTaken = true;
    float bananaSpantimer;
    float bananaSpawnTime = 2f;

    void Update() {
        if(bananaTaken) {
            if(bananaSpantimer < 0) {
                var bananaClone = Instantiate(banana, transform.position + new Vector3(0,1,0), Quaternion.identity);
                var bs = bananaClone.GetComponent<Banana>();
                bs.bp = this;
                bananaTaken = false;
            }
            bananaSpantimer -= Time.deltaTime;
        }
    }

    public void TakeBanana() {
        bananaTaken = true;
        bananaSpantimer = bananaSpawnTime;
    }
}
