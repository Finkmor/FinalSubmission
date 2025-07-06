using System.Collections;
using UnityEngine;

public class Mage : Enemy
{
    public GameObject projectilePrefab;
    private float reloadSeconds = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerIsDead();
    }
    private void Awake()
    {
        DiffChange();
        manager = FindFirstObjectByType<MainManager>();
        StartCoroutine(ShootTimer());

    }
    public override IEnumerator ShootTimer()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(shootSeconds);
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(reloadSeconds);
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(reloadSeconds);
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(shootSeconds);

        }
    }

}
