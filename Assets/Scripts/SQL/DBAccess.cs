using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class DBAccess : MonoBehaviour
{
    void Awake()
    {
        // conn = "URI=file:" + Application.dataPath + "/DB Browser로 만든 데이터베이스 이름.s3db";
        string conn = "URI=file:" + Application.dataPath + "/BoxDB.db";

        // IDbConnection
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.

        // IDbCommand
        IDbCommand dbcmd = dbconn.CreateCommand();
        // sql문장 = "SELECT 조회할 컬럼 FROM 조회할 테이블";
        string sqlQuery = "SELECT Box_id,Box_name FROM BOX";
        dbcmd.CommandText = sqlQuery;

        // IDataReader
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            // 변수타입은 컬럼 데이터 타입에 맞추면 된다.
            int Box_id = reader.GetInt32(0);
            string Box_name = reader.GetString(1);

            Debug.Log("Box_id= " + Box_id + " Box_name =" + Box_name);
        }
        // 닫아주고 초기화 시켜주는 곳
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }   
}

