using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlayerMovment : MonoBehaviour
{

    private Vector2 velocity;
    private Vector3 direction;
    private bool hasMoved;
   

    [SerializeField] private int vision = 3;
    [SerializeField] private QuestSystem quest;
    [SerializeField] private FightSystem fightSystem;
    public Tilemap fog;
    public Camera camera;
    public Text energy;
    public bool hasTurn;
    public int maxEnergy = 5;
    public int currentEnergy = 5;
    public Quest currentQuest = null;
    public List<GameObject> backpack;
    public int strenght = 5;
    public bool stun = false;

    private void Start()
    {
        UpdateFog();
    }

    void Update()
    {
        if (hasTurn && currentEnergy != 0)
        {
            if (velocity.x == 0)
            {
                hasMoved = false;
            }
            else if (velocity.x != 0 && !hasMoved)
            {
                hasMoved = true;
                MoveByDirection();
            }

            velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }

    private void MoveByDirection()
    {
        if (velocity.x < 0)
        {
            if(velocity.y> 0)
            {
                direction = new Vector3(-.5f, .75f);
            }
            else if( velocity.y < 0)
            {
                direction = new Vector3(-.5f, -.75f);
            } 
            else
            {
                direction = new Vector3(-1f, 0);
            }
        }
        else if (velocity.x > 0)
        {
            if (velocity.y > 0)
            {
                direction = new Vector3(.5f, .75f);
            }
            else if (velocity.y < 0)
            {
                direction = new Vector3(.5f, -.75f);
            }
            else
            {
                direction = new Vector3(1f, 0);
            }
        }
        currentEnergy--;
        energy.text = "Energy: " + currentEnergy + "/" + maxEnergy;
        transform.position += direction;
        UpdateFog();
        if (currentQuest != null)
            if (currentQuest.CheckQuest(this))
            {
                currentQuest.CompletedQuest(this);
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "obs":
                transform.position -= direction;
                break;
            case "city":
                quest.SetQuestWinow(this);
                break;
            case "lab":
                //
                break;
            case "Player":
               fightSystem.SetPlayesFight(this, collision.gameObject.GetComponent<PlayerMovment>());
                break;
            case "mob":
                fightSystem.SetMobFight(this, collision.gameObject.GetComponent<PlayerMovment>());
                break;
            default:
                break;

        }
    }

    private void UpdateFog()
    {
        Vector3Int currentPosition = fog.WorldToCell(transform.position);
        for (int i = -3; i <= 3; i++)
        {
            for (int j = -3; j <= 3; j++)
            {
                fog.SetTile(currentPosition + new Vector3Int(i, j, 0), null);
            }
        }
    }

}
