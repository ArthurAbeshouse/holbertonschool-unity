using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGMSlider : MonoBehaviour
{
    public AudioMixer bgm_mix_a_lot;

    public void SetVol (float sliderValues)
    {
        bgm_mix_a_lot.SetFloat("BGM", Mathf.Log10(sliderValues) * 20);
    }
}
