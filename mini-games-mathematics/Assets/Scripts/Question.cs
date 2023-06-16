using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    public int question1, question2, answer;
    List<string> randomOperator = new List<string>() {"addition","subtraction" };
    public string currentOpration,question;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GenerateQuestion()
    {
        question1 = Random.Range(1, 10);
        currentOpration = randomOperator[Random.Range(0, randomOperator.Count)];
        switch (currentOpration)
        {
            case "addition":
                question2 = Random.Range(1, 10);
                question = question1.ToString() + "+" + question2.ToString();
                answer = question1 + question2;
                break;
            case "subtraction":
                question2 = Random.Range(1, question1);
                question = question1.ToString() + "-" + question2.ToString();
                answer = question1 - question2;
                break;
        }
    }
}
