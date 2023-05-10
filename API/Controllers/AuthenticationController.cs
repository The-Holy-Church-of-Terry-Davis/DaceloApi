using Microsoft.AspNetCore.Mvc;
using DaceloApi.Handlers;
using DaceloApi.Types;
using Newtonsoft.Json;
using DaceloApi.SQL;
using CSL.SQL;

namespace DaceloApi.Controllers;

[ApiController]
[Route("/api/auth")]
public class AuthenticationController : ControllerBase
{
    [HttpPost]
    [Route("authenticateuser")]
    public async Task<Guid?> AuthenticateUser(string json)
    {
        //convert the json from the client into a C# object
        AuthSecret? auth = JsonConvert.DeserializeObject<AuthSecret>(json);
        if(auth is null) { return null; } //check if there was a problem anywhere in the conversion process

        //create our SQLDB object to help handle the SQL
        using(SQLDB sql = await SQLHandler.GetSql())
        {
            //Try to find our UserSecret from the database
            UserSecret? s = await UserSecret.SelectOne(sql, Conditional.WHERE("email", IS.EQUAL_TO, auth.email));
            if(s is null) { return null; } //Check if the UserSecret search was successful

            Guid ns = Guid.NewGuid(); //Generate an authentication key

            Authenticated.Ids.Add(ns); //Store our key
            return ns; //return the key to the client for future use
        }
    }

    [HttpPost]
    [Route("amiauthenticated")]
    public bool AmIAuthed(Guid uuid)
    {
        if(Authenticated.Ids.Contains(uuid))
        {
            return true;
        }

        return false;
    }
}

public record AuthSecret(string email, string password);
