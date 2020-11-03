using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    // public GameObject explosionEffect; 
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collided");
        if(other.CompareTag("Enemy")) {
        // GameObject effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        // Destroy(effect, 5f);
        Debug.Log("Destroy");
        Destroy(gameObject);
        }
    }
}
