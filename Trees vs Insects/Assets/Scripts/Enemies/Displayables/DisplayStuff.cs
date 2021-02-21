using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class DisplayStuff : DisplayStuffBase
    {
        protected DisplayPathManager displayPathManager = new DisplayPathManager ();

        public virtual void Reset ()
        {
            displayPathManager.Reset ();
        }
    }
}