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
        hitWall[0] = Physics2D.Raycast(ctx.GameObject.transform.position, Vector2.up, 1, LayerMask.GetMask("Foreground"));
        hitWall[1] = Physics2D.Raycast(ctx.GameObject.transform.position, Vector2.right, 1, LayerMask.GetMask("Foreground"));
        hitWall[2] = Physics2D.Raycast(ctx.GameObject.transform.position, Vector2.left, 1, LayerMask.GetMask("Foreground"));
        hitWall[3] = Physics2D.Raycast(ctx.GameObject.transform.position, Vector2.down, 1, LayerMask.GetMask("Foreground"));

        for (int i = 0; i < hitWall.Length; i++)
        {
            if (hitWall[i]) rand.AddExclude(i);
        }

        if (timer >= TIMETOMOVE)
        {

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
                Debug.Log("go to" + ctx.MoveTowards);
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
        if (canMove) return SlimeStates.MOVESTATE;
        if (ctx.Locater.Locate(ctx.GameObject)) return SlimeStates.ATTACKSTATE;
        if (ctx.DamageHandler.IsDamaged) return SlimeStates.DAMAGEDSTATE;
        return SlimeStates.IDLESTATE;
    }
}
