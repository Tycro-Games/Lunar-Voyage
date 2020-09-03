using UnityEngine;

public class GoldenTree : MonoBehaviour
{
    private Market market;
    [SerializeField]
    private int energyGain = 1;
    void Awake()
    {
        market = FindObjectOfType<Market>();
    }
    public void AddEnergy()
    {
        market.Add(energyGain);
    }

}
