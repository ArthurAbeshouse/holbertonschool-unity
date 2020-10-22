using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFXSlider : MonoBehaviour
{
    public AudioMixer sfx_mix_a_lot;

    public void SetVol (float sliderValues)
    {
        sfx_mix_a_lot.SetFloat("SFX", Mathf.Log10(sliderValues) * 20);
    }
}
