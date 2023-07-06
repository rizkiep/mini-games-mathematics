using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int inputID;
    float horizontalInput;
    float lastActivity;
    GameObject playerSpawner;
    PlayerSpawn playerSpawn;
    // Start is called before the first frame update
    void Start()
    {
        playerSpawner = GameObject.Find("PlayerSpawner");
        playerSpawn = playerSpawner.GetComponent<PlayerSpawn>();
        lastActivity = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        if (horizontalInput!=0)
        {
            lastActivity = Time.time;
            Vector3 movment = Vector3.right * Time.deltaTime * horizontalInput * 10;
            if (transform.position.x<=-8.2 && horizontalInput<0)
            {
                movment = Vector3.zero;
            }
            if (transform.position.x >= 8.2 && horizontalInput>0)
            {
                movment = Vector3.zero;
            }
            transform.Translate(movment);
        }
       /* if (Time.time - lastActivity > 20f)
        {
            playerSpawn.playerSpawned[inputID - 1] = false;
            DestroyPlayer();
        }*/
    }
    void DestroyPlayer()
    {
        Destroy(gameObject);
    }
}
