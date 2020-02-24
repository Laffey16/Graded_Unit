using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    //References the Scoremanager module
    public static ScoreManager instance;
    //References the Text module
    public TextMeshProUGUI text;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
    }

    // Update is called once per frame
  public void ChangeScore(int coinValue)
    {
        //Changes the Score according to the coin value (Which in this case is 1)
        score += coinValue;
        //Outputs X + whatever the score is (converting it from a integer to a string)
        text.text = "X" + score.ToString();
    }
}
