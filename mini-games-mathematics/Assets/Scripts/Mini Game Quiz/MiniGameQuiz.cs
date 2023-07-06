using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MiniGameQuiz : MonoBehaviour
{
    public Text timeText, questionText,leftAnswerText,rightAnswerText;
    public float time=20f;
    public GameManager gameManager;
    public ScoreManager scoreManager;
    public GameObject fireworks;
    Question questionScript;
    float wrongAnswer;
    public bool answerleft, answerRight,isFunctionRunning;
    // Start is called before the first frame update
    void Start()
    {
        isFunctionRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFunctionRunning)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                timeText.text = Mathf.RoundToInt(time).ToString();

            }
            else
            {
                if (answerleft==true)
                {
                    Instantiate(fireworks,new Vector3 (-5.57f,0,0),Quaternion.identity);
                }
                else
                {
                    Instantiate(fireworks, new Vector3(5.57f, 0, 0), Quaternion.identity);
                }
                ChackAnswer();
                gameManager.OnMiniGameFinished();
            }
        }
    }
    public void StartQuiz()
    {
        questionScript = GetComponent<Question>();
        time = 20f;
        timeText.text = time.ToString();
        questionScript.GenerateQuestion();
        questionText.text = questionScript.question;
        Answer();
        isFunctionRunning = false;
    }
    void Answer()
    {
        wrongAnswer = Random.Range(0, questionScript.answer + 5);
        if (Mathf.Approximately(questionScript.answer%1, 0))
        {
            wrongAnswer = Mathf.Ceil(wrongAnswer);
        }
        while (wrongAnswer == questionScript.answer){
            wrongAnswer = Random.Range(0, questionScript.answer + 5);
            if (Mathf.Approximately(questionScript.answer%1, 0))
            {
                wrongAnswer = Mathf.Ceil(wrongAnswer);
            }
        }
        float randomAnswerLocation = Random.value;
        Debug.Log(randomAnswerLocation);
        if (randomAnswerLocation<0.5f)
        {
            leftAnswerText.text = questionScript.answer.ToString();
            rightAnswerText.text = wrongAnswer.ToString();
            answerRight = false;
            answerleft = true;
        }
        else
        {
            rightAnswerText.text = questionScript.answer.ToString();
            leftAnswerText.text = wrongAnswer.ToString();
            answerleft = false;
            answerRight = true;
        }
    }
    void ChackAnswer()
    {
        isFunctionRunning = true;
        foreach(GameObject player in MiniGameManager.Instance.players)
        {
            PlayerScore playerScore = player.GetComponent<PlayerScore>();
            PlayerControl playerControl = player.GetComponent<PlayerControl>();
            playerScore.AnsweMiniGameQuiz();
            if (playerScore.answer==true)
            {
                scoreManager.AddScore(playerControl.inputID);
                Debug.Log("Player " + playerControl.inputID + "= Menang");
            }
            else
            {
                Debug.Log("Player " + playerControl.inputID + "= Kalah");
            }
        }
    }

}
