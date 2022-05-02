using System;
using System.Collections.Generic;
using THETHREEPENDANTS.Casting;

namespace THETHREEPENDANTS
{
    /// <summary>
    /// The base class of all other actions.
    /// </summary>
    public abstract class Action
    {
        public abstract void Execute(Dictionary<string, List<Actor>> cast);
    }
}