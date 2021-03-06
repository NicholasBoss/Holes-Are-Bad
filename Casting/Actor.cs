using System;
using HolesAreBad.Services;
namespace HolesAreBad.Casting
{
    /// <summary>
    /// Base class for all actors in the game.
    /// </summary>
    public class Actor
    {
        protected Point _position;
        protected Pointf _velocity;

        protected int _width = 0;
        protected int _height = 0;

        protected string _text = "";
        private string _image = "";

        private bool _using_gravity;

        private bool _jump_ready;

        private bool _jump;

        private double _jump_multiplier;

        public Actor()
        {
            // Start these at 0, 0 by default
            _position = new Point(0, 0);
            _velocity = new Pointf(0f, 0f);
            _using_gravity = false;
            _jump_ready = false;
            _jump = false;
            _jump_multiplier = 1;
        }

        public void SetUseGravity(bool using_gravity)
        {
            _using_gravity = using_gravity;
        }

        public bool GetUseGravity()
        {
            return _using_gravity;
        }

        public void SetJumpReady(bool jump_ready)
        {
            _jump_ready = jump_ready;
        }

        public bool GetJumpReady()
        {
            return _jump_ready;
        }

        public void SetJump(bool jump)
        {
            _jump = jump;
        }

        public double GetJumpMultiplier()
        {
            return _jump_multiplier;
        }

        public double UseJumpMultiplier()
        {
            double returnVal = _jump_multiplier;
            _jump_multiplier = 1;
            return returnVal;
        }

        public void AddJumpPower()
        {
            _jump_multiplier += 0.01;
        }

        public bool GetJump()
        {
            return _jump;
        }

        public void ChangeVelocityX()
        {
            Pointf velocity = GetVelocity();
            double x = velocity.GetX();
            double y = velocity.GetY();
            SetVelocity(new Pointf(-x,y));
        
        }
        public void ChangeVelocityY()
        {
            Pointf velocity = GetVelocity();
            double x = velocity.GetX();
            double y = velocity.GetY();
            SetVelocity(new Pointf(x,-y));
        }
        public void ChangeSpeed()
        {
            Pointf velocity = GetVelocity();
            double x = velocity.GetX();
            double newspeed = x + 0.5;
            int speed = Convert.ToInt32(newspeed);
            double y = velocity.GetY();
            SetVelocity(new Pointf(speed,-y));
        }

        // public bool IsFound()
        // {
        //     return (GetImage() == Constants.IMAGE_PENDANT);
        // }

        public void SetImage(string image)
        {
            _image = image;
        }

        public string GetImage()
        {
            return _image;
        }

        public bool HasImage()
        {
            return _image != "";
        }

        public bool HasText()
        {
            return _text != "";
        }

        public bool HasBox()
        {
            return _width > 0 && _height > 0;
        }

        public string GetText()
        {
            return _text;
        }

        public void SetText(string text)
        {
            _text = text;
        }

        public int GetX()
        {
            return _position.GetX();
        }

        public int GetY()
        {
            return _position.GetY();
        }

        public int GetLeftEdge()
        {
            return _position.GetX();
        }

        public int GetRightEdge()
        {
            return _position.GetX() + _width;
        }

        public int GetTopEdge()
        {
            return _position.GetY();
        }

        public int GetBottomEdge()
        {
            return _position.GetY() + _height;
        }

        public int GetWidth()
        {
            return _width;
        }

        public void SetWidth(int width)
        {
            _width = width;
        }

        public int GetHeight()
        {
            return _height;
        }

        public void SetHeight(int height)
        {
            _height = height;
        }

        public Point GetPosition()
        {
            return _position;
        }

        public void SetPosition(Point position)
        {
            _position = position;
        }

        public Pointf GetVelocity()
        {
            return _velocity;
        }

        public void SetVelocity(Pointf newVelocity)
        {
            _velocity = newVelocity;
        }

        public void MoveNext()
        {
            int x = _position.GetX();
            int y = _position.GetY();

            int dx = (int)_velocity.GetX();
            int dy = (int)_velocity.GetY();

            int newX = (x + dx) % Constants.MAX_X;
            int newY = (y + dy) % Constants.MAX_Y;

            if (newX < 0)
            {
                newX = Constants.MAX_X;
            }

            if (newY < 0)
            {
                newY = Constants.MAX_Y;
            }

            _position = new Point(newX, newY);
        }

        public override string ToString()
        {
            return $"Position: ({_position.GetX()}, {_position.GetY()}), Velocity({_velocity.GetX()}, {_velocity.GetY()})";
        }

    }

}