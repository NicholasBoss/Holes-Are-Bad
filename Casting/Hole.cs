namespace HolesAreBad.Casting
{
    ///<summary>
    /// This class will handle all actions with the generation of hiding spots for the pendants
    ///<summary>
    public class Hole : Actor
    {
        private string _description;

        public Hole()
        {
            SetText("?");
            SetHeight(Constants.HOLE_HEIGHT);
            SetWidth(Constants.HOLE_WIDTH);
        }

        public string GetDescription()
        {
            return _description;
        }

        public void SetDescription(string description)
        {
            _description = description;
        }
        
        
    }
}