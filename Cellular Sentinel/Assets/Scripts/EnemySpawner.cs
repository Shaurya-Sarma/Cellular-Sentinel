using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  [SerializeField] float spawnRadius = 8f;
  [SerializeField] float time = 1.5f;
  public GameObject[] enemies;
  private GameObject Player;

  private void Start()
  {
    Player = GameObject.FindGameObjectWithTag("Player");
    StartCoroutine(SpawnEnemy());
  }
  private IEnumerator SpawnEnemy()
  {
    Vector2 spawnPos = Player.transform.position;
    spawnPos += Random.insideUnitCircle.normalized * spawnRadius;
    Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
    yield return new WaitForSeconds(time);
    StartCoroutine(SpawnEnemy());
  }

}