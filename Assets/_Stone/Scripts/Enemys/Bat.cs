using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace _Stone.Enemy
{
    public class Bat : _Stone.Creature.CreatureBase,IBat
    {

        [SerializeField] private List<_Stone.Item.ItemBase> ItemsDrop = new List<Item.ItemBase>();
        [SerializeField] private float DropAmount;

        private Dictionary<string, spell> AttackSpellsList = new Dictionary<string, spell>();
        [SerializeField] private List<spell> _SpellList_ = new List<spell>();
        private void Start()
        {
            for (int i = 0; i < _SpellList_.Count; i++)
            {
                AttackSpellsList.Add(_SpellList_[i].Name, _SpellList_[i]);
                _SpellList_[i].Event = (SpellMethod)_Stone.Loader.EnemyEvents[_SpellList_[i].MethodName].CreateDelegate(typeof(SpellMethod));

            }

        }
        private void FixedUpdate()
        {

          
            if (Vector3.Distance(transform.position,_Stone.MasterHouse.instance.transform.position) < 5)
            {
                Target = _Stone.MasterHouse.instance.transform;
    
            }
        
            if (Target)
            {
                AIFunction();
            }
        }
        private void AIFunction()
        {


            if (Vector3.Distance(Target.transform.position, transform.position) < 1.2f)
            {
                transform.LookAt(Target);
                if (AninControler)
                {

                }
                if (!AttackSpellsList["BitAttack"].IsCasting)
                {
                    BitAttack();
                }
            }
            else
            {
                if (Vector3.Distance(Target.transform.position, transform.position) > 1.2f)
                {
                    if (!CombatMaster.CurrentSpell.IsCasting)
                    {

                        transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
                        

                    }
                }


            }
        }

        private void OnDestroy()
        {
            for (int i = 0; i < DropAmount; i++)
            {
                float value = (UnityEngine.Random.Range(0, 100) / ItemsDrop.Count) * 100;
                DropItem(ItemsDrop[UnityEngine.Random.Range(0, ItemsDrop.Count)]);
            }



        }
        void DropItem(_Stone.Item.ItemBase item)
        {
            GameObject SpawnItem = Instantiate(item?.PrefabModel);
        }

        public void SonicWave()
        {
            MoveSpeed = 1;
            CombatMaster.CallSpell(AttackSpellsList["SonicWave"]);
            Destroy(gameObject,0.3f);
            MoveSpeed = 3;
        }

        public void BitAttack()
        {
            MoveSpeed = 5;
            CombatMaster.CallSpell(AttackSpellsList["BitAttack"]);
            Destroy(gameObject,0.3f);
            MoveSpeed = 3;

        }
    }
}

