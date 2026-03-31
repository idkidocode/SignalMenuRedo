namespace SignalMenu
{
    public class CategoryActions
    {
        public static void ReDraw()
        {
            Main.DestroyMenu();
            Main.CreateMenu();
        }

        public static void NextPage()
        {
            Main.currentPage += 1;
            ReDraw();
        }

        public static void BackPage()
        {
            Main.currentPage -= 1;
            ReDraw();
        }

        public static void ReturnToHome()
        {
            Main.currentCat = 0;
            ReDraw();
        }

        public static void ToMovement()
        {
            Main.currentCat = 1;
            ReDraw();
        }

        public static void ToRig()
        {
            Main.currentCat = 2;
            ReDraw();
        }
    }
}