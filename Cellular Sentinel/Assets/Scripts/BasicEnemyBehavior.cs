using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyBehavior : MonoBehaviour
{
    private Transform _player;
    private Rigidbody2D _rb;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        // Find direction from enemy to player 
        Vector2 dir = _player.position - transform.position;
        // Find Angle of Rotation
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg -90f;
        _rb.rotation = angle;

    }
}
