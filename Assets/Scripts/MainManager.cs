using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    public float spawnSeconds;
    public int spawnSecondsMin;
    public int spawnSecondsMax;
    public static int levelsCleared;
    [SerializeField] private GameObject RangerPrefab;
    [SerializeField] private GameObject MagePrefab;
    [SerializeField] private GameObject WarriorPrefab;
    [SerializeField] private GameObject PlayerPrefab;

    private void Start()
    {
        DiffChange();
        player.alive = true;
        StartCoroutine(Spawner());

    }
    private void Update()
    {
        GameOver();
    }
    private void Awake()
    {
        
    }

    IEnumerator Spawner()
    {
        while (enabled)
        {
            Instantiate(RangerPrefab, RandomSpawnPos(), Quaternion.identity);
            yield return new WaitForSeconds(RandomSeconds());
            Instantiate(WarriorPrefab, RandomSpawnPos(), Quaternion.identity);
            yield return new WaitForSeconds(RandomSeconds());
            Instantiate(MagePrefab, RandomSpawnPos(), Quaternion.identity);
            yield return new WaitForSeconds(RandomSeconds());
        }
    }
    Vector3 RandomSpawnPos()
    {
        float x = Random.Range(-25, 25);
        float z = Random.Range(-16, 12);
        Vector3 pos = new Vector3(x, -11.5f, z);
        return pos;
    }
    private void GameOver()
    {
        if (!player.alive)
        {
            if (MenuManager.Instance.diffLevel == 1)
            {
                StartCoroutine(GameOverScreen());
                MenuManager.levelsCleared2 = 1;
                StopAllCoroutines();
            }
            if (MenuManager.Instance.diffLevel == 2)
            {
                StartCoroutine(GameOverScreen());
                MenuManager.levelsCleared2 = 2;
                StopAllCoroutines();
            }
            if (MenuManager.Instance.diffLevel == 3)
            {
                StartCoroutine(GameOverScreen());
                MenuManager.levelsCleared2 = 3;
                StopAllCoroutines();
            }
            if (MenuManager.Instance.diffLevel == 4)
            {
                StartCoroutine(GameOverScreen()); 
                MenuManager.levelsCleared2 = 4;
                StopAllCoroutines();
            }
        }
    }
    private float RandomSeconds()
    {
        spawnSeconds = Random.Range(spawnSecondsMin, spawnSecondsMax);
        return spawnSeconds;
    }
    private void DiffChange()
    {
        if (MenuManager.Instance.diffLevel == 1)
        {

        }
        else if (MenuManager.Instance.diffLevel == 2)
        {
            spawnSecondsMax = 12;
        }
        else if (MenuManager.Instance.diffLevel == 3)
        {
            spawnSecondsMax = 9;
        }
        else if (MenuManager.Instance.diffLevel == 4)
        {
            spawnSecondsMax = 6;
        }
    }
    private IEnumerator GameOverScreen()
    {
        SceneManager.LoadScene(0);
        yield return new WaitForSeconds(2);
    }
}

