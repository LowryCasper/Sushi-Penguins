using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    public Toggle bgmToggle;
    public Toggle sfxToggle;
    public GameObject setting;

    private const string BGM_MUTE_KEY = "bgmMute";
    private const string SFX_MUTE_KEY = "sfxMute";
    private const string BGM_TOGGLE_KEY = "bgmToggle";
    private const string SFX_TOGGLE_KEY = "sfxToggle";

    public AudioSource bgmSource;
    public AudioSource sfxSource;

    private void Awake()
    {
        //bgmSource = GameObject.Find("BGM").GetComponent<AudioSource>();
        // sfxSource = GameObject.Find("SFX").GetComponent<AudioSource>();
        // Load saved mute values from PlayerPrefs

        if (PlayerPrefs.HasKey(BGM_MUTE_KEY))
        {
            bgmSource.mute = PlayerPrefs.GetInt(BGM_MUTE_KEY, 0) == 1 ? true : false;
        }
        bgmSource.mute = PlayerPrefs.GetInt(BGM_MUTE_KEY, 0) == 1 ? true : false;
        if (PlayerPrefs.HasKey(SFX_MUTE_KEY))
        {
            sfxSource.mute = PlayerPrefs.GetInt(SFX_MUTE_KEY, 0) == 1 ? true : false;
        }
           

        // Load saved toggle state from PlayerPrefs
        if (PlayerPrefs.HasKey(BGM_TOGGLE_KEY))
        {
            bgmToggle.isOn = PlayerPrefs.GetInt(BGM_TOGGLE_KEY, 0) == 1 ? true : false;
        }

        if (PlayerPrefs.HasKey(SFX_TOGGLE_KEY))
        {
            sfxToggle.isOn = PlayerPrefs.GetInt(SFX_TOGGLE_KEY, 0) == 1 ? true : false;
        }
          
    }
    // Start is called before the first frame update
    void Start()
    {
       

        bgmToggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(bgmToggle, bgmSource, BGM_MUTE_KEY, BGM_TOGGLE_KEY);
        });

        sfxToggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(sfxToggle, sfxSource, SFX_MUTE_KEY, SFX_TOGGLE_KEY);
        });


    }
    public void ToggleValueChanged(Toggle toggle, AudioSource audioSource, string muteKey, string toggleKey)
        // void ToggleValueChanged(Toggle toggle, AudioSource audioSource)
    {
       audioSource.mute = !toggle.isOn;
        
           
            Debug.Log("AudioSetting is Saved");

            PlayerPrefs.SetInt(BGM_MUTE_KEY, audioSource.mute ? 1 : 0);
        PlayerPrefs.SetInt(SFX_MUTE_KEY, audioSource.mute ? 1 : 0);
        PlayerPrefs.SetInt(BGM_TOGGLE_KEY, toggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt(SFX_TOGGLE_KEY, toggle.isOn ? 1 : 0);

        PlayerPrefs.Save();
        
      
        
    }
    private void Update()
    {
        
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
