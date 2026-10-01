using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    [SerializeField] private Vector2 playerSpawnPos;
    
    private void Awake()
    {
        SpawnPlayer();
    }
    
    private void SpawnPlayer()
    {
        Instantiate(playerPrefab, playerSpawnPos, quaternion.identity);
    }

    private void SpawnEnemies()
    {
        
    }

    public void SceneTransition()
    {
        
    }
}
