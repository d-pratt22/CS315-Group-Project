using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq.Expressions;
public class SortingManager : MonoBehaviour
{
    [Header("UI Stuff")]
    public TMP_Dropdown algorithmChooser;
    public static int mode;
    public Button startButton;

    private CubeManager cubeManager;
    private BubbleSort bubbleSort;
    private InsertionSort insertionSort;

    private void Awake()
    {
        cubeManager = GetComponent<CubeManager>();

        bubbleSort = GetComponent<BubbleSort>();

        insertionSort = GetComponent <InsertionSort>();
    }

    private void Start()
    {
        startButton.onClick.AddListener(StartButtonClicked);
    }

    public void StartButtonClicked()
    {
        switch(mode)
        {
            case 0:
                StartCoroutine(bubbleSort.SortCubes(cubeManager.Cubes));
                break;
            case 1:
                StartCoroutine(insertionSort.SortCubes(cubeManager.Cubes));
                break;
            case 2:
                //put in sorting algorithm
                break;
            case 3:
                //put in sorting algorithm
                break;
            default:
                Debug.Log("How??");
                break;
        }
    }

    private void Update()
    {
        mode = algorithmChooser.value;
    }
}
