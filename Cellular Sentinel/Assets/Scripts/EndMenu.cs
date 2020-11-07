using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public bool isGameOver;
  public GameObject endMenuUI;

  private void Awake()
  {
    isGameOver = false;
  }
  private void Start()
  {
    isGameOver = false;
  }

  public void Restart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    Time.timeScale = 1f;
  }

    public void LoadMenu()
  {
    SceneManager.LoadScene("Menu");
  }

  public void Quit()
  {
    // GameObject.FindGameObjectWithTag("GameMaster").GetComponent<AudioManager>().Play("Click");
    // GameObject.FindObjectOfType<GameMaster>().SavePlayer();
    Application.Quit();
  }
}
