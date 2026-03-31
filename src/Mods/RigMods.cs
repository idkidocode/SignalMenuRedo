using SignalMenu;

namespace SignalMenu
{
    public class RigMods
    {
        public static void NameTags()
        {
            foreach(NetPlayer netPlayer in PhotonNetwork.PlayerList)
            {
                var rig = GorillaGameManager.instance.FindPlayerVRRig(netPlayer);
                
                if(!rig.isOfflineVRRig && !rig.isMyPlayer)
                {
                    var NameTags = new GameObject("NameTags");
                    NameTags.transform.SetParent(rig.transform);
                    NameTags.transform.LookAt(Camera.main.transform.position);
                    NameTags.transform.Rotate(0f, 100f, 0f);
                    
                    var tmp = NameTags.AddComponent<TextMeshPro>();
                    tmp.text = netPlayer.NickName;
                    tmp.fontSize = 2f;
                    tmp.alignment = TextAlignmentOptions.Center;
                    tmp.color = Themes.TextColor;
                    NameTags.GetComponent<TextMeshPro>().renderer.material.shader = Shader.Find("GUI/Text Shader");
                    
                }
            }
        }
    }
}