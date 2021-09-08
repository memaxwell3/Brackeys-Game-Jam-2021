using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.Experimental.Rendering.Universal
{
    public class Exit : MonoBehaviour
    {
        public PlayerController player;

        public CircleCollider2D exitCollider;

        public Light2D exitLight;

        Vector3 size;
        Vector3 scaleChange;

        // Start is called before the first frame update
        void Start()
        {
            //size = transform.localScale;
            scaleChange = new Vector3(0, 0, 0);
        }

        // Update is called once per frame
        void Update()
        {
            exitCollider.radius = (player.score / 200)+2.9f;
            scaleChange = new Vector3(player.score / 200, player.score / 200, 0);
            transform.localScale = scaleChange;
            exitLight.pointLightOuterRadius = (player.score / 100) + 1;
            exitLight.intensity = (player.score / 200) + 1;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //play leaving animation
            //freeze player
            //reset level
            Debug.Log("You escaped!");
        }


    }

}

