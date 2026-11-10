using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject towerPrefab;

    public void TrySpawnTower(Transform tileTransform)
    {
        //선택한 타일의 위치에 타워 건설
        Instantiate(towerPrefab, tileTransform.position, Quaternion.identity);
    }
}
