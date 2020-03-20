namespace _Stone.Item
{
    [UnityEngine.CreateAssetMenu(fileName = "NewItem",menuName = "Items/NewItem")]
    public class ItemBase : UnityEngine.ScriptableObject
    {
        [UnityEngine.SerializeField] private string Name;
        public int ID;
        [UnityEngine.SerializeField] private UnityEngine.Sprite Icon;

        public int CurrentAmount;
        public int MaxAmount;

        public UnityEngine.GameObject PrefabModel;
    }
}
