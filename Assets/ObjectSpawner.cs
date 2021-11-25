using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] levelObjects;

    int z_increase;

    private void Start()
    {
        for (int i = 0; i < 11; i++) //Candle Part Spawn
        {
            Instantiate(levelObjects[0], new Vector3(Random.Range(-4 , 4), 1, 25 + z_increase), Quaternion.identity);
            
            z_increase += 20;
        }

        z_increase = 0;

        for (int i = 0; i < 11; i++) //Obstacle Spawn
        {
            Instantiate(levelObjects[Random.Range(1, 4)], new Vector3(0, 0 ,37.5f + z_increase), Quaternion.identity);

            z_increase += 20;
        }
    }
}