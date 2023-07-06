using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public bool answer;
    GameObject miniGames;
    MiniGameQuiz miniGameQuiz;
    // Start is called before the first frame update
    void Start()
    {
        miniGames=GameObject.Find("MiniGames");
        miniGameQuiz = miniGames.GetComponent<MiniGameQuiz>();
    }

    public void AnsweMiniGameQuiz()
    {
        Vector3 playerPosition = transform.position;
        if (playerPosition.x <=0)
        {
            answer = miniGameQuiz.answerleft;
        }
        else
        {
            answer = miniGameQuiz.answerRight;
        }

    }
}
