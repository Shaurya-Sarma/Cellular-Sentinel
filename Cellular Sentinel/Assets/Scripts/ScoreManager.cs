using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
  public Text scoreText;
  public float scoreCount;
  public float pointsPerSecond;
  public bool scoreIncreasing = true;

  private void Update()
  {
    if (scoreIncreasing)
    {
      scoreCount += pointsPerSecond * Time.deltaTime;
    }


    scoreText.text = "Score: " + Mathf.Round(scoreCount);
  }
}
