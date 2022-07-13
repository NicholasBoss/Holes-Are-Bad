namespace HolesAreBad.Casting
{
    ///<summary>
    /// This class will handle all actions with the generation of hiding spots for the pendants
    ///<summary>
    public class Hole : Actor
    {
        private string _charimg = Constants.IMAGE_HOLE;
        private int _charwidth = Constants.HOLE_WIDTH;
        private int _charheight = Constants.HOLE_HEIGHT;

        public Hole()
        {
            SetImage(_charimg);
            SetHeight(_charheight);
            SetWidth(_charwidth);
        }
        
    }
}