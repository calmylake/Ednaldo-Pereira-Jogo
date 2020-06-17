using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCode : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rdbplayer;
    void Start()
    {
        rdbplayer = player.GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        Vector3 positiontogo = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        //transform.position = Vector3.Lerp(transform.position, positiontogo, Time.deltaTime);
        //transform.position = positiontogo + new Vector3(rdbplayer.velocity.x, rdbplayer.velocity.y, 0);
        
        transform.position = Vector3.Lerp(transform.position, positiontogo+new Vector3(rdbplayer.velocity.x, rdbplayer.velocity.y, 0)*1.3f, Time.smoothDeltaTime);
    }
}
