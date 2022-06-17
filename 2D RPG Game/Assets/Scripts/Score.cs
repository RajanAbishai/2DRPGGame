using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    private int score;

    [SerializeField]
    private Text scoreText;

    void Start()
    {
        MakeInstance();
    }

    void MakeInstance() //this allows us to transfer our public variables and methods to other scripts
    {
        if (instance == null)
        {
            instance=this;
        }
    }

    
    void Update()
    {
        
    }

    public void ScoreUp(int scoreObtained) //different score for each pickup / kill
    {
        score+=scoreObtained;

        scoreText.text = score.ToString();  //converting to string to display it
    }

}
