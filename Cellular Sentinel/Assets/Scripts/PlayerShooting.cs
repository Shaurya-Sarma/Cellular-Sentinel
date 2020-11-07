using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
  [Header("Prerequisites")]
  public Transform firePoint;
  public GameObject bulletPrefab;
  public float bulletForce = 20f;
  public float shootingDelay = 0.1f;
  private float shootingDelayTimer;

  private PlayerMovement Player;

  void Start()
  {
    shootingDelayTimer = shootingDelay;
    Player = GetComponent<PlayerMovement>();
  }
  void Update()
  {
    shootingDelayTimer -= Time.deltaTime;

    if (Input.GetButton("Fire1") && shootingDelayTimer <= 0)
    {
      Shoot();
    }
  }

  private void Shoot()
  {
    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    shootingDelayTimer = shootingDelay;

    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    Destroy(bullet, 5f);
  }
}
