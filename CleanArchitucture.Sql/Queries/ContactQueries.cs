using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitucture.Sql.Queries
{
    public  class ContactQueries
    {
        public static string AllContact => "SELECT * FROM [Contact] (NOLOCK)";

        public static string ContactById => "SELECT * FROM [Contact] (NOLOCK) WHERE [ContactId] = @ContactId";

        public static string AddContact =>
            @"INSERT INTO [Contact] ([FirstName], [LastName], [Email], [PhoneNumber]) 
            VALUES (@FirstName, @LastName, @Email, @PhoneNumber)";

        public static string UpdateContact =>
            @"UPDATE [Contact] 
        SET [FirstName] = @FirstName, 
            [LastName] = @LastName, 
            [Email] = @Email, 
            [PhoneNumber] = @PhoneNumber
        WHERE [ContactId] = @ContactId";

        public static string DeleteContact => "DELETE FROM [Contact] WHERE [ContactId] = @ContactId";
    }
}
