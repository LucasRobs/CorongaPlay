using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Stone.Enemy
{
    public enum SpawnType
    {
        bat = 0,
        mosquito = 1,
        corona = 2,


    }
    public class EnemySpawner : MonoBehaviour
    {

        [SerializeField] private GameObject BatPrefab;
        [SerializeField] private float SpawnDelay = 5;
        [SerializeField] private SpawnType enemyType;


        private void Start()
        {

            StartCoroutine(SpanwWave());
        }


        private IEnumerator SpanwWave()
        {
            float delay = SpawnDelay;

            while (true)
            {
      
                if (delay <= 0)
                {
                    switch (enemyType)
                    {
                        case SpawnType.bat:

                            GameObject batP = Instantiate(BatPrefab,transform);
                            if (!batP.GetComponent<Rigidbody2D>())
                            {
                                batP.AddComponent<Rigidbody2D>();
                                batP.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;


                            }
                            if (!batP.GetComponent<BoxCollider2D>())
                            {
                                batP.AddComponent<BoxCollider2D>();

                            }
                            batP.transform.position = _Stone.MasterHouse.instance.transform.position + new Vector3(UnityEngine.Random.Range(12, 8), UnityEngine.Random.Range(1, -1));

                            break;
                    }
                    delay = SpawnDelay;
                }
                else
                {
                    delay -= Time.deltaTime;
                }


                yield return null;
            }
      

        }
    }

}
