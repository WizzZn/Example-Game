using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Vector3 enemyDefaultPoss;
    

    [SerializeField] Animator enemyAnim;
    [SerializeField] GameObject player;
    [SerializeField] float enemySpeed;
    [SerializeField] float enemyDistance;
    [SerializeField] Vector2 enemyPoss;
    [SerializeField] GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemyDefaultPoss = transform.position;
    }
   
    // Update is called once per frame
    void Update()
    {
        enemyMove();
       
    }
    private void FixedUpdate()
    {
        // transform.LookAt(player.transform);
        enemyFlip();

    }
    void enemyMove()
    {
       
        enemyDistance = Vector2.Distance(transform.position, player.transform.position);
        if (enemyDistance < 4f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed);
            enemyAnim.SetBool("Run", true);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position,enemyDefaultPoss, enemySpeed);
          
        }
       if (enemyDefaultPoss == transform.position)
       {
            enemyAnim.SetBool("Run", false);

       }
    }
    void enemyFlip()
    {
        enemyPoss = new Vector2(enemy.transform.position.x,transform.position.y);
        if (enemyPoss.x > transform.position.x)
        {
            Debug.Log("right");
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (enemyPoss.x < transform.position.x)
        {
            Debug.Log("left");
            GetComponent<SpriteRenderer>().flipX = true;
        }
        transform.position =  new Vector2(transform.position.x,enemyPoss.y);
    }
}