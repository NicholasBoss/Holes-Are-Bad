using System.Collections.Generic;
using HolesAreBad.Casting;

namespace HolesAreBad
{
    /// <summary>
    /// The TitleScreen class is responsible for handling the title screen of the game.
    /// </summary>
    public class TitleScreen
    {
        //create the cast
        private Dictionary<string, List<Actor>> _cast = new Dictionary<string, List<Actor>>();

        //environment objects
        _cast["Cenvironment"] = new List<Actor>();
        private CreditImage _background = new CreditImage();
        _cast["Cenvironment"].Add(_background);

    }}