using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<string> miniGames = new List<string>(){"quiz"};
    int roundMiniGame = 3;
    MiniGameManager miniGameManager;
    int currentRound = 1;
    string currentMiniGame;
    // Start is called before the first frame update
    void Start()
    {
        miniGameManager = GetComponent<MiniGameManager>();
        StartMiniGame();
        
    }
    void StartMiniGame()
    {
        if(currentRound <= roundMiniGame)
        {
            currentMiniGame = miniGames[Random.Range(0, miniGames.Count)];
            miniGameManager.PlayMiniGame(currentMiniGame);
        }
    }
    public void OnMiniGameFinished()
    {
        if (currentRound < roundMiniGame)
        {
            currentRound++;
            //Debug.Log(currentRound);
            //miniGameManager.PlayMiniGame(currentMiniGame);
            StartCoroutine(DelayCoroutine(2f));
        }
        else
        {
            //Debug.Log("Finish2");
            currentRound = 1;
            currentMiniGame = miniGames[Random.Range(0, miniGames.Count)];
            //miniGameManager.PlayMiniGame(currentMiniGame);
            StartCoroutine(DelayCoroutine(2f));
        }
    }
    IEnumerator DelayCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        miniGameManager.PlayMiniGame(currentMiniGame);
    }

}
