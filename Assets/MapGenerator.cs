using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject ObstacleWallPrefab;
    public GameObject BoxPrefab;
    public GameObject Player;
    public GameObject[] PirateGhostObjects;
    public GameObject PirateGhost2;
    public GameObject GhostMaster;
    public GameObject DestPoint;
    public GameObject MagicalRubyItem;
    public GameObject MagicalSapphireItem;
    public GameObject TreasureBox;
    public GameObject Ground;

  
    public int mRubyMax;
    public int mSapphireMax;
    public int tBoxMax;

    public int gMasterMax;
    //0:None 1:ObstacleWall 2:Box 3:Player 4:PirateGhost 5:GhostMaster 6:MagicalRubyItem 7:MagicalSapphireItem 8:TreasureBox 9:Points
    //ランダムに変えられるように、2ステージ用意（追加で３，４ステージを用意する可能性あり）

   
    public int[,,] StageMap =
{
{
        { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
        { 1,1,1,0,0,2,2,2,2,0,0,9,1,1,1,1 },
        { 1,1,1,0,2,2,2,5,5,0,2,4,0,1,1,1 },
        { 1,1,0,0,2,2,6,2,2,7,2,0,0,0,1,1 },
        { 1,0,0,0,0,2,1,2,2,2,0,0,0,5,0,1 },
        { 1,2,0,1,0,1,0,1,2,0,0,0,0,0,0,1 },
        { 1,0,2,0,0,2,1,2,0,9,0,0,0,0,9,1 },
        { 1,0,0,0,1,0,0,2,0,0,0,0,0,0,1,1 },
        { 1,0,0,1,0,2,2,0,0,0,0,0,0,1,1,1 },
        { 1,0,0,0,0,1,0,0,0,9,0,0,1,1,1,1 },
    },
{
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            { 1,1,1,9,0,0,0,0,4,0,0,9,1,1,1,1 },
            { 1,1,1,0,0,0,0,2,2,2,2,0,0,1,1,1 },
            { 1,1,0,0,0,0,2,2,2,3,2,0,0,0,1,1 },
            { 1,0,0,0,0,2,1,2,2,2,2,2,0,5,0,1 },
            { 1,1,7,1,1,0,0,1,0,0,0,6,0,0,0,1 },
            { 1,0,1,2,2,2,1,2,6,2,2,2,2,0,1,1 },
            { 1,0,0,7,9,0,0,0,0,4,9,2,0,1,1,1 },
            { 1,0,0,1,1,2,2,2,2,2,2,0,1,1,1,1 },
            { 1,1,5,1,1,1,1,1,1,1,1,5,1,1,1,1 },
        }
    };

    public int stageScale;
    // Start is called before the first frame update
    void Start()
    {

        GetStageMax();
        CleateStage(stageScale);
     
    }

    public int GetStageMax()
    {
        return StageMap.GetLength(1);

    }

    public void CleateStage(int stage)
    {
       
        var parent = this.transform;
        Vector3 groundPosition = new Vector3(35.3f, 1.5f, 15);
        Vector3 initPosition = groundPosition;

        Quaternion q = new Quaternion();
        q = Quaternion.identity;


        for (int i = 1; i < StageMap.GetLength(1); i++)
        {
            groundPosition.x = initPosition.x;
            for (int j = 0; j < StageMap.GetLength(2); j++)
            {

                int gameObject = StageMap[stage + 1, i, j];  
                if (gameObject != 0)
                {

                    GameObject obs = Instantiate(ObstacleWallPrefab, groundPosition, q, parent);


                }
                else
                {
                    GameObject box = Instantiate(BoxPrefab, groundPosition, q, parent);


                }
            
            groundPosition.x -= DestPoint.transform.localScale.x * 2.9f;

            }
        groundPosition.z -= DestPoint.transform.localScale.z * 5.6f;
        }

        
        for (int mrubyCount = 0; mrubyCount < mRubyMax; mrubyCount++)
        {
            groundPosition.x -= MagicalRubyItem.transform.localScale.x * -20.3f;
            groundPosition.z -= MagicalRubyItem.transform.localScale.z * -8.3f;

            float x = Random.Range(0.5f, 1.1f);
            float z = Random.Range(1.0f,0.5f);
            if (mrubyCount < mRubyMax)
            {

                GameObject mruby = Instantiate(MagicalRubyItem, groundPosition, q, parent);
               
            }
        }

        for (int msapphierCount = 0; msapphierCount < mSapphireMax; msapphierCount++)
        {
            groundPosition.x -= MagicalSapphireItem.transform.localScale.x * 13.0f;
            groundPosition.z -= MagicalSapphireItem.transform.localScale.z * -11.3f;

            float x = Random.Range(0.5f, 1.1f);
            float z = Random.Range(1.0f, 0.5f);
            if (msapphierCount < mSapphireMax)
            {

                GameObject msapp = Instantiate(MagicalSapphireItem, groundPosition, q, parent);

            }
        }

        for (int tboxCount = 0; tboxCount < tBoxMax; tboxCount++)
        {

            groundPosition.x += TreasureBox.transform.localScale.x*5;
            groundPosition.z -= TreasureBox.transform.localScale.z * 15.5f;
           

            if (tboxCount < tBoxMax)
            {
                GameObject trebox = Instantiate(TreasureBox, groundPosition, q, parent);

            }
        }

        for (int gmasterCount =0; gmasterCount < gMasterMax; gmasterCount++)
        {
            groundPosition.x += GhostMaster.transform.localScale.x *5;
            groundPosition.z -= GhostMaster.transform.localScale.z * -11;
            if (gmasterCount < gMasterMax)
            {
                float x = Random.Range(0.5f, 1.1f);
                float z = Random.Range(1.0f, 0.5f);

                GameObject gmaster = Instantiate(GhostMaster, groundPosition, q, parent);

              
                
            }
        }
    }
    }
    
    



    




