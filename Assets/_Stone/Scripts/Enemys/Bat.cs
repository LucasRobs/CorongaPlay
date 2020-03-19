using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Stone.Enemy.Bat
{
    public class Bat : EnemyBase.EnemyBase
    {
        [SerializeField] private _Stone.Status.BasicStatus status;
        [SerializeField] private float MoveSpeed;
        [SerializeField] private int BaseDamageAmount = 1;

        private void FixedUpdate()
        {

            transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
        
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.transform.name);
            _Stone.MasterHouse.MasterHouse house = collision.transform.GetComponent<_Stone.MasterHouse.MasterHouse>();
            if (house)
            {
                house.TakeDamage(BaseDamageAmount);
                Destroy(gameObject);
            }

        }


    }
}

