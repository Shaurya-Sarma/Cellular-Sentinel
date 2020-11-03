using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
  public GameObject explosionEffect;

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.collider.CompareTag("Enemy"))
    {
      GameObject effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
      Destroy(effect, 3f);
      Destroy(gameObject);
    }
  }

}
