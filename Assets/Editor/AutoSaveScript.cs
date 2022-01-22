using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class AutoSaveScript : MonoBehaviour
{
   static AutoSaveScript()
   {
      EditorApplication.playModeStateChanged += SaveOnPlay;
   }

   private static void SaveOnPlay(PlayModeStateChange state)
   {
      if (state == PlayModeStateChange.ExitingEditMode)
      {
         Debug.Log("Zapisano...");
         EditorSceneManager.SaveOpenScenes();
         AssetDatabase.SaveAssets();
      }
   }
   
}
