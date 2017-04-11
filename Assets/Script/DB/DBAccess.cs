using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
// 출력시킬 text 오브젝트 참조하려면 넣어야함
using UnityEngine.UI;

public class DBAccess : MonoBehaviour
{
    // 출력시킬 text 오브젝트
    public Text DebugText;

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
        string sqlQuery = "SELECT Score_id,Score_score,Player_id FROM Score order by score_score desc"; // score 높은 순으로 정렬
        dbcmd.CommandText = sqlQuery;

        // IDataReader
        IDataReader reader = dbcmd.ExecuteReader();
        while ( reader.Read() )
        {
            // 변수타입은 컬럼 데이터 타입에 맞추면 된다.
            int Score_id = reader.GetInt32(0);
            int Score_score = reader.GetInt32(1);
            int Player_id = reader.GetInt32(2);

            String msg = "Score_id= " + Score_id + "  Score_score =" + Score_score + " Player_id =" + Player_id;
            ToConsole(msg);
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
    private void ToConsole (string msg)
    {
        DebugText.text += System.Environment.NewLine + msg;
        Debug.Log(msg);
    }
}