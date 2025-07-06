using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isProjectile = false;
    private int speed = 2;
    public float shootSeconds = 5;
    Vector3 playerpos;
    [SerializeField] public MainManager manager;
    [SerializeField] private GameObject projectilePrefab;

    private void Start()
    {
        manager = FindFirstObjectByType<MainManager>();
        DiffChange();
    }
    private void Update()
    {
        
    }
    private void Awake()
    {
        
    }

    public virtual void ProjectileMove()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public virtual IEnumerator ShootTimer()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(shootSeconds);
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
    }
    public Vector3 PlayerPos()
    {
        playerpos = manager.player.transform.position;
        return playerpos;
    }
    public void PlayerIsDead()
    {
        if (!manager.player.alive)
        {
            StopAllCoroutines();
        }
    }
    public virtual void DiffChange()
    {
        if (MenuManager.Instance.diffLevel == 1)
        {
            
        }
        else if (MenuManager.Instance.diffLevel == 2)
        {
            shootSeconds = shootSeconds - 1;
        }
        else if (MenuManager.Instance.diffLevel == 3)
        {
            shootSeconds = shootSeconds - 2;
        }
        else if (MenuManager.Instance.diffLevel == 4)
        {
            shootSeconds = shootSeconds - 3;
        }
    }
}
