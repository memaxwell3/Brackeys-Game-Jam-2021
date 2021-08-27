using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public bool followingCat = false;
    float moveSpeed = 2f;

    float waitTime;
    float startWaitTime = 5f;

    public Transform[] moveSpots;
    int randomSpot;

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (!followingCat)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, moveSpeed*Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < .2f)
            {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, moveSpots.Length);
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }

            }
        }
        if (followingCat)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime * 1.2f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Game Over Kitty!");
    }


    //if !following catevery 10 seconds, move to water cooler, then back to desk
}
