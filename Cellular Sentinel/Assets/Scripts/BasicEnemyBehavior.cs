using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyBehavior : MonoBehaviour
{

    [Header("Enemy Speed")] public float moveSpeed = 3f; 
    private Transform _player;
    private Rigidbody2D _rb;
    private Vector2 _movement; 

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        // Find direction from enemy to player 
        Vector2 dir = _player.position - transform.position;
        // Find Angle of Rotation
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg -90f;
        _rb.rotation = angle;
        _movement = dir.normalized;
        MoveEnemy(_movement);
    }

    private void MoveEnemy(Vector2 dir) {
        _rb.MovePosition((Vector2)transform.position + (dir * moveSpeed * Time.fixedDeltaTime));
    }
}
