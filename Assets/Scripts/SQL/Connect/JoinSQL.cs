using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;

public class JoinSQL : MonoBehaviour
{
    [SerializeField]
    public Text id;
    [SerializeField]
    public InputField pw;
    [SerializeField]
    public InputField cpw;

    
    public void IsClicked(){
        string conn = "URI=file:" + Application.dataPath + "/StreamingAssets/" + "/NetworkProgrammingB.db";
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open();

        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = null;
        sqlQuery = "SELECT UserID from UserInfo ";// 테이블 이름
        sqlQuery += "WHERE UserID = '"+id.text+"'";

        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        string JoinSearchId = null;
        while(reader.Read()){
            JoinSearchId = reader.GetString (0);
            Debug.Log(JoinSearchId);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        if(JoinSearchId == id.text){
            Debug.Log("동일한 아이디가 존재합니다");
        }
        else if(pw.text != cpw.text){
            Debug.Log("비밀번호가 일치하지 않습니다");
        }
        else if(pw.text == cpw.text)
        {
            IDbConnection sql;
            sql = (IDbConnection) new SqliteConnection(conn);
            sql.Open();

            IDbCommand dbcmdd = sql.CreateCommand();
            string Query;
            Query = "INSERT INTO UserInfo (UserID, Password)";// 테이블 이름
            Query += "VALUES('"+id.text+"','"+pw.text+"')";

            dbcmdd.CommandText = Query;
            dbcmdd.ExecuteNonQuery();

            dbcmdd.Dispose();
            dbcmdd = null;
            sql.Close();
            sql = null;
            Debug.Log("회원가입 성공!");
        }
    } 
}
