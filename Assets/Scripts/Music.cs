using UnityEngine;

public class Music : MonoBehaviour
{
    private static Music instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // keep this object across scenes
        }
        else
        {
            Destroy(gameObject); // prevent duplicates
        }
    }
}

