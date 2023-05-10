using CSL.SQL;
using DaceloApi.Types;

namespace DaceloApi.SQL
{
    public class SQLHandler
    {
        public static async Task<SQLDB> GetSql() => await PostgreSQL.Connect("localhost", "dacelo", "dacelo-db", "8letters");
        public static async Task Init()
        {
            PostgreSQL.TrustAllServerCertificates = true;

            using (SQLDB sql = await GetSql())
            {
                sql.BeginTransaction();

                await Post.CreateDB(sql);
                await UserSecret.CreateDB(sql);

                sql.CommitTransaction();
            }
        }
    }
}
