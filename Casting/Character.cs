namespace HolesAreBad.Casting
{
    ///<summary>
    /// This class will handle all needed action with implementing the character of the game
    ///<summary>
    public class Character : Actor
    {
        private string _charimg = Constants.IMAGE_CHARACTER;
        private int _charwidth = Constants.CHARACTER_WIDTH;
        private int _charheight = Constants.CHARACTER_HEIGHT;
        public Character()
        {
            SetImage(_charimg);
            SetHeight(_charheight);
            SetWidth(_charwidth);

            int x = Constants.MAX_X / 2;
            int y = Constants.MAX_Y / 2;
            Point position = new Point(x, y);
            SetPosition(position);

            SetVelocity(new Pointf(0, 0));
        }
    }
}