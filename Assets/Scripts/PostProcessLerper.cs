using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;
using UnityEngine.PostProcessing;

public class PostProcessLerper : MonoBehaviour
{
	public PostProcessingProfile nextProfile;

	private PostProcessingProfile profile;

	private PostProcessingBehaviour pPBehaviour;
	
	
	#region settings

	private AmbientOcclusionModel.Settings AOSettings;

	private BloomModel.Settings BloomSettings;

	private ColorGradingModel.Settings CGSettings;

	private UserLutModel.Settings LUTSettings;

	#endregion

	public PostProcessingProfile test1;
	public PostProcessingProfile test2;

	
	private void Start()
	{
		
		//empeche que le post process soit altéré par le playmode
		pPBehaviour = Camera.main.GetComponent<PostProcessingBehaviour>();
		profile = Instantiate(pPBehaviour.profile);
		pPBehaviour.profile = profile;
	}

//	void Update()
//	{
//		if (Input.GetKeyDown(KeyCode.A))
//		{
//			ChangePostProcess(nextProfile, 1);
//		}
//		if (Input.GetKeyDown(KeyCode.Z))
//		{
//			ChangePostProcess(test1, 2);
//		}if (Input.GetKeyDown(KeyCode.E))
//		{
//			ChangePostProcess(test2, 10);
//		}
//	}

	public void ChangePostProcess(PostProcessingProfile _profile, float _length)
	{
		StopAllCoroutines();
		StartCoroutine(PPLerp(_profile, _length));
	}

	IEnumerator PPLerp(PostProcessingProfile _profile, float _length)
	{
		float _i = 0;


		AOSettings = profile.ambientOcclusion.settings;
		BloomSettings = profile.bloom.settings;
		CGSettings = profile.colorGrading.settings;
		LUTSettings = profile.userLut.settings;

		float _AOIntensity = AOSettings.intensity;
		float _BloomIntensity = BloomSettings.bloom.intensity;

		float _temp = CGSettings.basic.temperature;
		float _exp = CGSettings.basic.postExposure;
		float _tint = CGSettings.basic.tint;
		float _hue = CGSettings.basic.hueShift;

		float _lut = LUTSettings.contribution;
		
		float _lerpValue = 0;
		
		while (_i <= _length)
		{
			_lerpValue = _i / _length;

			AOSettings.intensity = Mathf.Lerp(_AOIntensity, _profile.ambientOcclusion.settings.intensity, _lerpValue);

			BloomSettings.bloom.intensity = Mathf.Lerp(_BloomIntensity, _profile.bloom.settings.bloom.intensity, _lerpValue);
			
			CGSettings.basic.temperature = Mathf.Lerp(_temp, _profile.colorGrading.settings.basic.temperature, _lerpValue);
			CGSettings.basic.postExposure = Mathf.Lerp(_exp, _profile.colorGrading.settings.basic.postExposure, _lerpValue);
			CGSettings.basic.tint = Mathf.Lerp(_tint, _profile.colorGrading.settings.basic.tint, _lerpValue);
			CGSettings.basic.hueShift = Mathf.Lerp(_hue, _profile.colorGrading.settings.basic.hueShift, _lerpValue);
			
			LUTSettings.contribution = Mathf.Lerp(_lut, _profile.userLut.settings.contribution, _lerpValue);

			profile.ambientOcclusion.settings = AOSettings;
			profile.bloom.settings = BloomSettings;
			profile.colorGrading.settings = CGSettings;
			profile.userLut.settings = LUTSettings;
			
			_i += Time.deltaTime;
			yield return null;
		}

	}
	
}
