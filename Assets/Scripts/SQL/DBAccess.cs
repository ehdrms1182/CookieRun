using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class DBAccess : MonoBehaviour
{
    void Start()
    {
        DBCalling();
    }
    void DBCalling()
    {
        Debug.Log("성공");
        // conn = "URI=file:" + Application.dataPath + "/DB Browser로 만든 데이터베이스 이름.db";
        string conn = "URI=file:" + Application.dataPath + "/StreamingAssets/" + "/NetworkProgrammingB.db";
        // IDbConnection
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.

        // IDbCommand
        IDbCommand dbcmd = dbconn.CreateCommand();
        // sql문장 = "SELECT 조회할 컬럼 FROM 조회할 테이블";
        string sqlQuery = "SELECT UserId, Password FROM UserInfo";
        dbcmd.CommandText = sqlQuery;

        // IDataReader
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            // 변수타입은 컬럼 데이터 타입에 맞추면 된다.
            string UserID = reader.GetString(1);
            string Password = reader.GetString(1);
            Debug.Log("연결 성공");
            Debug.Log($"UserID = {UserID} + Password = {Password}");
        }
        // 닫아주고 초기화 시켜주는 곳
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        Debug.Log("초기화 성공");
    }
}