using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Stone.Enemy.Spawn
{
    public enum SpawnTýpe
    {
        bat = 0,
        mosquito = 1,
        corona = 2,


    }
    public class EnemySpawner : MonoBehaviour
    {

        [SerializeField] private GameObject BatPrefab;
        [SerializeField] private float SpawnDelay = 5;
        [SerializeField] private SpawnTýpe enemyType;
        [SerializeField] private Vector3 SpawnPosition = Vector2.zero;


        private void Start()
        {

            StartCoroutine(SpanwWave());
        }


        private IEnumerator SpanwWave()
        {
            float delay = SpawnDelay;
            SpawnPosition = transform.position + new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(1, -1));
            while (true)
            {
      
                if (delay <= 0)
                {
                    switch (enemyType)
                    {
                        case SpawnTýpe.bat:

                            GameObject batP = Instantiate(BatPrefab);
                            if (!batP.GetComponent<Rigidbody2D>())
                            {
                                batP.AddComponent<Rigidbody2D>();
                                batP.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;


                            }
                            if (!batP.GetComponent<BoxCollider2D>())
                            {
                                batP.AddComponent<BoxCollider2D>();

                            }
                            batP.transform.position = SpawnPosition;

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
