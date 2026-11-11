using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool IsbuildTower {set; get;}

    private void Awake()
    {
        IsbuildTower = false;
    }
}
