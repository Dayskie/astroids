using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public int mSize; 
    // 3 = large  2 = medium  1 = small
    public GameObject MeteorMedium;
    public GameObject MeteorSmall;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "bullet"){
            switch (mSize) {
                case 3:
                    spawnMeteor(MeteorMedium);
                    destroyMeteor(other.gameObject); //other gameobject is the bullet
                    break;
                case 2:
                    spawnMeteor(MeteorSmall);
                    destroyMeteor(other.gameObject);
                    break;
                case 1:
                    destroyMeteor(other.gameObject);
                    break;
            }
        }
    }

    void spawnMeteor(GameObject gameobj){
        for(int i = 0; i < 3; i++){
            Instantiate(gameobj, transform.position, transform.rotation);
        }
    }

    void destroyMeteor(Object obj){
        Destroy(obj);
        Destroy(gameObject);
    }
}
