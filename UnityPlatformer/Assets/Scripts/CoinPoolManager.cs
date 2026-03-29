using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPoolManager : MonoBehaviour
{
    public static CoinPoolManager Instance { get; private set; }

    public GameObject coinPrefab;

    private ObjectPool coinPool;
    private List<Vector3> coinStartPositions;
    private List<GameObject> activeCoins;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        GameObject[] existingCoins = GameObject.FindGameObjectsWithTag("Coin");
        coinStartPositions = new List<Vector3>();

        foreach (GameObject coin in existingCoins)
        {
            coinStartPositions.Add(coin.transform.position);
            Destroy(coin); // Remove scene-placed coins
        }

        // Create pool
        coinPool = new ObjectPool(coinPrefab, coinStartPositions.Count);
        activeCoins = new List<GameObject>();

        //Debug.Log("CoinPool created: " + (coinPool != null));

        // Spawn all coins from pool
        SpawnAllCoins();

    }

    public void SpawnAllCoins()
    {
        foreach (Vector3 position in coinStartPositions)
        {
            GameObject coin = coinPool.Get();
            coin.transform.position = position;
            activeCoins.Add(coin);

            //Debug.Log("Spawned coin: " + coin.name + " Tag: " + coin.tag + " Position: " + coin.transform.position);

        }

    }

    public void ReturnCoin(GameObject coin)
    {
        coinPool.Return(coin);
        activeCoins.Remove(coin);
    }

    public void ResetAllCoins()
    {
        for (int i = activeCoins.Count - 1; i >= 0; i--)
        {
            coinPool.Return(activeCoins[i]);
        }

        activeCoins.Clear();
        SpawnAllCoins();
    }
}