using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class FlashControl : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = StatsManager.instance.flashIntensity;
        slider.onValueChanged.AddListener(UpdateFlashIntensity);
    }

    void UpdateFlashIntensity(float value)
    {
        StatsManager.instance.flashIntensity = value;
    }
}

