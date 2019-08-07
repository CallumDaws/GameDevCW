using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

	public AudioMixer audioMixer;

	public Dropdown resolutionDropdown;

	public GameObject mainMenu;

	Resolution[] resolutions;

	public bool hide;


	void Start()
	{

		resolutions = Screen.resolutions;
		Debug.Log (resolutions);

		resolutionDropdown.ClearOptions();

		List<string> options = new List<string>();

		int currentResolutionIndex = 0;

		for(int i =0; i<resolutions.Length; i++){
			string option = resolutions[i].width + " x " + resolutions[i].height + " (" + resolutions[i].refreshRate + "hz)";
			options.Add(option);
			if (resolutions[i].width == Screen.width && 
				resolutions[i].height == Screen.height && resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
			{
				currentResolutionIndex = i;
			}
		}

		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currentResolutionIndex;
		resolutionDropdown.RefreshShownValue();
	}

	public void backButtonConfig(){
		if (hide == true) {
			mainMenu.SetActive (true);
		} else {
			mainMenu.SetActive (false);
		}
	}


	public void setVolume(float volume){
		audioMixer.SetFloat ("volume", volume);
}

	public void setQuality(int qualityValue){
		QualitySettings.SetQualityLevel (qualityValue);
}
		
	public void setFullscreen(bool isFullscreen){
		Screen.fullScreen = isFullscreen;
	}

	public void setResolution(int resolutionValue){
		Resolution resolution = resolutions[resolutionValue];
		Screen.SetResolution (resolution.width, resolution.height, Screen.fullScreen);
	}
		
}
