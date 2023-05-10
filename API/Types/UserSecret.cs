using CSL.SQL;

namespace DaceloApi.Types;

public record UserSecret(string email, string salt, string hash) : SQLRecord<UserSecret>;