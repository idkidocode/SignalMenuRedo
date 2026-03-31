using UnityEngine.UI;

namespace SignalMenu
{
    public class Buttons
    {
        public static List<ButtonData> buttonList = new List<ButtonData>
        {
            //Categorys
            new ButtonData("Movement", CategoryActions.ToMovement, false, 0, 1),//Cat 1
            new ButtonData("Rig", CategoryActions.ToRig, false, 0, 1),//Cat 2

            //Movements Mods
            new ButtonData("-->", CategoryActions.NextPage, false, 1, 99),
            new ButtonData("<--", CategoryActions.BackPage, false, 1, 99),
            new ButtonData("Return To Main", CategoryActions.ReturnToHome, false, 1, 99),
            new ButtonData("Speed Boost", MovementMods.SpeedBoost, true, 1, 1),
            new ButtonData("Fly", MovementMods.Fly, true, 1, 1),

            //Visual Mods
            new ButtonData("-->", CategoryActions.NextPage, false, 2, 99),
            new ButtonData("<--", CategoryActions.BackPage, false, 2, 99),
            new ButtonData("Return To Main", CategoryActions.ReturnToHome, false, 2, 99),
            
        };

        
        public static void AllButtons()
        {
            int buttonIndex = 0;
            for (int i = 0; i < buttonList.Count; i++)
            {
                if (Main.currentCat == buttonList[i].TargetCat)
                {
                    if(buttonList[i].TargetPage == 99)
                    {
                        float zOffset = 0.15f - (buttonIndex * 0.05f);
                        Main.AddButton(zOffset, buttonList[i].Name, buttonList[i].Action, buttonList[i].IsToggleable);
                        buttonIndex++;
                    }
                    else if(Main.currentPage == buttonList[i].TargetPage && buttonList[i].TargetPage != 99)
                    {
                        float zOffset = 0.15f - (buttonIndex * 0.05f);
                        Main.AddButton(zOffset, buttonList[i].Name, buttonList[i].Action, buttonList[i].IsToggleable);
                        buttonIndex++;
                    }
                }
            }
        }
    }
}