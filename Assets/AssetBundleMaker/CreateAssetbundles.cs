using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class CreateAssetbundles {

	[MenuItem("Assets/User Select Dir Path(+Track Dependency)")]
	static void CreateTableAssetbundles()
	{
        string strPath = GetOutputDir() + "SelectDirPath_Def.assetbundle";

		CreateTableAssetBundles(
			strPath,
			Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets),
			"",
			BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets);
	}

    [MenuItem("AssetBuilder/Fix Dir Path(Packing Target+Track Dependency)")]
    static void CreateTableAssetbundlesFixPath()
    {
        string strPath = GetOutputDir() + "SelectDirPath_Def.assetbundle";
        string[] strResPaths = AssetDatabase.GetAllAssetPaths();
        ArrayList objs = new ArrayList();

        foreach(string strResPath in strResPaths)
        {
            if( strResPath.Contains("Assets/ForAssetBundle/PackingTargets") )
               objs.Add( AssetDatabase.LoadMainAssetAtPath(strResPath) );
        }
        CreateTableAssetBundles(
            strPath,
            objs.ToArray(),
            "",
            BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets);
    }
	
	static void CreateTableAssetBundles(string strPath, object[] objs, string strExternFilter, BuildAssetBundleOptions op)
	{
		Debug.Log("* Creating assetbundles. Start");
		
		ArrayList objsToBundle = new ArrayList();
		foreach (Object obj in objs)
		{
			if((null == strExternFilter || "" == strExternFilter)
				|| AssetDatabase.GetAssetPath(obj).Contains("." + strExternFilter))
			{
				objsToBundle.Add(obj);
				Debug.Log("* Add to AssetBundle : " + AssetDatabase.GetAssetPath(obj));
			}
		}
		
		if(0 < objsToBundle.Count)
		{
			
			BuildPipeline.BuildAssetBundle(
				null, 
				(Object[])objsToBundle.ToArray(typeof(UnityEngine.Object)),
				strPath, 
				op,
				AssetBundleTarget); 
		}
		else
			Debug.LogWarning("Nothing To Add > Skip Build AssetBundle.");
		
        Debug.Log("* Creating Tables assetbundles.\n > " + strPath);
	}

	static string GetOutputDir()
	{
		string strPath = AssetbundlePath;
		if (!Directory.Exists(strPath))
		{
			Directory.CreateDirectory(strPath);
		}
		return strPath;
	}
	
	public static string AssetbundlePath
	{
		#if UNITY_ANDROID
		get { return "assetbundles" + Path.DirectorySeparatorChar + "android" + Path.DirectorySeparatorChar; }
		#elif UNITY_IPHONE
		get { return "assetbundles" + Path.DirectorySeparatorChar + "ios" +  Path.DirectorySeparatorChar; }
		#else
		get { return "assetbundles" + Path.DirectorySeparatorChar + "android" +  Path.DirectorySeparatorChar; }
		#endif
	}
	
	public static BuildTarget AssetBundleTarget
	{
		#if UNITY_ANDROID
		get { return BuildTarget.Android; }
		#elif UNITY_IPHONE
		get { return BuildTarget.iPhone; }
		#else
		get { return BuildTarget.Android; }
		#endif
	}
}