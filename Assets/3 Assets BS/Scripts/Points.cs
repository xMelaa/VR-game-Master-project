using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
   public redSaber redSaber;
   public blueSaber blueSaber;
    public int points = 0;
    
    public TextMeshProUGUI textPoints;

    void Update()
    {
        redSaber = FindObjectOfType<redSaber>();
        blueSaber = FindObjectOfType<blueSaber>();
        points = redSaber.point + blueSaber.point;
        textPoints.text = points.ToString();
    }
}
