using UnityEngine;
using System.Collections;

namespace _Stone.MasterHouse
{
    public class MasterHouse : MonoBehaviour,IMasterHouse
    {
        [SerializeField] private _Stone.Status.BasicStatus HouseStatus;

        public void TakeDamage(int amout)
        {

            HouseStatus.Heakth -= amout;
            Debug.Log($"enemy did {amout} damage");
            if (HouseStatus.Heakth <= 0)
            {
                DieFunction();
                HouseStatus.Heakth = 0;
                //die

            }

        }


        private void DieFunction()
        {
            Debug.Log($"{transform.name} just die");
        }
    }

}

