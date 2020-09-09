using UnityEngine;


public class GoldenTree : MonoBehaviour
{
    [SerializeField]
    private int energyGain = 1;

    public void AddEnergy()
    {
        MarketIntro.Add(energyGain);
    }

}
