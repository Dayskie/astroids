using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Sprite mBig, mMedium, mSmall;
    public BoxCollider2D box;
    public int mSize; 

    void Start(){
        mSize = Random.Range(1,4);
        createMeteor();

    }

    void createMeteor(){
        switch(mSize){
            case 1: // small
                sprite.sprite = mSmall;
                box.size = new Vector2(1,1);
                transform.localScale = new Vector3(1,1,1);
                break;
            case 2:
                sprite.sprite = mMedium;
                box.size = new Vector2(2,2);
                transform.localScale = new Vector3(1,1,1);
                break;
            case 3:
                sprite.sprite = mBig;
                box.size = new Vector2(2,2);
                transform.localScale = new Vector3(2,2,1);
                break;
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
