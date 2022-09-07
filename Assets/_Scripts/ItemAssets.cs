using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    public Sprite redShirt, greenShirt, blueShirt;
    public Sprite redPants, greenPants, bluePants;
    public Sprite redShoes, tanShoes, blackShoes;
}
