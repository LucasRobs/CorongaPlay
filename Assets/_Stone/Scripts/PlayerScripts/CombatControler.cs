using UnityEngine;
using System.Collections;

namespace _Stone
{
    [RequireComponent(typeof(Creature.CreatureBase))]
    public class CombatControler : MonoBehaviour
    {
        public _Stone.spell CurrentSpell = new spell();
        private Creature.CreatureBase creature => GetComponent<Creature.CreatureBase>();

        public void CallSpell(spell spells)
        {
            if (!CurrentSpell.IsCasting)
            {
                CurrentSpell = spells;
                if (!creature.Target)
                {
                    creature.Target = transform;
                }
                spells.Init(this);


            }
        }
  
    }

}
