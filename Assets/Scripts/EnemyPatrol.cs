using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public int positionOfPatrol;
    public Transform point;
    bool movingRight = true; // Ќачальное направление движени€ вправо

    Transform Player;
    public float stoppingDistance;

    bool chill = false;
    bool angry = false;
    bool goBack = false;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol)
        {
            chill = true;
        }

        if (Vector2.Distance(transform.position, Player.position) < stoppingDistance)
        {
            angry = true;
        }

        if (Vector2.Distance(transform.position, Player.position) > stoppingDistance)
        {
            goBack = true;
        }

        if (chill == true)
        {
            Chill();
        }
        else if (angry == true)
        {
            Angry();
        }
        else if (goBack == true)
        {
            GoBack();
        }
    }

    void Chill()
    {
        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            movingRight = false;
            Flip();
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            movingRight = true;
            Flip();
        }

        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }

    void Angry()
    {
        if ((Player.position.x > transform.position.x && !movingRight) || (Player.position.x < transform.position.x && movingRight))
        {
            movingRight = !movingRight;
            Flip();
        }

        transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
    }

    void GoBack()
    {
        if ((point.position.x > transform.position.x && !movingRight) || (point.position.x < transform.position.x && movingRight))
        {
            movingRight = !movingRight;
            Flip();
        }

        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
