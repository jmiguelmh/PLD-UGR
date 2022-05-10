using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumen;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("volumen"))
        {
            PlayerPrefs.SetFloat("volumen", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void cambiarVolumen()
    {
        AudioListener.volume = volumen.value;
        Save();
    }

    private void Load()
    {
        volumen.value = PlayerPrefs.GetFloat("volumen");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("volumen", volumen.value);
    }
}
