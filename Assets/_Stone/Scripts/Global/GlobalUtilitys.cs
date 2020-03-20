using System.Collections;

namespace _Stone.Status
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
namespace _Stone.MasterHouse
{
    public interface IMasterHouse
    {
         void TakeDamage(int amout);
        
    }
}
namespace _Stone.GameDataManager
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
namespace _Stone.Enemy.Bat
{
    public interface IBat
    {
        void SonicWave();
        void BitAttack();

    }
}
namespace _Stone.Spells
{
    [System.Serializable]
    public class spell
    {
        public string AttackName;

        public bool IsCasting;
        public int DamageAmount;
        public string AnimationName;
        public UnityEngine.AudioClip Sound;
        public float AttackDelay;
        public void Init(combat.CombatControler controler)
        {
            IsCasting = true;
            controler.StartCoroutine(StartSpell(controler));
        }

        private IEnumerator StartSpell(combat.CombatControler control)
        {
            Creature.CreatureBase Caster = control.GetComponent<Creature.CreatureBase>();
            Creature.CreatureBase Target = Caster.Target.GetComponent<Creature.CreatureBase>();
            if (Sound)
            {
                Audio.AudioMaster.instace.PlaySound(Sound);
            }
            if (Caster.AninControler)
            {
                if (AnimationName != string.Empty)
                {
                    Caster.AninControler.Play(AnimationName);

                }
            }
            Target.TakeDamage(DamageAmount);

            yield return new UnityEngine.WaitForSeconds(AttackDelay);

            IsCasting = false;

        }
    }
}