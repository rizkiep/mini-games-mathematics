using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Dictionary<int, int> playersScore = new Dictionary<int, int>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int playerId)
    {
        if (playersScore.ContainsKey(playerId))
        {
            playersScore[playerId] += 1;
        }
        else
        {
            playersScore[playerId] = 1;
        }
    }
    public void ChackWin()
    {
        foreach(KeyValuePair<int,int> score in playersScore)
        {
            Debug.Log("Player " + score.Key + "=" + score.Value);
        }
    }
}
