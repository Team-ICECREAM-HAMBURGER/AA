using UnityEngine;

public class GCSingletonImplementer<T> : MonoBehaviour where T : Component {
    private static T instance;
    public static T Instance {
        get {
            if (isQuitting) {
                return null;
            }
            
            if (instance == null) {
                instance = (T)FindObjectOfType(typeof(T));
                
                if (instance == null) {
                    SetupInstance();
                }
            }
            
            return instance;
        }
    }
    private static bool isQuitting = false;

    
    public virtual void Awake() {
        RemoveDuplicates();
    }

    protected virtual void OnApplicationQuit() {
        isQuitting = true;
    }
    
    private static void SetupInstance() {
        instance = (T)FindObjectOfType(typeof(T));
        
        if (instance == null) {
            GameObject gameObj = new GameObject();
            gameObj.name = typeof(T).Name;
            instance = gameObj.AddComponent<T>();
            DontDestroyOnLoad(gameObj);
        }
    }

    private void RemoveDuplicates() {
        if (instance == null) {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this) {
            Destroy(gameObject);
        }
    }
}