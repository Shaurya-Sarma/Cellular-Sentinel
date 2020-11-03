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

  public int maxAmmo = 50;
  private int curAmmo;
  public float reloadTime = 1.5f;
  private bool isReloading = false;

  private PlayerMovement Player;
  void Start()
  {
    shootingDelayTimer = shootingDelay;
    curAmmo = maxAmmo;
    Player = GetComponent<PlayerMovement>();
  }
  void Update()
  {
    Debug.Log(curAmmo);

    shootingDelayTimer -= Time.deltaTime;
    if (isReloading)
    {
      return;
    }

    if (Input.GetButtonDown("Reload") && curAmmo < maxAmmo)
    {
      Player.Health -= 5;
      StartCoroutine(Reload());
      return;
    }
    if (Input.GetButton("Fire1") && shootingDelayTimer <= 0 && curAmmo > 0)
    {
      Shoot();
    }
  }

  private void Shoot()
  {
    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    shootingDelayTimer = shootingDelay;
    curAmmo--;

    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    Destroy(bullet, 5f);
  }

  private IEnumerator Reload()
  {
    isReloading = true;
    yield return new WaitForSeconds(reloadTime);
    curAmmo = maxAmmo;
    isReloading = false;

  }
}
