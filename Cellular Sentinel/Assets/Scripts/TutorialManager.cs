using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;


public class TutorialManager : MonoBehaviour
{
  public Text textMessage;
  private bool hasMoved = false;
  private bool shownBackground = false;
  private bool hasShooted = false;
  public Transform[] spawnPoints;
  public GameObject enemyPrefab;
  private bool hasSpawnedEnemies = false;
  private bool hasKilledEnemies = false;
  private bool isDone = false;
  private bool isReady = false;
  private CinemachineVirtualCamera virtualCamera;
  private GameObject Player;

  private void Start()
  {
    textMessage.text = "Press [WASD] To Move";
    virtualCamera = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
    if (GameObject.FindGameObjectWithTag("Player"))
    {
      Player = GameObject.FindGameObjectWithTag("Player");
    }
  }

  private void Update()
  {
    if (Input.GetButtonDown("Horizontal") && !hasMoved || Input.GetButtonDown("Vertical") && !hasMoved)
    {
      hasMoved = true;
      StartCoroutine(ShowBackgroundInfo());
    }
    if (shownBackground && !hasShooted)
    {
      textMessage.text = "Press [SPACE] to fire antibodies. These Y-shaped proteins will bind to pathogens and destroy them.";
      if (Input.GetButton("Fire1") && !hasShooted)
      {
        hasShooted = true;
        StartCoroutine(PrepareForEnemies());
      }
    }
    if (hasShooted && isReady)
    {
      textMessage.text = "";
      if (!hasSpawnedEnemies)
      {
        hasSpawnedEnemies = true;
        SpawnEnemies();

      }
      else
      {
        if (!GameObject.FindGameObjectWithTag("Enemy"))
        {
          hasKilledEnemies = true;
        }
      }
    }
    if (hasKilledEnemies && !isDone)
    {
      StartCoroutine(ShowEndMessage());
    }
    if (isDone)
    {
      SceneManager.LoadScene("Menu");
    }

  }

  private IEnumerator ShowBackgroundInfo()
  {
    textMessage.text = "You are a lymphocyte and you must hold off the invading pathogens until backup arrives.";
    yield return new WaitForSeconds(10f);
    textMessage.text = "Survive for as long as you can and destroy all of the pathogens.";
    yield return new WaitForSeconds(19f);
    shownBackground = true;
  }

  private IEnumerator PrepareForEnemies()
  {
    textMessage.text = "A wave of antigens are approaching! Use [MOUSE] to aim and eliminate them...";
    yield return new WaitForSeconds(10f);
    textMessage.text = "Be careful. If you get hit by the antigens your cell membrane might rupture! Collect amino acids to replenish your health. Good luck.";
    yield return new WaitForSeconds(10f);
    isReady = true;
  }

  private void SpawnEnemies()
  {
    if (Player)
    {
      virtualCamera.Follow = Player.transform;
    }
    foreach (Transform spawn in spawnPoints)
    {
      Instantiate(enemyPrefab, spawn.position, Quaternion.identity);
    }
  }

  private IEnumerator ShowEndMessage()
  {
    textMessage.text = "Great Job! You were able to successfully fight off those antigens. Rest up, more invaders may come soon...";
    yield return new WaitForSeconds(10f);
    isDone = true;
  }

}
