using System;

namespace HolesAreBad.Casting
{
    public class Spike : Actor
    {
        private string _spikeimg = Constants.IMAGE_SPIKE;
        private int _spikewidth = Constants.SPIKE_WIDTH;
        private int _spikeheight = Constants.SPIKE_HEIGHT;
        public Spike()
        {
            SetImage(_spikeimg);
            SetWidth(_spikewidth);
            SetHeight(_spikeheight);
        }
    }
}