namespace HolesAreBad.Casting
{
    ///<summary>
    /// This class will handle all needed action with implementing the character of the game
    ///<summary>
    public class Collectableenv : Actor
    {
        public static int collectable = 0;
        public Collectableenv()
        {
            SetText($"Collectables: {collectable}/10");
            Point position = new Point(Constants.MAX_X - 360, 0);
            SetPosition(position);
            
        }
    }
}