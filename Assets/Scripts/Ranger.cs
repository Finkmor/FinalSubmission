using UnityEngine;

public class Ranger : Enemy
{
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

}
