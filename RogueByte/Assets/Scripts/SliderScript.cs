using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SliderScript : MonoBehaviour
{

    TMP_Text volumeText;
    float volume = 100;
    public Slider volumeSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        volumeText = GameObject.Find("VolumeLevel").GetComponent<TMP_Text>();
        volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateVolumeText() {
        volume = volumeSlider.value;
        volumeText.GetComponent<TextMeshProUGUI>().text = volume.ToString();
        Debug.Log(volume);
    }
}
