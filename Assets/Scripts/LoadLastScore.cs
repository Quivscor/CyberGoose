using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLastScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TMPro.TextMeshProUGUI text = GetComponent<TMPro.TextMeshProUGUI>();
        PlayerScore displayScore = ScoreSerializer.LoadHighScore();
        text.text = "Last played score: " + displayScore.points;
    }
}
