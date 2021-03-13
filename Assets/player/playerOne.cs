using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerOne : MonoBehaviour
{
    public GameObject bullet;
    public GameObject holster; // where to fire the bullet from
    
    Rigidbody2D rb;

    [SerializeField] private float invFrameTime;
    private bool isInvincible = false;
    public float lives;
    public float speed; // referring to the ship
    public float rotateSpeed;
    float timetoShoot = 0.5f;
    float timestamp;
    
    private bool collidingMeteor = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update(){
    
        checkforCollision();

        Debug.Log(collidingMeteor);

        if(Time.time >= timestamp && Input.GetKeyDown(KeyCode.Space)){
            Shoot();
            timestamp = Time.time + timetoShoot;
        }

    }
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W)){
            rb.AddForce((transform.up * speed));
        }

        float HorizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0,0, rotateSpeed * -HorizontalInput);

    }

    void Shoot(){
        Instantiate(bullet, new Vector2(holster.transform.position.x, holster.transform.position.y), 
        transform.rotation * Quaternion.Euler(holster.transform.rotation.x, holster.transform.rotation.y, 0f));
    }


    //TODO player die :( https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRJVfQ21sHE199a6y3slE7v1Wa6qi_nHOfKWw&usqp=CAU
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "meteor"){
            collidingMeteor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "meteor"){
            collidingMeteor = false;
        }
    }


    void checkforCollision(){
        if(collidingMeteor == true){
            if(lives > 0){
                if(isInvincible) return;
                lives--;
                StartCoroutine(InvincibilityFrames());
            } else if(lives == 0){
            Destroy(gameObject);
            }
        } 
    }

    //invincibility frames still need to make blink
    private IEnumerator InvincibilityFrames(){
        isInvincible = true;
        yield return new WaitForSeconds(invFrameTime);
        isInvincible = false;
    }   
}
