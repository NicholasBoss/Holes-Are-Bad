namespace HolesAreBad.Casting
{
    ///<summary>
    /// This class will handle all needed action with implementing the character of the game
    ///<summary>
    public class JumpingEnemy : Actor
    {
        private string _charimg = Constants.IMAGE_JUMPING_ENEMY;
        private int _charwidth = Constants.JUMPING_ENEMY_WIDTH;
        private int _charheight = Constants.JUMPING_ENEMY_HEIGHT;
        public JumpingEnemy()
        {
            SetImage(_charimg);
            SetHeight(_charheight);
            SetWidth(_charwidth);
        }
    }
}