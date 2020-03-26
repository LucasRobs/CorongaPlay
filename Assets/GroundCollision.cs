using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Stone
{
    public class GroundCollision : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            MasterHouse house = collision.GetComponent<MasterHouse>();
            if (house)
            {
                house.TakeDamage(10000);
            }
        }
    }

}
