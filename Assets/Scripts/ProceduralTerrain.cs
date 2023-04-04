using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralTerrain : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab;
    [SerializeField] int terrainSize;

    List<GameObject> allCubes = new List<GameObject>();

    void Start()
    {
        for (int column = 0; column < terrainSize; column++)
        {
            for (int row = 0; row < terrainSize; row++)
            {
                int randomHeight = Random.Range(1, 4);

                if((column == 0) || (column == terrainSize - 1) || (row == 0) || (row == terrainSize - 1))
                {
                    randomHeight += 3;
                }
                
                for (int height = 0; height < randomHeight; height++)
                {
                    allCubes.Add(Instantiate(cubePrefab, new Vector3(row, height, column), Quaternion.identity));
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int maxHeight = 0;
            List<GameObject> removeList = new List<GameObject>();
            foreach (var item in allCubes)
            {
                if(item.transform.position.y < maxHeight)
                {
                    continue;
                }
                else if(item.transform.position.y == maxHeight)
                {
                    removeList.Add(item);
                }
                else if (item.transform.position.y > maxHeight)
                {
                    maxHeight = (int)item.transform.position.y;
                    removeList.Clear();
                    removeList.Add(item);
                }
            }

            foreach (var item in removeList)
            {                
                Destroy(item);
                allCubes.Remove(item);
            }
            
        }
    }

}
