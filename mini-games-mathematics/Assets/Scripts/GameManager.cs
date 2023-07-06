using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public List<string> miniGames = new List<string>(){"quiz"};
    int roundMiniGame = 3;
    MiniGameManager miniGameManager;
    ScoreManager scoreManager;
    int currentRound = 1;
    public int level=1;
    public Text time,question,leftAnswer,rightAnswer;
    //public string currentMiniGame;
    // Start is called before the first frame update
    private void Awake()
    {
        HideText();
    }
    void Start()
    {
        miniGameManager = GetComponent<MiniGameManager>();
        scoreManager = GetComponent<ScoreManager>();
        miniGameManager.startMiniGame();
        //StartMiniGame();
        
    }
   /* void StartMiniGame()
    {
        if(currentRound <= roundMiniGame)
        {
            currentMiniGame = miniGames[Random.Range(0, miniGames.Count)];
            miniGameManager.PlayMiniGame(currentMiniGame);
        }
    }*/
    public void OnMiniGameFinished()
    {
        if (currentRound < roundMiniGame)
        {
            currentRound++;
            HideText();
            StartCoroutine(DelayCoroutine(2f));
        }
        else
        {
            currentRound = 1;
            scoreManager.ChackWin();
            HideText();
            //currentMiniGame = miniGames[Random.Range(0, miniGames.Count)];
            StartCoroutine(DelayCoroutine(3f));
        }
    }
    IEnumerator DelayCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        //miniGameManager.PlayMiniGame(currentMiniGame);
        Destroy(GameObject.Find("Fireworks(Clone)"));
        miniGameManager.startMiniGame();
    }
    void HideText()
    {
        time.enabled = false;
        question.enabled = false;
        leftAnswer.enabled = false;
        rightAnswer.enabled = false;
    }

}
