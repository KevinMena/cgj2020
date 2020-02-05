using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IActorNPC : Interactable
{
    public Dialogue[] dialoguesList;

    public StateActor currentState;

    public List<StateActor> posibleStates;

    public bool isMoving;
    
    public Transform[] waypointsArray = null;

    public float npcSpeed = 2f;

    private Queue<Transform> waypoints = new Queue<Transform>();

    private Transform currentWaypoint;

    private Animator anim;

    void Awake() 
    {
        anim = GetComponent<Animator>();
    }

    void Start() {
        for(int i = 0; i < waypointsArray.Length; i++)
        {
            waypoints.Enqueue(waypointsArray[i]);
        }
        currentWaypoint = waypoints.Dequeue();
    }

    void Update() 
    {
        if(isMoving)
        {
            Patrolling();
        }
    }

    public override IEnumerator InteractWith() 
    {
        isMoving = false;
        KaraokeController.Instance.IActorNPC = this;

        if (currentState.stateCode != 0)
        {
            KaraokeController.Instance.PlayDialogues(posibleStates[currentState.stateCode - 1].stateDialogue);
        }
        else
        {
            KaraokeController.Instance.PlayDialogues(dialoguesList);
        }
        
        yield return null;
    }

    public bool SendGift(int gift) {

        if (currentState.stateCode != 0)
        {
            Debug.Log("You already gifted something to this NPC");
            return false;
        }

        for(int i = 0; i < posibleStates.Count; i++) {
            for(int j = 0; j < posibleStates[i].itemList.Count; j++) {
                if(posibleStates[i].itemList[j] == gift) 
                {
                    currentState = posibleStates[i];
                    KaraokeController.Instance.PlayDialogues(currentState.stateDialogue);
                    StartCoroutine(WaitForDialogue());
                    return true;
                }
            }
        }

        return false;
    }

    private IEnumerator WaitForDialogue() {
        yield return new WaitWhile(()=> KaraokeController.Instance.IsTalking);
        currentState.StateEvent.Invoke();
        GameManager.Instance.UpdateState(this, currentState.stateCode);
    }

    public void Patrolling()
    {
        Vector3 direction = currentWaypoint.position - this.transform.position;
        direction = direction.normalized;
        transform.Translate(direction * npcSpeed * Time.deltaTime, Space.World);
        anim.SetFloat("moveX", direction.x);
        anim.SetFloat("moveY", direction.y);
        float distance = Vector3.Distance(this.transform.position, currentWaypoint.position);
        if(distance < 0.1f)
        {
            waypoints.Enqueue(currentWaypoint);
            currentWaypoint = waypoints.Dequeue();
        }
    }
}
