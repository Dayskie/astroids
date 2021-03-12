using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sMeteor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "bullet"){
            Debug.Log("just a github test teehee");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
