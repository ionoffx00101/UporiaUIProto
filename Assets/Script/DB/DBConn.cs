using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
// 출력시킬 text 오브젝트 참조하려면 넣어야함
using UnityEngine.UI;

public class DBConn : MonoBehaviour
{
    // 출력시킬 text 오브젝트
    public Text Rank_Text;
    public Text Player_name_Text;
    public Text Score_score_Text;

    void Start ()
    {
        // conn = "URI=file:" + Application.dataPath + "/DB Browser로 만든 데이터베이스 이름.db";
        string conn = "URI=file:" + Application.dataPath + "/Proto.db";

        // IDbConnection
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.

        // IDbCommand
        IDbCommand dbcmd = dbconn.CreateCommand();
        // sql문장 = "SELECT 조회할 컬럼 FROM 조회할 테이블";
        // string sqlQuery = "SELECT Score_id,Score_score,Player_id FROM Score"; // 그냥 조회
        // string sqlQuery = "SELECT Score_id,Score_score,Player_id FROM Score order by score_score desc"; // score 높은 순으로 정렬
        // string sqlQuery = "SELECT Player.Player_name,Score.Score_score FROM Score Inner Join Player on Score.Player_id = Player.player_id order by score_score desc"; // 테이블 두개 조인 시킨 후 score 높은 순으로 정렬
        string sqlQuery = "SELECT Player.Player_name,Score.Score_score FROM Score Inner Join Player on Score.Player_id = Player.player_id order by score_score desc limit 10"; // 테이블 두개 조인 시킨 후 score 높은 순으로 정렬한 컬럼중 위에서 다섯개만 출력
        
        dbcmd.CommandText = sqlQuery;

        // IDataReader
        int ranksort = 0;
        IDataReader reader = dbcmd.ExecuteReader();
        while ( reader.Read() )
        {
            ranksort += 1;
            // 변수타입은 컬럼 데이터 타입에 맞추면 된다.
            string Player_name = reader.GetString(0);
            int Score_score = reader.GetInt32(1);

            // Debug.Log(ranksort + " / "+ Player_name + " / " + Score_score);
            ToConsole(ranksort,Player_name, Score_score);
        }

        // 닫아주고 초기화 시켜주는 곳
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    // 해당 text 게임 오브젝트에 출력하라고 시키는것
    private void ToConsole (int rank, string Player_name, int Score_score)
    {
        if ( rank > 1 ) { 
        Rank_Text.text += System.Environment.NewLine + rank;
        Player_name_Text.text += System.Environment.NewLine + Player_name;
        Score_score_Text.text += System.Environment.NewLine + Score_score;
        }
        else if ( rank == 1 )
        {
            Rank_Text.text += rank;
            Player_name_Text.text += Player_name;
            Score_score_Text.text += Score_score;
        }

        // Debug.Log(msg);
    }
}