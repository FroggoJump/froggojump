using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] int easyNumber;
    [SerializeField] int mediumNumber;
    [SerializeField] int hardNumber;

    [SerializeField]
    float startHard=50; 
    [SerializeField]
    float end=80;
    private int tileCount = 0;
    float time;
    [SerializeField] int tileSpawnNumber;
    List<GameObject> activeTiles = new List<GameObject>();

    private Transform spawnLength;
    float count;
    bool finalTile;
    List<int> tilesEasy = new List<int>();
    List<int> tilesMedium = new List<int>();
    List<int> tilesHard = new List<int>();

    #region Singleton

    public static TileManager Instance;

    private void Awake()
    {
        Instance = this;
        ResetEasy();
        ResetMedium();
        ResetHard();

    }

    #endregion

    
    private void Start()
    {
        spawnLength = null;
        for (int i = 0; i < tileSpawnNumber; i++)
        {
            int random= Random.Range(0, tilesEasy.Count);
          
            
            tileCount = tilesEasy[random];
            tilesEasy.Remove(tilesEasy[random]);

            string easyTiles = "Easy" + tileCount;
            SpawnTile(easyTiles);
            if (tileCount >= easyNumber)
            {
                tileCount = 0;
            }
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (tilesEasy == null)
        {
            ResetEasy();

        }
        if(tilesMedium == null)
        {
            ResetMedium();
        }

        if (tilesHard == null)
        {
            ResetHard();
        }
        Spawner();
    }

    private void SpawnTile(string tileLevel)
    {
        GameObject temp;

        if (spawnLength != null)
        {
             temp = ObjectPooler.Instance.SpawnFromPool(tileLevel, new Vector3(spawnLength.position.x, 0.6f), Quaternion.identity);

        }
        else
        {
            temp = ObjectPooler.Instance.SpawnFromPool(tileLevel, new Vector3(3, 0.6f), Quaternion.identity);

        }


        activeTiles.Add(temp);
        Tile tile;
        temp.TryGetComponent<Tile>(out tile);
        if (tile != null)
        {
            spawnLength = tile.Next;
        }
    }

    
    private void Spawner()
    {
        if (!finalTile)
        {
            if (FrogCentral.frog.transform.position.x > end)
            {
                finalTile = true;
                string final = "Final";
                SpawnTile(final);
            }
            else if (FrogCentral.frog != null && FrogCentral.frog.transform.position.x > spawnLength.position.x - 50 && !finalTile)
            {

                if (FrogCentral.frog.transform.position.x <= startHard)
                {
                    int random = Random.Range(0, tilesMedium.Count);


                    tileCount = tilesMedium[random];
                    tilesMedium.Remove(tilesMedium[random]);

                    string mediumTiles = "Medium" + tileCount;
                    SpawnTile(mediumTiles);
                    DeleteTile();
                    if (tileCount >= mediumNumber)
                    {
                        tileCount = 0;
                    }

                }
                else if (FrogCentral.frog.transform.position.x > startHard)
                {
                    int random = Random.Range(0, tilesHard.Count);


                    tileCount = tilesHard[random];
                    tilesHard.Remove(tilesHard[random]);
                    string hardTiles = "Hard" + tileCount;
                    SpawnTile(hardTiles);
                    DeleteTile();
                    if (tileCount >= mediumNumber)
                    {
                        tileCount = 0;
                    }

                }
            }
        }
        
       
    }

    private void DeleteTile()
    {
        count++;
        if (count >= 4)
        {
            activeTiles.RemoveAt(0);
            activeTiles[0].gameObject.SetActive(false);
            count = 0;

        }

    }
    void ResetEasy()
    {
        for (int i = 0; i < easyNumber; i++)
        {
            tilesEasy.Add(i + 1);
        }
    }
    void ResetMedium()
    {
        for (int i = 0; i < mediumNumber; i++)
        {
            tilesMedium.Add(i + 1);
        }
    }
    void ResetHard()
    {
        for (int i = 0; i < hardNumber; i++)
        {
            tilesHard.Add(i + 1);
        }
    }
}
