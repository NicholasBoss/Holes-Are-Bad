using System;

namespace HolesAreBad.Casting
{
    public class GhostBlock : Actor
    {
        private string _platimg = Constants.IMAGE_GHOST_BLOCK;
        private int _platwidth = Constants.PLATFORM_WIDTH;
        private int _platheight = Constants.PLATFORM_HEIGHT;
        public GhostBlock()
        {
            SetImage(_platimg);
            SetHeight(_platheight);
            SetWidth(_platwidth);
        }
}
}