// //////////////////////////////////////////////////// Usings //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ///////////////////////////////////////////// Class: Player //
public
class Player
        : MonoBehaviour
{
    // ============================ Private implementation < ==//
    // -------------------------------------- Behaviour << --==//
    // .............................. Initialization <<< ..--==//
    private void Awake()
    {
        SetupReferencesToComponents();
    }

    void SetupReferencesToComponents()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        healthUI = Instantiate(uiTextPrefab,
                new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Text>();
        healthUI.transform.parent = GameObject.Find("Canvas").transform;
        healthUI.text = health.ToString();
    }

    // ------------------------------------------- Data << --==//
    // .................................. Components <<< ..--==//
    private new Rigidbody rigidbody;
    [SerializeField] public GameObject fireballPre;


    [SerializeField] public float velocity;

    public void Move(Vector3 force)
    {
        rigidbody.AddForce(velocity * force);
    }

    public void Attack(GameObject enemy)
    {
        Vector3 direction = (enemy.transform.position
             - transform.position).normalized;

        GameObject fireball = Instantiate(fireballPre,
            this.transform.position, Quaternion.identity);
        Physics.IgnoreCollision(this.GetComponent<Collider>(), fireball.GetComponent<Collider>());
        fireball.GetComponent<Rigidbody>().velocity = direction * 1000 * Time.deltaTime;
    }

    [SerializeField] private GameObject uiTextPrefab;
    private Text healthUI;
    float health = 100;

    void Update()
    {
        health += 5 * Time.deltaTime;
        if (health >= 100) health = 100;

        GameObject.Find("Directional Light").GetComponent<Light>()
             .intensity = health / 100;
        GameObject.Find("Directional Light").transform.rotation =
            Quaternion.Euler(10 + (75 * (100 - health) / 100), -135, 0);


        healthUI.text = "HP: " + ((int)health).ToString();

        if (health <= 0)
        {
            healthUI.text = "GAME OVER";
            Destroy(gameObject);
        }

        // Render the UI
        Vector3 uiPos = Camera.main.WorldToScreenPoint(this.transform.position);
        healthUI.transform.position = uiPos + new Vector3(0, 75, 0);
        healthUI.color = Color.green;
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 20 * Time.deltaTime;
        }
    }
}

// /////////////////////////////////////////////////////////// //
