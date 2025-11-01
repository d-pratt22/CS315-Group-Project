using UnityEngine;

public class GUIButtons : MonoBehaviour
{
    public GameObject cubePrefab;
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 30, 100, 30), "Spawn cube"))
            Instantiate(cubePrefab);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
