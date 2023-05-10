using CSL.SQL;

namespace DaceloApi.Types;

public record Post(Guid postid, Guid uuid, DateTime timestamp, string title, string content, int views, int likes, int dislikes) : SQLRecord<Post>;