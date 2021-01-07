using Bogadanul.Assets.Scripts.Player;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class MarketGetter : MonoBehaviour
    {
        protected MarketIntro market;

        protected void GetMarket ()
        {
            market = FindObjectOfType<MarketIntro> ();
        }
    }
}