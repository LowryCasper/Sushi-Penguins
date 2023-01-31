using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    public Toggle bgmToggle;
    public Toggle sfxToggle;
    public GameObject setting;

    public bool toogle;

    private const string BGM_MUTE_KEY = "bgmMute";
    private const string SFX_MUTE_KEY = "sfxMute";
    private const string BGM_TOGGLE_KEY = "bgmToggle";
    private const string SFX_TOGGLE_KEY = "sfxToggle";

    public AudioSource bgmSource;
    public AudioSource sfxSource;

    // Start is called before the first frame update
    void Start()
    {
        bgmSource = GameObject.Find("BGM").GetComponent<AudioSource>();
        sfxSource = GameObject.Find("SFX").GetComponent<AudioSource>();
        // Load saved mute values from PlayerPrefs
        bgmSource.mute = PlayerPrefs.GetInt(BGM_MUTE_KEY, 0) == 1 ? true : false;
        sfxSource.mute = PlayerPrefs.GetInt(SFX_MUTE_KEY, 0) == 1 ? true : false;

        // Load saved toggle state from PlayerPrefs
        bgmToggle.isOn = PlayerPrefs.GetInt(BGM_TOGGLE_KEY, 0) == 1 ? true : false;
        sfxToggle.isOn = PlayerPrefs.GetInt(SFX_TOGGLE_KEY, 0) == 1 ? true : false;

        bgmToggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(bgmToggle, bgmSource, BGM_MUTE_KEY, BGM_TOGGLE_KEY);
        });

        sfxToggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(sfxToggle, sfxSource, SFX_MUTE_KEY, SFX_TOGGLE_KEY);
        });

       // bgmToggle.onValueChanged.AddListener(delegate {
        //    ToggleValueChanged(bgmToggle, //bgmSource);
       // });

       // sfxToggle.onValueChanged.AddListener(delegate {
       //     ToggleValueChanged(sfxToggle,//sfxSource);
       // });
    }
    public void ToggleValueChanged(Toggle toggle, AudioSource audioSource, string muteKey, string toggleKey)
        // void ToggleValueChanged(Toggle toggle, AudioSource audioSource)
    {
        audioSource.mute = !toggle.isOn;
        
           
            Debug.Log("AudioSetting is Saved");

            PlayerPrefs.SetInt(muteKey, audioSource.mute ? 1 : 0);
            PlayerPrefs.SetInt(toggleKey, toggle.isOn ? 1 : 0);
            PlayerPrefs.Save();
        
      
        
    }

    public void CloseSetting()
    {
        setting.SetActive(false);
    }
     
    public void OpenSetting()
    {
        setting.SetActive(true);
    }
}
