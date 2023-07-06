using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    public static Question Instance;
    public int question1, question2;
    public float answer;
    public List<string> randomOperator = new List<string>();
    public string currentOpration,question;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GenerateQuestion()
    {
        /*double tes=3/2;
        Debug.Log((double)tes);*/
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
            case "multiplaction":
                question2 = Random.Range(1, 10);
                question = question1.ToString() + " X " + question2.ToString();
                answer = question1 * question2;
                break;
            case "division":
                question2 = Random.Range(1, 10);
                question = question1.ToString() + "/" + question2.ToString();
                answer = question1 / question2;
                break;
            case "power":
                question2 = Random.Range(2, 4);
                question = question1.ToString() + "^" + question2.ToString();
                answer = question1 ^ question2;
                break;
        }
    }
}
