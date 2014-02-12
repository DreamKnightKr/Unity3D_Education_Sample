import UnityEngine

class GUIScript (MonoBehaviour):
	public objTextHello_Window as GameObject
	public objTextHello_iOS as GameObject
	public objTextHello_Android as GameObject
		
	def Start ():
		pass
	
	def Update ():
		pass
		
	def OnGUI() as void:
    	fPosX as double = 250
    	fPosY as double = 50
    	fYInterval as double = 4
    	nYPosCount as int = 10
    	
    	if GUI.Button(Rect(fPosX, fPosY + (fYInterval * nYPosCount), 200, 30), "Show Hello ~"):
    		// !! Boo currently supports only the ifdef directive. 
    		// [Unity Doc URL]
    		//	https://docs.unity3d.com/Documentation/Manual/PlatformDependentCompilation.html
    		ifdef UNITY_IPHONE:
            	GameObject.Instantiate( objTextHello_iOS );
            ifdef UNITY_ANDROID:
            	GameObject.Instantiate( objTextHello_Android );
            ifdef UNITY_STANDALONE_WIN:
            	GameObject.Instantiate( objTextHello_Window );
            	
