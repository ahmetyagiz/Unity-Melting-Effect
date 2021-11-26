using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] levelObjects;
    [SerializeField] private GameObject[] levelObstacles;
    [SerializeField] private GameObject levelParent;

    int z_increase;

    int[] sayilar = {0,1,2,3,4};

    private void Awake()
    {
        //sayilar[0] = Random.Range(0,5);
    }   

    private void Start()
    {
        print(sayilar[2]);

        for (int i = 0; i < 11; i++) //Candle Part Spawn
        {
            Instantiate(levelObjects[0], new Vector3(Random.Range(-4 , 4), 1, 25 + z_increase), Quaternion.identity, levelParent.transform);
            
            z_increase += 20;
        }

        z_increase = 0;

        for (int i = 0; i < 2; i++) //Speed Boost Spawn
        {
            Instantiate(levelObjects[1], new Vector3(Random.Range(-3, 3), 0.75f, 85 + z_increase), levelObjects[1].transform.rotation, levelParent.transform);

            z_increase += 80;
        }

        z_increase = 0;

        for (int i = 0; i < 2; i++) //Obstacle Spawn
        {
            for (int j = 0; j < levelObstacles.Length; j++)
            {
                Instantiate(levelObstacles[j], new Vector3(0, 0, 37.5f + z_increase), Quaternion.identity, levelParent.transform);

                z_increase += 20;
            }            
        }
    }
}