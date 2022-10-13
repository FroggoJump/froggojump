using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    [SerializeField] Material froggoMaterial;
    [SerializeField] Texture2D pink;
    [SerializeField] Texture2D yellow;
    [SerializeField] Texture2D red;
    [SerializeField] Texture2D green;
    [SerializeField] Texture2D purple;


   
    public void ChangeColor(string color)
    {
        switch (color)
        {
            case "pink":
                froggoMaterial.SetTexture("TextureAlbedo", pink);
                break;
            case "yellow":
                froggoMaterial.SetTexture("TextureAlbedo", yellow);
                break;
            case "red":
                froggoMaterial.SetTexture("TextureAlbedo", red);
                break;
            case "green":
                froggoMaterial.SetTexture("TextureAlbedo", green);
                break;
            case "purple":
                froggoMaterial.SetTexture("TextureAlbedo", purple);
                break;

        }
    }
}
