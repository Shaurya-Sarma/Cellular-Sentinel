using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWanderAI : MonoBehaviour
{
  [Header("Enemy Movement")]

  [SerializeField] float moveSpeed = 5f;
  [SerializeField] float range = 0.5f;
  [SerializeField] float maxDistance = 10f;

  private Vector2 _point;

  private void FixedUpdate()
  {
    transform.position = Vector2.MoveTowards(transform.position, _point, moveSpeed * Time.deltaTime);
    if (Vector2.Distance(transform.position, _point) < range)
    {
      SetNewDestination();
    }
  }
  private void SetNewDestination()
  {
    _point = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
  }
}
