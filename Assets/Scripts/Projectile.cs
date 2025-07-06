using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class Projectile : Enemy
{
    public float projSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DiffChange();
    }

    // Update is called once per frame
    void Update()
    {
        isProjectile = true;
        ProjectileMove();
    }
    private void Awake()
    {
        manager = FindFirstObjectByType<MainManager>();
        transform.LookAt(PlayerPos());
    }
    public override void ProjectileMove()
    {
        transform.Translate(Vector3.forward * projSpeed * Time.deltaTime);
    }
    public override void DiffChange()
    {
        if (MenuManager.Instance.diffLevel == 1)
        {

        }
        else if (MenuManager.Instance.diffLevel == 2)
        {
            projSpeed = projSpeed * 3 / 1.5f;
        }
        else if (MenuManager.Instance.diffLevel == 3)
        {
            projSpeed = projSpeed * 4 / 1.5f;
        }
        else if (MenuManager.Instance.diffLevel == 4)
        {
            projSpeed = projSpeed * 5 / 1.5f;
        }
    }
}
