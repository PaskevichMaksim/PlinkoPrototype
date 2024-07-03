using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (T)FindObjectOfType(typeof(T));

                if (FindObjectsOfType(typeof(T)).Length > 1)
                {
                    return _instance;
                }
            }
            if (_instance == null)
            {
                _instance = new GameObject().AddComponent<T>();
            }
            
            return _instance;
        }
    }
}
