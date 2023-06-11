using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject spawnManager;
    public int playerSpeed = 1000;
    public int directionalSpeed = 50;
    public AudioClip scoreup;
    public AudioClip damage;
    // Update is called once per frame
    void Update()
    {

// Check running enviroment
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        // Move player horizontally
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.position = Vector3.Lerp(
            gameObject.transform.position,
            new Vector3(
                 Mathf.Clamp(gameObject.transform.position.x + moveHorizontal,-2.5f,2.5f),
                 gameObject.transform.position.y,
                 gameObject.transform.position.z
                ),
            directionalSpeed * Time.deltaTime);
#endif
        // Move player forward
        GetComponent<Rigidbody>().velocity = Vector3.forward * playerSpeed * Time.deltaTime;
        // Rotate player
        transform.Rotate(Vector3.right * GetComponent<Rigidbody>().velocity.z / 4);
        // Mobile controller
        Vector2 mobileTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,10f));
        if(Input.touchCount > 0){
            transform.position = new Vector3(mobileTouch.x, transform.position.y, transform.position.z);
        }

    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "scoreup"){
            GetComponent<AudioSource>().PlayOneShot(scoreup, 1.0f);
        }

        if(other.gameObject.tag == "triangle"){
            GetComponent<AudioSource>().PlayOneShot(damage, 1.0f);
            spawnManager.GetComponent<App_Initialize>().GameOver();
        }
    }
}
