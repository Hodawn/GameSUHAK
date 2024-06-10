using System;
using System.Diagnostics;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance = null;
    private static object _lock = new object();
    private static bool _applicationQuit = false;

    public static T Instance
    {
        get
        {
            if (_applicationQuit)
            {
                return null;
            }

            // thread-safe
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        string componentName = typeof(T).ToString();
                        try
                        {
                            GameObject findObject = GameObject.Find(componentName);
                            if (findObject == null)
                            {
                                findObject = new GameObject(componentName);
                            }

                            _instance = findObject.AddComponent<T>();
                            DontDestroyOnLoad(_instance);
                        }
                        catch (Exception e)
                        {
                            UnityEngine.Debug.Log(e.Message);
                        }
                    }
                }
                return _instance;
            }
        }
    }

    protected virtual void OnApplicationQuit()
    {
        _applicationQuit = true;
    }

    public virtual void OnDestroy()
    {
        _applicationQuit = true;
    }
}