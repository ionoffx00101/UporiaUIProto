using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;

public class HighScoreManager : MonoBehaviour
{
    private string connectionString;

    private List<HighScore> highScores = new List<HighScore>();
    // 칸 프리팹 연결
    public GameObject scorePrefap;

    public Transform scoreParent;

    // void Awake ()
    void Start ()
    {
        // conn = "URI=file:" + Application.dataPath + "/DB Browser로 만든 데이터베이스 이름.s3db";
        connectionString = "URI=file:" + Application.dataPath + "/Proto.db";

        ShowScores();
    }

    private void ShowScores ()
    {
        // db호출
        GetScores();

        for ( int i = 0 ; i < highScores.Count ; i++ )
        {
            GameObject tmpObjec = Instantiate(scorePrefap);

            HighScore tmpScore = highScores[i];

            tmpObjec.GetComponent<HighScoreScript>().SetScore(tmpScore.rank.ToString() , tmpScore.playerName , tmpScore.score.ToString());

            tmpObjec.transform.SetParent(scoreParent);
            tmpObjec.GetComponent<RectTransform>().localScale = Vector3.one;
        }
    }

    private void GetScores ()
    {
        // IDbConnection
        using ( IDbConnection dbConnection = new SqliteConnection(connectionString) )
        {
            dbConnection.Open(); //Open connection to the database.

            // IDbCommand
            using ( IDbCommand dbCmd = dbConnection.CreateCommand() )
            {
                // sql문장 = "SELECT 조회할 컬럼 FROM 조회할 테이블";
                string sqlQuery = "SELECT Player.Player_name,Score.Score_score FROM Score Inner Join Player on Score.Player_id = Player.player_id order by score_score desc limit 10"; // 테이블 두개 조인 시킨 후 score 높은 순으로 정렬한 컬럼중 위에서 다섯개만 출력
                // dbcmd.Connection = dbconn; 위에서 쓰임
                dbCmd.CommandText = sqlQuery;

                // IDataReader
                using ( IDataReader reader = dbCmd.ExecuteReader() )
                {
                    int ranksort = 0;
                    while ( reader.Read() )
                    {
                        ranksort += 1;
                        // 변수타입은 컬럼 데이터 타입에 맞추면 된다.
                        string Player_name = reader.GetString(0);
                        int Score_score = reader.GetInt32(1);

                        highScores.Add(new HighScore(ranksort , Player_name , Score_score));
                    }

                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
    }

    private void DeleteScores (int id)
    {
        // IDbConnection
        using ( IDbConnection dbConnection = new SqliteConnection(connectionString) )
        {
            dbConnection.Open(); //Open connection to the database.
            // IDbCommand
            using ( IDbCommand dbCmd = dbConnection.CreateCommand() )
            {
                // sql문장 = "SELECT 조회할 컬럼 FROM 조회할 테이블";
                string sqlQuery = String.Format("Delete from Capsule where value =\"{0}\" " , id);

                // dbcmd.Connection = dbconn; 위에서 쓰임
                dbCmd.CommandText = sqlQuery;
                // 쓰기
                dbCmd.ExecuteScalar();
                // 닫기
                dbConnection.Close();
            }
        }
    }
}