using System;

namespace HolesAreBad.Casting
{
    public class Platform : Actor
    {
        private string _platimg = Constants.IMAGE_PLATFORM;
        private int _platwidth = Constants.PLATFORM_WIDTH;
        private int _platheight = Constants.PLATFORM_HEIGHT;
        public Platform()
        {
            SetImage(_platimg);
            SetHeight(_platheight);
            SetWidth(_platwidth);
        }
}
}