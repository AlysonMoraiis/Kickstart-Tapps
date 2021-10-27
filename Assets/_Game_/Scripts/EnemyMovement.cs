using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;   
    public float distanceToSeek;

    public Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (!target) return;
        if (Vector2.Distance(transform.position, target.position) > distanceToSeek) return;
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        var toPosition = (target.position - transform.position).normalized;
        transform.localScale = new Vector3 (toPosition.x < 0 ? -1 : 1, 1, 1);
    }

}
