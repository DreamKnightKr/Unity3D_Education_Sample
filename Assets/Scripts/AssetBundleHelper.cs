using UnityEngine;
using System.Collections;

public class AssetBundleHelper {

	public static string AssetbundleSubPath
	{
		#if UNITY_ANDROID
		get { return "/android/"; }
		#elif UNITY_IPHONE
		get { return "/ios/"; }
		#else
		get { return "/android/"; }
		#endif
	}
}
