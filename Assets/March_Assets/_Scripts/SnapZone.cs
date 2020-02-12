using UnityEngine;

public class SnapZone : MonoBehaviour
{
    public bool isEmpty = true;
    public BlockElementDragHandler block;
    public Vector2 Location;
    private RaycastHit2D[] up, down, left, right;
    public SnapZone upSnapZone, downSnapZone, leftSnapZone, rightSnapZone;
    int frameCounter;
    private SpriteRenderer sr;
    Color StartTileColor;
    BlockManager TriggeredBlockManager;
    private void OnEnable()
    {
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        StartTileColor = sr.color;
    }

    private void FixedUpdate()
    {
        if (frameCounter <= 10)
        {
            frameCounter++;
            GetNeighbours();
        }
        if (block == null)
        {
            ResetOrginalColor();
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        TriggeredBlockManager = col.GetComponentInParent<BlockManager>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (block != null)
        {
            TriggeredBlockManager = null;
            ResetOrginalColor();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TriggeredBlockManager = null;
        ResetOrginalColor();
    }
    #region Hover
    public void Hover(BlockManager bm)
    {
        if (bm.AllEmpty())
        {
            HoverGreen();
        }
        else
        {
            HoverRed();
        }
    }
    public void HoverGreen()
    {
        sr.color = new Color(0, 1, 0, 1);
    }
    public void HoverRed()
    {
        sr.color = new Color(1, 0, 0, 1);
    }
    public void ResetOrginalColor()
    {
        sr.color = StartTileColor;
    }
    #endregion
    #region GetNeighbours

    private void GetNeighbours()
    {
        up = Physics2D.RaycastAll(this.transform.position, transform.up, 0.9f);
        down = Physics2D.RaycastAll(this.transform.position, -transform.up, 0.9f);
        right = Physics2D.RaycastAll(this.transform.position, transform.right, 0.9f);
        left = Physics2D.RaycastAll(this.transform.position, -transform.right, 0.9f);

        
        upSnapZone = CheckRaycastHitArray(up);
        downSnapZone = CheckRaycastHitArray(down);
        rightSnapZone = CheckRaycastHitArray(right);
        leftSnapZone = CheckRaycastHitArray(left);
    }
    private SnapZone CheckRaycastHitArray(RaycastHit2D[] arr)
    {
        SnapZone snapZone = null;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].collider.gameObject != this.gameObject)
            {
                if (snapZone == null)
                {
                    snapZone = arr[i].collider.GetComponent<SnapZone>();
                    return snapZone;
                }
            }
        }
        return null;
    }
    #endregion
    #region Setter Getter
    public void SetLocation(int width, int height)
    {
        Location = new Vector2(width, height);
    }
    public Vector2 GetLocation()
    {
        return Location;
    }
    public void SetAttachedBlock(BlockElementDragHandler b)
    {
        block = b;
    }
    #endregion
}
