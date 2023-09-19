using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] private Slider _slider;


    protected void ChangeValueTo(int targetValue, int maxValue)
    {
        _slider.value = (float)targetValue / maxValue;
    }
}
