using UnityEngine;
using System.Collections;

public class InsertionSort : MonoBehaviour, ISorting
{
    public IEnumerator SortCubes(GameObject[] cubes)
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            GameObject keyCube = cubes[i];
            float keyHeight = keyCube.transform.localScale.y;
            int j = i - 1;

            while (j >= 0 && cubes[j].transform.localScale.y > keyHeight)
            {
                cubes[j + 1] = cubes[j];
                j--;

                yield return new WaitForSeconds(0.05f);
            }

            cubes[j + 1] = keyCube;

            for (int k = 0; k < cubes.Length; k++)
            {
                Vector3 pos = cubes[k].transform.position;
                pos.x = -((cubes.Length / 2f) * 1.25f) + k * 1.25f;
                cubes[k].transform.position = pos;
            }

            yield return new WaitForSeconds(0.1f);
        }

        
    }
}
