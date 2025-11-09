using UnityEngine;
using System.Collections;

public class QuickSort : MonoBehaviour, ISorting
{
    public IEnumerator SortCubes(GameObject[] cubes)
    {
        quickSort(cubes, 1, cubes.Length - 1);
        yield return new WaitForSeconds(0.1f);

    }

    private void quickSort(GameObject[] cubes, int low, int high)
    {
        // check to see if the selection is already sorted
        if(cubes[low].transform.localScale.y >= cubes[high].transform.localScale.y)
        {
            return;
        }

        int left = low;
        int right = high;

        int pivot = high;
        
        while (left != right)
        {
            while (cubes[left].transform.localScale.y <= cubes[pivot].transform.localScale.y && left < right)
            {
                left++;
            }

            while (cubes[right].transform.localScale.y >= cubes[pivot].transform.localScale.y && left < right)
            {
                right--;
            }

            swap(cubes, left, right);
        }

        swap(cubes, left, pivot);
        quickSort(cubes, low, left - 1);
        quickSort(cubes, right + 1, high);

    }

    private void swap(GameObject[] cubes, int a, int b)
    {
        GameObject temp = cubes[a];
        cubes[a] = cubes[b];
        cubes[b] = temp;
    }
}
