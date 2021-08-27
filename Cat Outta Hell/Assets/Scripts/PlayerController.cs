using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //movement
    public float moveSpeed = 5f;
    public Rigidbody2D playerRB;
    public Vector2 movement;
    //public Animator animator;

    //points
    public Text scoreText;
    public float score;

    public Transform attackPoint;
    public float attackRange = .5f;
    public LayerMask breakableLayer;

    // Start is called before the first frame update
    void Start()
    {
        score = 20f;
    }

// Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal"); 
        movement.y = Input.GetAxis("Vertical");

        scoreText.text = "Chaos Score:" + (score - 20);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Attack()
    {
        //animator.SetTrigger("Attack");
        Collider2D[] hitBreakables = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, breakableLayer);

        foreach (Collider2D breakable in hitBreakables)
        {
            //play breaking animation
            score += 20f;
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
