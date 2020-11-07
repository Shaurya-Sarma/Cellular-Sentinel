using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingAI : MonoBehaviour
{
  public GameObject bulletPrefab;
  public Transform firePoint;

  [Header("Enemy Settings")]
  public float moveSpeed = 4f;
  public float stoppingDistance = 20f;
  public float retreatDistance = 10f;

  private float timeBetweenShoot;
  public float startTimeBetweenShoot = 2f;
  public float bulletForce = 20f;

  private Transform Player;

  private void Start()
  {
    if(GameObject.FindGameObjectWithTag("Player")) {
      Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    timeBetweenShoot = startTimeBetweenShoot;
  }

  private void Update()
  {
    if(Player) {
      Vector2 direction = Player.position - this.transform.position;
      float angle = Mathf.Atan2(direction.y, direction.x);
      this.transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg - 90f);
      // Enemy Moves Toward The Player 
      if (Vector2.Distance(Player.position, transform.position) > stoppingDistance)
      {
        transform.position = Vector2.MoveTowards(transform.position, Player.position, moveSpeed * Time.deltaTime);
      }
      // Enemy Stops 
      else if (Vector2.Distance(Player.position, transform.position) < stoppingDistance && Vector2.Distance(Player.position, transform.position) > retreatDistance)
      {
        transform.position = this.transform.position;
      }
      // Enemy Retreats Away From The Player 
      else if (Vector2.Distance(Player.position, transform.position) < retreatDistance)
      {
        transform.position = Vector2.MoveTowards(transform.position, Player.position, -moveSpeed * Time.deltaTime);
      }

      // Enemy Shooting 
      if (timeBetweenShoot <= 0)
      {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        timeBetweenShoot = startTimeBetweenShoot;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 5f);
      }
      else
      {
        timeBetweenShoot -= Time.deltaTime;
      }
    }
  }
}
