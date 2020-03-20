using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Stone.Creature
{
    public interface ICreature
    {
        void TakeDamage(int amout);
    }
    [RequireComponent(typeof(combat.CombatControler))]
    public class CreatureBase : MonoBehaviour,ICreature
    {
        [SerializeField] private _Stone.Status.BasicStatus status;
        public Transform Target;
        public Animator AninControler;
        public combat.CombatControler CombatMaster => GetComponent<combat.CombatControler>();
        public float MoveSpeed = 3;
        public void TakeDamage(int amout)
        {

            status.Heakth -= amout;
            Debug.Log($"enemy did {amout} damage");
            if (status.Heakth <= 0)
            {
                DieFunction();
                status.Heakth = 0;
                //die

            }

        }


        private void DieFunction()
        {
            Debug.Log($"{transform.name} just die");
        }
    }

}
