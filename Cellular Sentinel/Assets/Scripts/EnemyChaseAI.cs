using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseAI : MonoBehaviour
{

  private static List<Rigidbody2D> EnemyRBs;

  [Header("Enemy Movement")]
  public float moveSpeed = 3f;
  [Range(0f, 1f)]
  public float turnSpeed = .1f;
  public float repelRange = .8f;
  public float repelAmount = 1.5f;
  private Transform _player;
  private Rigidbody2D _rb;
  private void Start()
  {
    _player = GameObject.FindGameObjectWithTag("Player").transform;
    _rb = GetComponent<Rigidbody2D>();

    if (EnemyRBs == null)
    {
      EnemyRBs = new List<Rigidbody2D>();
    }

    EnemyRBs.Add(_rb);
  }

  private void FixedUpdate()
  {
    // Find direction from enemy to player 
    Vector2 dir = (_player.position - transform.position).normalized;
    Vector2 newPos;

    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
    _rb.rotation = Mathf.LerpAngle(_rb.rotation, angle, turnSpeed);

    newPos = MoveRegular(dir);

    _rb.MovePosition(newPos);

    // if (isShooter)
    // {
    // 	float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
    // 	_rb.rotation = angle;

    // 	if (distance > shootDistance)
    // 	{
    // 		newPos = MoveRegular(dir);
    // 	} else
    // 	{
    // 		newPos = MoveStrafing(dir);
    // 	}

    // 	Shoot();

    // 	newPos -= _rb.position;

    // 	_rb.AddForce(newPos, ForceMode2D.Force);

    // } else
    // {

    // }
  }

  // Source: Brackeys
  Vector2 MoveRegular(Vector2 direction)
  {
    Vector2 repelForce = Vector2.zero;
    foreach (Rigidbody2D enemy in EnemyRBs)
    {
      if (enemy == _rb)
        continue;

      if (Vector2.Distance(enemy.position, _rb.position) <= repelRange)
      {
        Vector2 repelDir = (_rb.position - enemy.position).normalized;
        repelForce += repelDir;
      }
    }

    Vector2 newPos = transform.position + transform.up * Time.fixedDeltaTime * moveSpeed;
    newPos += repelForce * Time.fixedDeltaTime * repelAmount;

    return newPos;
  }
}
