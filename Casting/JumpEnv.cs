namespace HolesAreBad.Casting
{
    ///<summary>
    /// This class will handle all needed action with implementing the character of the game
    ///<summary>
    public class JumpEnv : Actor
    {
        public static int collectable = 0;
        public JumpEnv()
        {
            Point position = new Point(Constants.MAX_X - 545, 0);
            SetPosition(position);
        }
    }
}