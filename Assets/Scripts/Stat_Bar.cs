using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat_Bar : MonoBehaviour
{
    public Slider slider;

    public void setStat(int stat)
    {
        slider.value = stat;
    }

    public void setMaxStat(int stat)
    {
        slider.maxValue = stat;
        slider.value = stat;
    }

}
