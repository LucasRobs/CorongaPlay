using UnityEngine;
using System.Collections;

namespace _Stone.MasterHouse
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MasterHouse : Creature.CreatureBase
    {
        public static MasterHouse instance { get; private set; }
        [SerializeField] private int Score = 0;

        [SerializeField] private ParticleSystem FlyBallonEffect;
        [SerializeField] private Rigidbody2D rb => GetComponent<Rigidbody2D>();

        [SerializeField] private float GravityBoost;

        private void Update()
        {
            transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.UpArrow))
            {
                FlyUp();
            }
            if (rb.gravityScale <= 0.01f)
            {
                rb.gravityScale += Time.deltaTime;

            }
        }
        private void Start()
        {
            instance = this;
        }

        public void AddScore(int Amount)
        {
            Score += Amount;
        }

        public void FlyUp()
        {
            if (FlyBallonEffect)
            {
                FlyBallonEffect.Play();
            }
            rb.gravityScale -= GravityBoost;



        }



    }

}

