using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
    GameManager gameManager;
    public static MiniGameManager Instance;
    public List<string> miniGames = new List<string>();
    string currentMiniGame;
    public MiniGameQuiz miniGameQuiz;
    public MiniGameBalloon miniGameBalloon;
    public List<GameObject> players = new List<GameObject>();
    int timeQuiz;
    bool gameStart;
    // Start is called before the first frame update
    private void Awake()
    {
       gameManager = GetComponent<GameManager>();
       Instance = this;
       miniGameQuiz.enabled = false;
       miniGameBalloon.enabled = false;
       gameStart = false;
    }
    void Start()
    {
        
    }
    public void startMiniGame()
    {
        currentMiniGame = miniGames[Random.Range(0, miniGames.Count)];
        PlayMiniGame(currentMiniGame);
    }

    public void PlayMiniGame(string miniGameName)
    {
        if (players.Count> 0)
        {
            // Code Start Play Mini Game
            switch (miniGameName)
            {
                case "quiz":
                    miniGameQuiz.enabled = true;
                    gameManager.time.enabled = true;
                    gameManager.question.enabled = true;
                    gameManager.leftAnswer.enabled = true;
                    gameManager.rightAnswer.enabled = true;
                    miniGameQuiz.StartQuiz();
                    timeQuiz = Mathf.RoundToInt(miniGameQuiz.time);
                    break;
                case "balloon":
                    miniGameBalloon.enabled = true;
                    break;
            }
        }
    }

    public void RegisterPlayer(GameObject player)
    {
        if (gameStart==false)
        {
            gameStart = true;
            players.Add(player);
            StartCoroutine(DelayCoroutine());
        }
        else
        {
            players.Add(player);
        }
    }
    IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(2f);
        startMiniGame();
    }
}
