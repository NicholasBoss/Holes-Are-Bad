namespace HolesAreBad.Casting
{
    ///<summary>
    /// This class will handle all needed action with implementing the character of the game
    ///<summary>
    public class FlyingEnemy : Actor
    {
        private string _charimg = Constants.IMAGE_FLYINGENEMY;
        private int _charwidth = Constants.FLYING_ENEMY_WIDTH;
        private int _charheight = Constants.FLYING_ENEMY_HEIGHT;
        public FlyingEnemy()
        {
            SetImage(_charimg);
            SetHeight(_charheight);
            SetWidth(_charwidth);
        }
    }
}