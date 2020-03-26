using System.Collections;

namespace _Stone
{
    [System.Serializable]
    public struct BasicStatus
    {
        public int Heakth;


        public BasicStatus(int value)
        {
            Heakth = value;

        }

    }
}

namespace _Stone
{
    public class DataManager
    {
        private static string DataPath = UnityEngine.Application.persistentDataPath;
        private static System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        public static void SaveFiles(object file)
        {
            System.IO.FileStream FileStream = new System.IO.FileStream(DataPath +"/"+ file.ToString() + ".lst", System.IO.FileMode.Create);
            bf.Serialize(FileStream, file);
            FileStream.Close();


        }
        public static object LoadFiles(string fileName)
        {
            object file = new object();
            System.IO.FileStream FileStream = new System.IO.FileStream(DataPath + "/" + fileName + ".lst", System.IO.FileMode.Create);
            file = bf.Deserialize(FileStream) as object;
            FileStream.Close();
            return file;

        }
    }
}
namespace _Stone
{
    public interface IBat
    {
        void SonicWave();
        void BitAttack();

    }
}
namespace _Stone
{
    [System.Serializable]
    public delegate void SpellMethod(DataEvent dataEvent);
    public enum SpellType
    {
        Harm = 0,
        Benefyc = 1,


    }
    [System.Serializable]
    public class spell
    {
        public string Name;
        public SpellType type;
        public bool IsCasting;
        public int DamageAmount;
        public string AnimationName;
        public UnityEngine.AudioClip Sound;
        public float Colldown;
        public float Duration;
        public SpellMethod Event;
        public string MethodName;

        public void Init(CombatControler controler)
        {
            IsCasting = true;
            controler.StartCoroutine(StartSpell(controler));
        }
        private IEnumerator StartSpell(CombatControler control)
        {
            Creature.CreatureBase Caster = control.GetComponent<Creature.CreatureBase>();
            Creature.CreatureBase Target = Caster?.Target.GetComponent<Creature.CreatureBase>();
            if (Sound)
            {
                AudioMaster.instace.PlaySound(Sound);
            }
            if (Caster.AninControler)
            {
                if (AnimationName != string.Empty)
                {
                    Caster.AninControler.Play(AnimationName);

                }
            }
            switch (type)
            {
                case SpellType.Benefyc:
                    Event?.Invoke(new DataEvent { Caster = Caster,Target = Caster,Spell = this});

                    break;
                case SpellType.Harm:
                    Event?.Invoke(new DataEvent { Caster = Caster, Target = Target, Spell = this });
                    break;
            }
            yield return new UnityEngine.WaitForSeconds(Colldown);

            IsCasting = false;

        }
    }
}
namespace _Stone
{
    public class CombatFunctionAtribute : System.Attribute
    {

    }
    public struct DataEvent
    {
        public Creature.CreatureBase Caster;
        public Creature.CreatureBase Target;
        public spell Spell;

    }
    public class BallonEvents
    {
        [CombatFunctionAtribute]
        public static void Sprint(DataEvent dataEvent)
        {
            dataEvent.Caster.StartCoroutine(SprintEnum(dataEvent));
        }
        private static IEnumerator SprintEnum(DataEvent dataEvent)
        {
            dataEvent.Caster.MoveSpeed += 3;
            yield return new UnityEngine.WaitForSeconds(dataEvent.Spell.Duration);
            dataEvent.Caster.MoveSpeed -= 3;
        }

    }
    public class EnemyEvents
    {
        [CombatFunctionAtribute]
        public static void SonicWave(DataEvent dataEvent)
        {
            dataEvent.Target.TakeDamage(dataEvent.Spell.DamageAmount);
        }
        [CombatFunctionAtribute]
        public static void BitAttack(DataEvent dataEvent)
        {
            dataEvent.Target.TakeDamage(dataEvent.Spell.DamageAmount);
        }
    }

    public class Loader
    {
        public static System.Collections.Generic.Dictionary<string, System.Reflection.MethodInfo> EnemyEvents = new System.Collections.Generic.Dictionary<string, System.Reflection.MethodInfo>();
        public static System.Collections.Generic.Dictionary<string, System.Reflection.MethodInfo> BaloonEvents = new System.Collections.Generic.Dictionary<string, System.Reflection.MethodInfo>();
        public static void Load()
        {
            System.Type EnemyC = typeof(EnemyEvents);

            foreach (var method in EnemyC.GetMethods())
            {
                if (!EnemyEvents.ContainsKey(method.Name))
                {
                    EnemyEvents.Add(method.Name, method);

                }
            }

            System.Type BalllonC = typeof(BallonEvents);

            foreach (var method in BalllonC.GetMethods())
            {
                if (!BaloonEvents.ContainsKey(method.Name))
                {
                    BaloonEvents.Add(method.Name, method);

                }

            }
        }
    }
}