using UnityEngine;
using System.Collections;

public class BubbleSort : MonoBehaviour, ISorting
{
    public IEnumerator SortCubes(GameObject[] cubes)
    {
        int n = cubes.Length;

        for (int i = 0; i <= n - 2; i++)
        {
            for (int j = 0; j <= n - 2; j++)
            {
                float height1 = cubes[j].transform.localScale.y;
                float height2 = cubes[j+1].transform.localScale.y;

                if (height1 > height2)
                {
                    GameObject temp = cubes[j];
                    cubes[j] = cubes[j+1];
                    cubes[j+1] = temp;

                    Vector3 pos1 = cubes[j].transform.position;
                    Vector3 pos2 = cubes[j+1].transform.position;
                    cubes[j].transform.position = new Vector3(pos2.x, 0, 0);
                    cubes[j+1].transform.position = new Vector3(pos1.x, 0, 0);


                    yield return new WaitForSeconds(0.1f);
                }
            }
        }
    }
}
