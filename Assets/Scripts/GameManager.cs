using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [Header("References")]
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject[] mainRoadEnemies;
    [SerializeField] private GameObject[] sideRoadEnemies;
    [SerializeField] public TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI blockCountText;
    

    
    private GameObject summon;
    private GameObject sideSummon;
    private float timeUntilNextSpawn = 0f;

    [Header("Attributes")]
    public int maxEnemyCount = 10;
    public int enemyHitPoints = 50;
    public float spawnCooldown = 3f;
    public int enemyCount = 0;
    public int enemyCountTemp = 0;

    public int blockCount = 70;
    public int PlayerHp = 10;

    public bool timeStopped = false;

    public int BlueBlockCount;
    public int GreenBlockCount;
    public int RedBlockCount;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    private void Start()
    {
        healthText = GameObject.Find("HealthPoints").GetComponent<TextMeshProUGUI>();
        blockCountText = GameObject.Find("BlockCount").GetComponent<TextMeshProUGUI>();
    }
    
    private void Update()
    {
        timeUntilNextSpawn += Time.deltaTime;
        if(spawnCooldown >= 0.1)spawnCooldown -= 0.02f * Time.deltaTime;

        if(!timeStopped && timeUntilNextSpawn >= spawnCooldown && enemyCountTemp < maxEnemyCount)
        {
            summon = Instantiate(mainRoadEnemies[0]);
            MainRoadEnemy summonScript = summon.GetComponent<MainRoadEnemy>();
            sideSummon = Instantiate(sideRoadEnemies[0]);
            MainRoadEnemy sideSummonScript = summon.GetComponent<MainRoadEnemy>();
            enemyCount++; enemyCount++;
            enemyCountTemp++; enemyCountTemp++;
            summonScript.SetHitPoints(enemyHitPoints);
            summonScript.SetCount(enemyCount);
            sideSummonScript.SetHitPoints(enemyHitPoints);
            sideSummonScript.SetCount(enemyCount);

            //Debug.Log("Enemy summoned with " + summonScript.hitPoints + "hit points!");
            timeUntilNextSpawn = 0;
        }
    }

    public void StopTime()
    {
        timeStopped = true;
    }

    public void StartTime()
    {
        timeStopped = false;
    }

    public bool getTime()
    {
        return timeStopped;
    }

    public void HpLost(int damage)
    {
        PlayerHp -= damage;
        healthText.text = PlayerHp.ToString();

    }

    public void AddLego(int howMany)
    {
        for (int i = 0; i < howMany; i++)
        {
            blockCount++;
        }
    }

    public void RemoveLego(int howMany)
    {
        for (int i = 0; i < howMany; i++)
        {
            blockCount--;
        }
    }

    




}