using UnityEngine;
using UnityEngine.UI;

public class CubeManager : MonoBehaviour
{
    [Header("Cube Info")]
    public GameObject cubePrefab;
    [Range(2, 100)]
    public int cubeAmount = 20;
    public float cubeSpacing = 1.0f;

    [Header("Randomized Height Amount")]
    public float minHeight = 1f;
    public float maxHeight = 15f;

    [Header("UI Stuff")]
    public Slider cubeAmountSlider;
    public TMPro.TextMeshProUGUI cubeAmountLabel;
    public Button resetButton;

    protected GameObject[] cubes;

    public GameObject[] Cubes => cubes;

    private void Start()
    {
        cubeAmountSlider.value = cubeAmount;
        cubeAmountSlider.onValueChanged.AddListener(OnCubeAmountSliderChanged);
        resetButton.onClick.AddListener(ResetButton);

        GenerateCubes();
    }

    public void ResetButton()
    {
        GenerateCubes();
    }
    

    public void OnCubeAmountSliderChanged(float value)
    {
        cubeAmount = Mathf.RoundToInt(value);

        cubeAmountLabel.text = $"Cubes: {cubeAmount}";

        GenerateCubes();
    }

    public void GenerateCubes()
    {
        if (cubes != null)
        {
            foreach (GameObject cube in cubes) 
                Destroy(cube);
        }

        cubes = new GameObject[cubeAmount];
        float startX = -(cubeAmount / 2f) * cubeSpacing;

        for (int i = 0; i < cubeAmount; i++)
        {
            Vector3 pos = new Vector3(startX + i * cubeSpacing, 0, 0);
            cubes[i] = Instantiate(cubePrefab, pos, Quaternion.identity, transform);
        }

        RandomizeHeights();
    }

    public void RandomizeHeights()
    {
        foreach (GameObject cube in cubes)
        {
            float height = Random.Range(minHeight, maxHeight);
            Vector3 scale = cube.transform.localScale;
            scale.y = height;
            cube.transform.localScale = scale;
            cube.transform.position = new Vector3(cube.transform.position.x, 0f, 0);
        }
    }
}
