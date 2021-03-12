using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject player;
    playerOne playerScript;
    public Text pLives;
    [SerializeField] Camera cam;

    float horizontalMin;
    float horizontalMax;

    float verticalMin;
    float verticalMax;

    float boundsOffset = 1f;

    private void Start() {
        playerScript = player.GetComponent<playerOne>();
        pLives.text = "lives: " + playerScript.lives;
        //screen width
        float halfHeight = cam.orthographicSize;
        float halfWidtth = cam.aspect * halfHeight;

        verticalMin = -halfHeight;
        verticalMax = halfHeight;

        horizontalMin = -halfWidtth;
        horizontalMax = halfWidtth;


    }
    void Update(){
        ManagePlayerPos(); //is putting the code in a sperate method stupid? who knows!
        

    }

    // makes sure the player cant get lost going outside the bounds lul
    void ManagePlayerPos(){
        if(player != null){
            float playerposx = player.transform.position.x;
            float playerposy = player.transform.position.y;
            

            if(playerposx >= horizontalMax + boundsOffset){
                player.transform.position = new Vector2(horizontalMin - boundsOffset, player.transform.position.y);
            } else if(playerposx <= horizontalMin - boundsOffset){
                player.transform.position = new Vector2(horizontalMax + boundsOffset, player.transform.position.y);
            }

            if(playerposy >= verticalMax + boundsOffset){
                player.transform.position = new Vector2(playerposx, verticalMin - boundsOffset);
            } else if(playerposy <= verticalMin - boundsOffset){
                player.transform.position = new Vector2(playerposx, verticalMax + boundsOffset);
            }
            
        } else{
            Debug.Log("Player not found!"); // should really only happen when the gameover screen shows cause i'll just delete the player unless thats bad
        }
    }

    void SpawnMeteor(){
        //brain too duumb right now but somehow make more metors spawn and spawn faster and faster???
    }


}
