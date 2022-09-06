using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GUIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI lblGold;

    public void SetGoldAmmount(int goldAmmount)
    {
        lblGold.text = goldAmmount.ToString();
    }
}
