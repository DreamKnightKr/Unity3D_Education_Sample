import UnityEngine

class AssetBundleHelperBoo (MonoBehaviour): 
	static public AssetbundleSubPath as string:
		get:
			ifdef UNITY_ANDROID:
				return "/android/";
			ifdef UNITY_IPHONE:
				return "/ios/";
				
			return "/android/";
