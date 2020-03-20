using UnityEngine;
using System.Collections;

namespace _Stone.MasterHouse
{
    public class MasterHouse : Creature.CreatureBase
    {
        public static MasterHouse instance { get; private set; }
        [SerializeField] private int Score = 0;
        private void Update()
        {
            transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
        }
        private void Start()
        {
            instance = this;
        }

        public void AddScore(int Amount)
        {
            Score += Amount;
        }




    }

}

