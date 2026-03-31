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
            Main.currentPage = 1;
            Main.currentCat = 0;
            ReDraw();
        }

        public static void ToMovement()
        {
            Main.currentPage = 1;
            Main.currentCat = 1;
            ReDraw();
        }

        public static void ToRig()
        {
            Main.currentPage = 1;
            Main.currentCat = 2;
            ReDraw();
        }
    }
}