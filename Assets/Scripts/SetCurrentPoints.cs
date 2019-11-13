using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCurrentPoints : MonoBehaviour
{
    public float time = 1;
    private TMPro.TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();

        float startScore = GameManager.Instance.Score.previousPoints;
        float endScore = GameManager.Instance.Score.points;

        StartCoroutine(UpdateScoreOverTime(startScore, endScore));
    }

    IEnumerator UpdateScoreOverTime(float start, float end)
    {
        int current = (int)start;
        while(current < end)
        {
            current += (int)((end - start) / (time / Time.fixedDeltaTime));
            text.text = "ECTS: " + current;
            yield return new WaitForFixedUpdate();
        }
    }
}
