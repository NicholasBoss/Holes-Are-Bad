namespace HolesAreBad.Casting
{
    ///<summary>
    /// This class will handle all needed action with implementing the character of the game
    ///<summary>
    public class Enemy : Actor
    {
        private string _charimg = Constants.IMAGE_ENEMY;
        private int _charwidth = Constants.ENEMY_WIDTH;
        private int _charheight = Constants.ENEMY_HEIGHT;
        public Enemy()
        {
            SetImage(_charimg);
            SetHeight(_charheight);
            SetWidth(_charwidth);
        }
    }
}