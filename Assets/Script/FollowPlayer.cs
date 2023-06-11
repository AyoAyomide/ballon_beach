using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public int cameraDistance = 10;
    // Update is called once per frame
    void LateUpdate()
    {
        // transform.position = new Vector3(0,5.1f,-25.4f + player.transform.position.z);
        transform.position = Vector3.Lerp(
            gameObject.transform.position,
            new Vector3(
                0,
                gameObject.transform.position.y,
                player.gameObject.transform.position.z - cameraDistance
            ), Time.deltaTime * 100);
    }
}
