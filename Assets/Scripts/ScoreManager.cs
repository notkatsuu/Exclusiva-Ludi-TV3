using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton instance

    public int score; // Your score variable

    void Awake()
    {
        Cursor.visible = true;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // This object will persist across scenes
        }
        else
        {
            Destroy(gameObject); // If a ScoreManager already exists, destroy this one
        }
    }

    // Add any methods you need to manipulate the score here
}

