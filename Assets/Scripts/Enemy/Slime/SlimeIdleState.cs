using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class SlimeIdleState : AbstractState<SlimeStates, SlimeContext>
{
    private const float TIMETOMOVE = 2;
    private float timer;
    private Vector2 dir;
    private RaycastHit2D wallDetector;
    private bool canMove;

    public SlimeIdleState(SlimeContext ctx) : base(SlimeStates.IDLESTATE) 
    {
        this.ctx = ctx;
        timer = 0;
    }

    public override void EnterState()
    {
        canMove = false;
        Debug.Log("Enterly doo");
        dir = new Vector2(Random.Range(0, 2), Random.Range(0, 2));
        dir.Normalize();
        //ctx.Dir = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
    }
    
    public override void UpdateState()
    {
      //  Debug.Log("fuck me");
        //if (Physics2D.Raycast(ctx.GameObject.transform.position, dir, 1, LayerMask.GetMask("Foreground")))
       // {
         //   Debug.Log("wall found");
           // Debug.DrawLine(ctx.GameObject.transform.position, ctx.GameObject.transform.position + Vector3.up * 1, Color.black);
        //}

        Physics2D.Raycast(ctx.GameObject.transform.position, dir, 1, LayerMask.GetMask("Foreground"));
        Debug.DrawLine(ctx.GameObject.transform.position, ctx.GameObject.transform.position + (Vector3)dir * 1, Color.black);

        if (timer >= TIMETOMOVE)
        {
            canMove = true;
        }
        
        //if (timer >= TIMETOMOVE)
        //{
            // do
            //{
             //   dir = new Vector2(Random.Range(0, 2), Random.Range(0, 2));
            //} while (!Physics2D.Raycast(ctx.GameObject.transform.position, dir, 1, LayerMask.GetMask("Foreground")));
            
          //  Debug.DrawLine(ctx.GameObject.transform.position, ctx.GameObject.transform.position + (Vector3) dir * 1, Color.black);

         //   timeToMove = true;
           // ctx.Rb.MovePosition(ctx.Rb.position + dir * Time.deltaTime);
        //}

     /*   if (timer >= TIMETOSTOP || timer == 0)Foreground
        {
            do {
                dir = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));

                wallDetector = Physics2D.Raycast(ctx.Rb.position, dir, 2);
            } while (dir == Vector2.zero && wallDetector.collider.gameObject.layer == LayerMask.GetMask("Foreground"));

            timer = 0;
        } */
        
        //timer += Time.deltaTime;
    }

    public override SlimeStates GetNextState()
    {
        if (canMove) return SlimeStates.MOVESTATE;
       // if (ctx.Locater.Locate(ctx.GameObject)) return SlimeStates.ATTACKSTATE;
        if (ctx.DamageHandler.IsDamaged) return SlimeStates.DAMAGEDSTATE;
        return SlimeStates.IDLESTATE;
    }
}
