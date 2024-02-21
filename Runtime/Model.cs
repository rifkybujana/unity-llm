using UnityEngine;

namespace gentatechnology.llm
{
    [CreateAssetMenu(fileName = "Model", menuName = "LLM/Model")]
    public class Model : ScriptableObject
    {
        public string Name;
        public string Author;
        public string ID;
    }
}