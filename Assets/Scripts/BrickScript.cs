using UnityEngine;

public class BrickScript : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Number of hits to break (destroy) the brick")]
    int hitsToBreak;
    [SerializeField]
    [Tooltip("Points given for destryoing the brick")]
    int points;
    [SerializeField]
    [Tooltip("Colors to switch after hit")]
    Color[] spriteColors = new Color[3];

    public void BrickBreak()
    {
        GetComponent<SpriteRenderer>().color = spriteColors[--hitsToBreak - 1];
    }

    public int GetHitsToBreak()
    {
        return hitsToBreak;
    }

    public int GetPoints()
    {
        return points;
    }

}
