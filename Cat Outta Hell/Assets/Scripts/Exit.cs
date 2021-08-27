using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public PlayerController player;

    public CircleCollider2D exitCollider;

    Vector3 size;
    Vector3 scaleChange;

    // Start is called before the first frame update
    void Start()
    {
        size = transform.localScale;
        scaleChange = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        exitCollider.radius = player.score / 220;
        scaleChange = new Vector3(player.score / 100, player.score / 100, 0);
        transform.localScale = scaleChange;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //play leaving animation
        //freeze player
        //reset level
        Debug.Log("You escaped!");
    }


}
