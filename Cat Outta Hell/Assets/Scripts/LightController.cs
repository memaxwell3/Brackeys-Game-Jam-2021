using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace UnityEngine.Experimental.Rendering.Universal {

    public class LightController : MonoBehaviour
    {
        public MonsterController monsterController;
        public CircleCollider2D lightCollider;

        public Light2D demonLight;

        private void Start()
        {

        }

        private void Update()
        {
            if (monsterController.followingCat)
            {
                demonLight.pointLightOuterRadius += Time.deltaTime/3;
                lightCollider.radius += Time.deltaTime / 5;
            }
            if (!monsterController.followingCat)
            {
                if (lightCollider.radius >= 1.5f)
                {
                    demonLight.pointLightOuterRadius -= Time.deltaTime/3;
                    lightCollider.radius -= Time.deltaTime / 5;
                }
                else
                {
                    demonLight.pointLightOuterRadius = 3.2f;
                    lightCollider.radius = 1.5f;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            monsterController.followingCat = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            monsterController.followingCat = false;
        }
    }
}