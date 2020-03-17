using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class DbOperations
    {
        static DemoEntities3 D = new DemoEntities3();
        public static bool get(string username,string password)
        {
            var v = from E in D.tbl_login
                    where E.username== username
                    && E.password == password
                    select E;
            if (v.ToList().Count == 1)
                return true;
            else
                return false;
        }
        public static List<EMPDATA> GetAll()
        {
            var E = from E1 in D.EMPDATAs
                    select E1;
            return E.ToList();
        }
        public static EMPDATA GetEmpupdate(int Empno)
        {
            var LE = from L in D.EMPDATAs
                     where L.EMPNO == Empno
                     select L;
            return LE.FirstOrDefault();
        }
        public static string GetEmpnoData(EMPDATA emp)
        {
            var LE = from L in D.EMPDATAs
                     where L.EMPNO == emp.EMPNO
                     select L;
            foreach (var row in LE)
            {
                row.JOB = emp.JOB;
                row.MGR = emp.MGR;
                row.SAL = emp.SAL;
                row.COMM = emp.COMM;
                row.DEPTNO = emp.DEPTNO;
            }
            D.SaveChanges();
            return "1 Row Updated";
        }
        public static string DeleteEmp(int Eno)
        {
            var E = from E1 in D.EMPDATAs
                    where E1.EMPNO == Eno
                    select E1;
            D.EMPDATAs.Remove(E.First());
            D.SaveChanges();
            return Eno + " Employee details are deleted";
        }
        public static string InsertEmp(EMPDATA A)
        {
            try
            {
                D.EMPDATAs.Add(A);
                D.SaveChanges();
            }
            catch (DbUpdateException E)
            {
                SqlException ex = E.GetBaseException() as SqlException;
                if (ex.Message.Contains("FK_EmpDept"))
                {
                    return "No Proper Deptno";
                }
                else if (ex.Message.Contains("EMP_PK"))
                {
                    return "Empno cannot be duplicate";
                }
                else
                    return "error occured";
            }
            return "1 row inserted";
        }
    }
}