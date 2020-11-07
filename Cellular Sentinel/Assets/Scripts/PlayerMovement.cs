using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


  public GameObject explosionEffect;
  [Header("Player Speed")] public float moveSpeed = 5f;
  private Rigidbody2D _rb;
  private Camera _cam;
  private Vector2 _movement;
  private Vector2 _mousePos;
  public float Health = 50f;

  private ScoreManager _SM; 

  private void Start()
  {
    _rb = GetComponent<Rigidbody2D>();
    _cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    _SM = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
  }

  private void Update()
  {
    // Get Movement Input Values
    _movement.x = Input.GetAxisRaw("Horizontal");
    _movement.y = Input.GetAxisRaw("Vertical");

    // Find Mouse Position - Convert From Pixel To World Coordinates 
    _mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);

    if (Health <= 0)
    {
      // Player Death
      Instantiate(explosionEffect, transform.position, Quaternion.identity);
      this.gameObject.SetActive(false);
      _SM.scoreIncreasing = false;
    }


  }

  private void FixedUpdate()
  {
    // Move Player 
    _rb.MovePosition(_rb.position + _movement * moveSpeed * Time.fixedDeltaTime);

    // Find direction from Player to Mouse
    Vector2 dir = _mousePos - _rb.position;
    // Find Angle Of Rotation 
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
    // Rotate Player
    _rb.rotation = angle;
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.collider.CompareTag("Enemy"))
    {
      Health -= 5;
    }
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if(other.collider.CompareTag("Collect")) {
      if(Health <= 45) { 
        Health += 5;
      } 
    }
  }
}
