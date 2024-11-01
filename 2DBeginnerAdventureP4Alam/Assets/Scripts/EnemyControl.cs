using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speed = 3.0f;
    public bool vertical = true;
    public float changeTime = 3.0f;

    Rigidbody2D rigidbody2d;
    float timer;
    int direction = 1;

    Animator animator;
        
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 )
        {
            direction = -direction;
            timer = changeTime;
        }
    }
  

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        if(vertical)
        {
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
            position.y = position.y + speed  * Time.deltaTime * direction;
        }
        else
        {
            animator.SetFloat("Move x", direction);
            animator.SetFloat("Move Y", 0);
            position.x = position.x + speed * Time.deltaTime * direction;
        }
        
        rigidbody2d.MovePosition(position);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
        }

    }
}
