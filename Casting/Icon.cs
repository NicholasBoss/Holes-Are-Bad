using System;
using Raylib_cs;

namespace HolesAreBad
{
    public class Icon : Actor
    {
        private string _icon = Constants.IMAGE_ICON;
        public Icon()
        {
            SetImage(_icon);
            SetHeight(Constants.ICON_HEIGHT);
            SetWidth(Constants.ICON_WIDTH);
        }
    }
}