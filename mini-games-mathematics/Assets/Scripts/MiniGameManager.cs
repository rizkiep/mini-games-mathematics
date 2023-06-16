using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
    public MiniGameQuiz miniGameQuiz;
    int timeQuiz;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayMiniGame(string miniGameName)
    {
        // Code Start Play Mini Game
        switch (miniGameName)
        {
            case "quiz":
                //miniGameQuiz.enabled = false;
                miniGameQuiz.StartQuiz();
                timeQuiz = Mathf.RoundToInt(miniGameQuiz.time);
                break;
        }
        
    }
    

}
