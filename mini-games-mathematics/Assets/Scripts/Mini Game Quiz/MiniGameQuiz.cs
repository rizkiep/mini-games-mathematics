using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MiniGameQuiz : MonoBehaviour
{
    public Text timeText, questionText,leftAnswerText,rightAnswerText;
    public float time=20f;
    public GameManager gameManager;
    Question questionScript;
    int wrongAnswer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            timeText.text = Mathf.RoundToInt(time).ToString();
        }
        else
        {
            //Debug.Log(onMiniGameFinished);
            gameManager.OnMiniGameFinished();
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
    }
    void Answer()
    {
        wrongAnswer = Random.Range(0,questionScript.answer + 5);
        while (wrongAnswer == questionScript.answer){
            wrongAnswer = Random.Range(0, questionScript.answer + 5);
        }
        
        if (Random.value < 0.5f)
        {
            leftAnswerText.text = questionScript.answer.ToString();
            rightAnswerText.text = wrongAnswer.ToString();
        }
        else
        {
            rightAnswerText.text = questionScript.answer.ToString();
            leftAnswerText.text = wrongAnswer.ToString();
        }
    }
}
