using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager 
{
    private static GameManager _Instance;
    public static GameManager Instance
    {
        get{
            if(_Instance==null){
                _Instance=new GameManager();
            }
            return _Instance;
        }
    }
    public CharacterType CharacterType {
        get{
            return(CharacterType)PlayerPrefs.GetInt(GameDefine.playerRole);
        }
    }
   public void LoadScence (string sceneName){
       SceneManager.LoadScene(sceneName);
   }
   public T LoadResources<T>(string path) where T:Object
   {
       Object obj =Resources.Load(path);
       if (obj==null){
           return null;
       }
       return (T)obj;
   }
}
