using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Mushy_Cheat
{
    internal class Hacks : MonoBehaviour
    {

        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        public void OnGUI()
        {
            GUI.Label(new Rect(0f, 0f, 1000f, 300f), "Mushy Unleashed Private Plus Max Extra");
            

            foreach (NonLocalPlayer player in FindObjectsOfType(typeof(NonLocalPlayer)) as NonLocalPlayer[])
            {
                //In-Game Pos
                Vector3 pivotPos = player.transform.position;
                Vector3 playerFootPos; playerFootPos.x = pivotPos.x; playerFootPos.z = pivotPos.z; playerFootPos.y = pivotPos.y - 2f;
                Vector3 playerHeadPos; playerHeadPos.x = pivotPos.x; playerHeadPos.z = pivotPos.z; playerHeadPos.y = pivotPos.y + 2f;

                //Screen Pos
                Vector3 w2s_footpos = Camera.main.WorldToScreenPoint(playerFootPos);
                Vector3 w2s_headpos = Camera.main.WorldToScreenPoint(playerHeadPos);

                if (w2s_footpos.z > 0f)
                {
                    DrawBoxESP(w2s_footpos, w2s_headpos, Color.blue);
                }
            }

        }

        public void DrawBoxESP(Vector3 footpos, Vector3 headpos, Color color)
        {
            float height = headpos.y - footpos.y;
            float widthOffset = 2f;
            float width = height / widthOffset;


            Render.DrawBox(footpos.x - width / 2, Screen.height - footpos.y - height, width, height, color, 2f);
        }

        ClientPlayer health = FindObjectOfType<ClientPlayer>();
        WeaponAnimation recoil = FindObjectOfType<WeaponAnimation>();
        ShopManager shopManager = FindObjectOfType<ShopManager>();
        PlayerController playerController = FindObjectOfType<PlayerController>();
        public void Update()
        {
            // health.health = 100f;
            ShopManager.Money = 100000f;

                if (Input.GetKeyUp(KeyCode.Delete))
            {
                Loader.Unload();
            }

        }


    }
}

