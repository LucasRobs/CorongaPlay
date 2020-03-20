using UnityEngine;
using System.Collections;
namespace _Stone.Ballons
{
    public class Baloon : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            MasterHouse.MasterHouse house = collision.GetComponent<MasterHouse.MasterHouse>();
            if (house)
            {
                house.AddScore(5);
            }
        }

    }

}
