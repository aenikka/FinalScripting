﻿using UnityEngine;

// <T> can be any type.
public class Singleton<T> : MonoBehaviour where T : Component
{
    // The instance is accessible only by the getter.
    private static T m_Instance;

    public static T Instance
    {
        get
        {
            if (m_Instance == null)
            {
                // Making sure that there's not other instances
                // of the same type in memory.
                m_Instance = FindObjectOfType<T>();

                if (m_Instance == null)
                {
                    // Making sure that there's not other instances
                    // of the same type in memory.
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    m_Instance = obj.AddComponent<T>();
                }
            }
            return m_Instance;
        }
    }

    // Virtual Awake() that can be overridden in a derived class.
    public virtual void Awake()
    {
        if (m_Instance == null)
        {
            // If null, this instance is now the Singleton instance
            // of the assigned type.
            m_Instance = this as T;

            // Making sure that my Singleton instance
            // will persist in memory across every scene.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // Destroy current instance because it must be a duplicate.
            Destroy(gameObject);
        }
    }
}
