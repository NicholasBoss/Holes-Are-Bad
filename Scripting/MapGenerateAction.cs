using System.Collections.Generic;
using HolesAreBad.Casting;

namespace HolesAreBad.Scripting
{
    ///<summary>
    /// This class will control how each actor will act when collided with.
    ///<summary>
    public class MapGenerateAction : UpdateAction
    {

        FileGenerator fgenerator;
        public MapGenerateAction(FileGenerator generator)
        {
            fgenerator = generator;
        }

        public override bool Execute(Dictionary<string, List<Actor>> cast)
        {
            int genMarkerX = cast["map_gen_marker"][0].GetX();
            if (genMarkerX < Constants.MAX_X * 1.5) {
                int horizontalOffset = fgenerator.Generate(cast, genMarkerX);
                cast["map_gen_marker"][0].SetPosition(new Point(genMarkerX + horizontalOffset, 0));
            }
            return true;
        }
    }
}