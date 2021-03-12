using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float bulletspeed;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Awake() {
        Debug.Log(this + "hello world");
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce((transform.up * bulletspeed));
        if(transform.position.x > 20 || transform.position.x < -20){
            Destroy(gameObject);
        }

        if(transform.position.y > 20 || transform.position.y< -20){
            Destroy(gameObject);
        }
    }
}
