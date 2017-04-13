using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;

public class InsertScoreManager : MonoBehaviour {

    private string connectionString;

    void Start ()
    {
        // conn = "URI=file:" + Application.dataPath + "/DB Browser로 만든 데이터베이스 이름.s3db";
        connectionString = "URI=file:" + Application.dataPath + "/Proto.db";
  
    }
    
    private void InsertScore (int Player_id , int score_score) // playerid , new score 받으면 될거같다.
    {
        // IDbConnection
        using ( IDbConnection dbConnection = new SqliteConnection(connectionString) )
        {
            dbConnection.Open(); //Open connection to the database.

            // IDbCommand
            using ( IDbCommand dbCmd = dbConnection.CreateCommand() )
            {
                // sql문장 = "SELECT 조회할 컬럼 FROM 조회할 테이블";
                //insert into Score(Player_id , score_score) values("3" , "15000")
                string sqlQuery = String.Format("insert into Score(Player_id , score_score) values(\"{0}\" , \"{1}\")" , Player_id , score_score);

                // dbcmd.Connection = dbconn; 위에서 쓰임
                dbCmd.CommandText = sqlQuery;
                // 쓰기
                dbCmd.ExecuteScalar();
                // 닫기
                dbConnection.Close();

            }
        }
    }
    public void callInsertScore ()
    {
        InsertScore(6 , 8321);
        //여기서 데이터를 넣어 보낸다 
        // player 객체안에 정보가 있어서 해당 정보를 
        // player.id 이런식으로 불러서 넣을수는 없을까
        // 그럼 클릭했을때 clikc(player){ ((insert- ),player.id)으로 넣으면 될텐데} 
    }
}
