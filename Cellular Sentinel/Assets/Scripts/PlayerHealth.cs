using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

  private Image HealthBar;
  public float curHP;
  private float maxHP = 50f;
  private PlayerMovement Player;

  private void Start()
  {
    HealthBar = GetComponent<Image>();
    Player = FindObjectOfType<PlayerMovement>();
  }

  private void Update()
  {
    curHP = Player.Health;
    HealthBar.fillAmount = curHP / maxHP;
  }




}
