using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using System;
using System.Linq;

public class SlimeIdleState : AbstractState<SlimeStates, SlimeContext>
{
    private const float TIMETOMOVE = 2;
    private readonly RaycastHit2D[] hitWall;
    private readonly RandomNumber rand;
    private float timer;
    private bool canMove;


    public SlimeIdleState(SlimeContext ctx) : base(SlimeStates.IDLESTATE)
    {
        this.ctx = ctx;
        timer = 0;
        hitWall = new RaycastHit2D[4];
        rand = new RandomNumber();
    }

    public override void EnterState()
    {
        canMove = false;
    }

    public override void UpdateState()
    {
        //These are the directions that I shoot a raycast to detect "foreground" colliders.
        hitWall[0] = Physics2D.Raycast(ctx.GameObject.transform.position, Vector2.up, 1, LayerMask.GetMask("Foreground"));
        hitWall[1] = Physics2D.Raycast(ctx.GameObject.transform.position, Vector2.right, 1, LayerMask.GetMask("Foreground"));
        hitWall[2] = Physics2D.Raycast(ctx.GameObject.transform.position, Vector2.left, 1, LayerMask.GetMask("Foreground"));
        hitWall[3] = Physics2D.Raycast(ctx.GameObject.transform.position, Vector2.down, 1, LayerMask.GetMask("Foreground"));

        /*Possible directions the enemy can move are all directions excluding the directions the would result in a collision with 
        foreground. */
        for (int i = 0; i < hitWall.Length; i++)
        {
            if (hitWall[i]) rand.AddExclude(i); //Adds the direction in which a foreground is located to the exclusion list.
        }

        if (timer >= TIMETOMOVE)
        {

            //Generates a random number to determine movement direction excluding the numbers in the exclude list.
            //May change later to make it more deterministic.
            ctx.MoveTowards = rand.GetNumber(0, hitWall.Length) switch
            {
                0 => Vector3.up,
                1 => Vector3.right,
                2 => Vector3.left,
                3 => Vector3.down,
                _ => Vector2.zero,
            };

            if (ctx.MoveTowards != Vector2.zero)
            {
                canMove = true;
            }
        }

        rand.ClearExlude();
        timer += Time.deltaTime;
    }

    public override void ExitState()
    {
        timer = 0;
    }

    public override SlimeStates GetNextState()
    {
        if(ctx.Health.Hearts <= 0)
        {
            ctx.Animator.SetBool("isDamaged", false);
            Debug.Log("Fuck " + ctx.Animator.GetBool("isDamaged"));
            return SlimeStates.DEATHSTATE;
        }
        
        if (canMove) return SlimeStates.MOVESTATE;
        if (ctx.Detector.Detect(ctx.GameObject, ctx.AttackRadius)) return SlimeStates.PREPARETOATTACKSTATE;
        if (ctx.DamageHandler.IsTriggered) return SlimeStates.DAMAGEDSTATE;
        return SlimeStates.IDLESTATE;
    }
}
