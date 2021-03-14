using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject player;
    playerOne playerScript;
    public Text pLives;
    public Text pDead;
    public GameObject pRetry;
    [SerializeField] Camera cam;

    public GameObject meteor; 

    float horizontalMin;
    float horizontalMax;
    float verticalMin;
    float verticalMax;
    float boundsOffset = 1f;

    float spawnRate = 1f;
    float timeStamp; 

    bool showMenu = false;

    private void Start() {
        pDead.enabled = false;
        pRetry.SetActive(false);
            
        playerScript = player.GetComponent<playerOne>();

        //screen width
        float halfHeight = cam.orthographicSize;
        float halfWidtth = cam.aspect * halfHeight;

        verticalMin = -halfHeight;
        verticalMax = halfHeight;

        horizontalMin = -halfWidtth;
        horizontalMax = halfWidtth;


    }
    void Update(){
         if(Time.time >= timeStamp){
            SpawnMeteor();
            timeStamp = Time.time + spawnRate;
        }


        ManagePlayerPos(); //is putting the code in a sperate method stupid? who knows!
        
        pLives.text = "lives: " + playerScript.lives;
    }

    // makes sure the player cant get lost going outside the bounds lul
    void ManagePlayerPos(){
        if(player != null){
            float playerposx = player.transform.position.x;
            float playerposy = player.transform.position.y;
            

            if(playerposx >= horizontalMax + boundsOffset){
                player.transform.position = new Vector2(horizontalMin - boundsOffset, playerposy);
            } else if(playerposx <= horizontalMin - boundsOffset){
                player.transform.position = new Vector2(horizontalMax + boundsOffset, playerposy);
            }

            if(playerposy >= verticalMax + boundsOffset){
                player.transform.position = new Vector2(playerposx, verticalMin - boundsOffset);
            } else if(playerposy <= verticalMin - boundsOffset){
                player.transform.position = new Vector2(playerposx, verticalMax + boundsOffset);
            }
            
        } else{
            if(showMenu) return;
            PlayerDeath();
        }
    }

    void SpawnMeteor(){
    }


    void PlayerDeath(){
        showMenu = true;
        pDead.enabled = true;
        pRetry.SetActive(true);

    }

    public void RestartLevel(){
        SceneManager.LoadScene(0);
    }


}
