namespace HolesAreBad.Casting
{
    ///<summary>
    /// This class will handle all needed action with implementing the character of the game
    ///<summary>
    public class Collectable : Actor
    {
        private string _charimg = Constants.IMAGE_COLLECTABLE;
        private int _charwidth = Constants.COLLECTABLE_WIDTH;
        private int _charheight = Constants.COLLECTABLE_HEIGHT;
        public static int collectable = 0;
        public Collectable()
        {
            SetImage(_charimg);
            SetHeight(_charheight);
            SetWidth(_charwidth);
        }
    }
}