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
