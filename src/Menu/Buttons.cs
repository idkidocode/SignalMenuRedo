using UnityEngine.UI;

namespace SignalMenu
{
    public class Buttons
    {
        public static List<ButtonData> buttonList = new List<ButtonData>
        {
            //Categorys
            new ButtonData("Movement", CategoryActions.ToMovement, false, 0, 1),
            new ButtonData("Rig", CategoryActions.ToRig, false, 0, 1),

            //Movements Mods
            new ButtonData("Return To Main", CategoryActions.ReturnToHome, false, 1, 1),
            new ButtonData("Speed Boost", MovementMods.SpeedBoost, true, 1, 1),
            new ButtonData("Fly", MovementMods.Fly, true, 1, 1),

            //Visual Mods
            new ButtonData("Return To Main", CategoryActions.ReturnToHome, false, 2, 1),
            new ButtonData("NameTags", RigMods.NameTags, true, 2, 1)
            
        };

        
        public static void AllButtons()
        {
            int buttonIndex = 0;
            for (int i = 0; i < buttonList.Count; i++)
            {
                if (Main.currentCat == buttonList[i].TargetCat && Main.currentPage == buttonList[i].TargetPage)
                {
                    float zOffset = 0.15f - (buttonIndex * 0.05f);
                    Main.AddButton(zOffset, buttonList[i].Name, buttonList[i].Action, buttonList[i].IsToggleable);
                    buttonIndex++;
                }
            }
        }
    }
}