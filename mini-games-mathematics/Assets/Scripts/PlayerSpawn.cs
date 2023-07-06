using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject[] players;
    float spawnRange = 8f;
    float spawnOffSet = 2.5f;
    float random;
    public bool[] playerSpawned;
    public MiniGameQuiz miniGameQuiz;
    
    // Update is called once per frame
    void Update()
    {
        if(!playerSpawned[0] && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
        {
            Spawn(0);
            playerSpawned[0] = true;
        }
        else if (!playerSpawned[1] && (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L)))
        {
            Spawn(1);
            playerSpawned[1] = true;
        }
        else if (!playerSpawned[2] && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            Spawn(2);
            playerSpawned[2] = true;
        }

    }
    void Spawn(int playerIndex)
    {
        random = Random.Range(-spawnRange, spawnRange);
        while (Overlap(random))
        {
            random = Random.Range(-spawnRange, spawnRange);
        }
        GameObject newPlayer = Instantiate(players[playerIndex], new Vector3(random, -3.523f, 0), Quaternion.identity);
        MiniGameManager.Instance.RegisterPlayer(newPlayer);
    }
    private bool Overlap(float randomX)
    {
        GameObject[] findPlayers = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject findPlayer in findPlayers)
        {
            if(findPlayer!=null && Mathf.Abs(findPlayer.transform.position.x -randomX) <= spawnOffSet)
            {
                return true;
            }
        }
        return false;
    }
}
