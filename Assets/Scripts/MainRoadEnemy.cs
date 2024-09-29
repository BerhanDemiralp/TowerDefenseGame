using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoadEnemy : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] public float hitPoints = 100;
    [SerializeField] public float enemyCount = 0;
    [SerializeField] private Movement movement;

    private float _speed;
    private float damageAmplifier = 1;
    private Color defaultColor;
    private SpriteRenderer spriteRenderer;
    private  GameObject gameManager;
    private GameManager gameManagerScript;
    
    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
    }

    public void SetHitPoints(float _hitPoints)
    {
        hitPoints = _hitPoints;
    }

    public void SetCount(int _enemyCount)
    {
        enemyCount = _enemyCount;
    }

    public void DealDamage(float damage)
    {
        hitPoints -= damage * damageAmplifier;
        StartCoroutine(SetDamageColor());
        if(hitPoints <= 0)
        {
            gameManagerScript.enemyCountTemp--;
            DestroyEnemy();
        }
    }

    public void SetSpeed(float _speedMultiplier, float _time)
    {
        movement.speed = _speed;
        StartCoroutine(SetSpeedDefault(_speedMultiplier,_time));
    }
    public void SetDamageAmplifier(float _damageAmplifier, float _time)
    {
        StartCoroutine(DamageAmplifier(_damageAmplifier, _time));
    }   

    IEnumerator SetSpeedDefault(float _speedMultiplier,float _time)
    {
        movement.SetSpeed(_speedMultiplier);
        yield return new WaitForSeconds(_time);
        movement.SetSpeedDefault();
    }

    IEnumerator DamageAmplifier(float _damageAmplifier, float _time)
    {
        damageAmplifier = (100 + _damageAmplifier)/100;
        yield return new WaitForSeconds(_time);
        damageAmplifier = 1;
    }
    IEnumerator SetDamageColor()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.color = defaultColor;
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    
    
}
