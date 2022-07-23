using UnityEngine;


namespace Mushy_Cheat
{
    public class Loader
    {
        public static void Init()
        {
            Load = new GameObject();
            Load.AddComponent<Hacks>();
            UnityEngine.Object.DontDestroyOnLoad(Load);
        }

        public static void Unload()
        {
            _Unload();
        }

        private static void _Unload()
        {
            UnityEngine.Object.Destroy(Load);
        }


        private static GameObject Load;
    }
}