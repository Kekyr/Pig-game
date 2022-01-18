using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private GameObject _bombPrefab;
    
    public void PlantBomb()
    {
        Instantiate(_bombPrefab, transform.position, Quaternion.identity);
    }

}
