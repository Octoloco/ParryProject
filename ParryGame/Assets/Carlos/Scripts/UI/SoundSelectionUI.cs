using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoundSelectionUI : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] SoundCollection collection;
    [SerializeField] Text visualFeedback;
    // Start is called before the first frame update
    void Awake()
    {
        collection.SetVolume(0.5f);
        slider.value = 0.5f;
        visualFeedback.text = ((int)(slider.value * 100)).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        visualFeedback.text = ((int)(slider.value*100)).ToString();
    }
}
