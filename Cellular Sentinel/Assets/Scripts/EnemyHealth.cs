using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

  public GameObject explosionEffect;

  [Header("Health Settings")]
  public int maxHP = 5;

  [Header("Health Pack Settings")]
  public GameObject aminoAcidPrefab;
  public int healthSpawnChance = 5;
  private int curHP;
  private bool isHurt = false;
  private Material matWhite;
  private Material matDefault;
  private SpriteRenderer sr;
  private ScoreManager _SM;

  void Start()
  {
    curHP = maxHP;
    sr = GetComponent<SpriteRenderer>();
    matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
    matDefault = sr.material;
    _SM = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
  }
  private void Update()
  {
    if (isHurt)
    {
      curHP--;
      isHurt = true;
      isHurt = false;
      sr.material = matWhite;
      Invoke("ResetMaterial", 0.2f);
    }
    if (curHP <= 0)
    {
      DestroyEnemy();
      if (_SM.scoreIncreasing)
      {
        _SM.scoreCount += 100;
      }
    }
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.collider.CompareTag("Player"))
    {
      curHP = 0;
    }
    else if ((other.collider.CompareTag("Projectile")))
    {
      isHurt = true;
    }
  }

  public void DestroyEnemy()
  {
    GameObject effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
    Destroy(effect, 3f);
    this.gameObject.SetActive(false);

    // Randomly Spawn A Health Drop
    int num = Random.Range(1, healthSpawnChance);
    if (num == 1)
    {
      Instantiate(aminoAcidPrefab, transform.position, Quaternion.identity);
    }
  }

  private void ResetMaterial()
  {
    sr.material = matDefault;
  }
}
