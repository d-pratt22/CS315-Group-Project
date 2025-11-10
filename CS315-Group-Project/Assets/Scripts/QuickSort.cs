using UnityEngine;
using System.Collections;

public class QuickSort : MonoBehaviour, ISorting
{
    public IEnumerator SortCubes(GameObject[] cubes)
    {
        yield return StartCoroutine(QuickSortCoroutine(cubes, 0, cubes.Length - 1));
    }

    private IEnumerator QuickSortCoroutine(GameObject[] cubes, int low, int high)
    {
        if (low >= high)
            yield break;

        int pivotIndex = high;
        float pivotValue = cubes[pivotIndex].transform.localScale.y;

        int left = low;
        int right = high - 1;

        while (left <= right)
        {
            while (left <= right && cubes[left].transform.localScale.y < pivotValue)
                left++;

            while (left <= right && cubes[right].transform.localScale.y >= pivotValue)
                right--;

            if (left < right)
            {
                swap(cubes, left, right);
                yield return new WaitForSeconds(0.1f);
            }
        }

        swap(cubes, left, pivotIndex);
        yield return new WaitForSeconds(0.1f);

        yield return StartCoroutine(QuickSortCoroutine(cubes, low, left - 1));
        yield return StartCoroutine(QuickSortCoroutine(cubes, left + 1, high));
    }

    private void swap(GameObject[] cubes, int a, int b)
    {
        GameObject temp = cubes[a];
        cubes[a] = cubes[b];
        cubes[b] = temp;

        Vector3 tempPos = cubes[a].transform.position;
        cubes[a].transform.position = cubes[b].transform.position;
        cubes[b].transform.position = tempPos;
    }
}
