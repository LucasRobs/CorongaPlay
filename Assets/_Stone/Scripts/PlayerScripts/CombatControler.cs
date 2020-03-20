using UnityEngine;
using System.Collections;

namespace _Stone.combat
{
    [RequireComponent(typeof(Creature.CreatureBase))]
    public class CombatControler : MonoBehaviour
    {
        public _Stone.Spells.spell CurrentSpell = new Spells.spell();
        private Creature.CreatureBase creature => GetComponent<Creature.CreatureBase>();

        public void CallSpell(Spells.spell spells)
        {
            if (!CurrentSpell.IsCasting)
            {
                CurrentSpell = spells;
                spells.Init(this);

            }
        }
  
    }

}
