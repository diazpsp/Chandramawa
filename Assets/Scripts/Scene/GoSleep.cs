
using UnityEngine;

public class GoSleep : MonoBehaviour
{

    [SerializeField] TimeManager timeManager;
    [SerializeField] private float Sleep = 0.5f;

    public string sceneName;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            timeManager = FindObjectOfType<TimeManager>();
            timeManager.TimeLeft = Sleep;

        }
    }
}
