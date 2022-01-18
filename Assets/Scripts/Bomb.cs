using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Collider2D[] _victims;

    private void Start()
    {
        StartCoroutine(WaitAndDestroy());
    }
    
    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(3f);
        _victims = Physics2D.OverlapCircleAll(transform.position, 1.5f);
        
        if (_victims.Length > 0)
        {
            for (int i = 0; i < _victims.Length; i++)
            {
                if (_victims[i].tag != "Stone" && _victims[i].tag!="Border")
                {
                    Destroy(_victims[i].gameObject);
                }
            }
        }
        Destroy(gameObject);
    }
}
