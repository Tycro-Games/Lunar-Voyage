﻿using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class DisplayStuff : DisplayStuffBase
    {
        public DisplayPathManager displayPathManager = new DisplayPathManager ();

        public virtual void Reset ()
        {
            displayPathManager.Reset ();
        }

        public virtual void Init ()
        {
            MakeObjects ();
            displayPathManager = new DisplayPathManager ();
        }
    }
}