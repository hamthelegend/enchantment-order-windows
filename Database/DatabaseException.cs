namespace Database;

public class DatabaseException : IOException
{
    public DatabaseException(string message) : base(message) {}
}

public class EntityDoesNotExistException : DatabaseException
{
    public EntityDoesNotExistException(int id) : base($"Entity with the ID {id} is not in the database.") {}
}