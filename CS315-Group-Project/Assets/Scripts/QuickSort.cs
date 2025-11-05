using UnityEngine;
using System.Collections;

public class QuickSort : MonoBehaviour, ISorting
{
    public IEnumerator SortCubes(GameObject[] cubes)
    {


    }

    private void quickSort(GameObject cubes[], int left, int right)
    {


    }

    private int partition (GameObject cubes[], int left, int right)
    {
        int pivot = right;
    }

    private void swap(GameObject cubes, int a, int b)
    {
        GameObject temp = cubes[a];
        cubes[a] = cubes[b];
        cubes[b] = temp;
    }
}
