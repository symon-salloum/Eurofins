# Eurofins

note: i named the table in the database "ToDoTask" based on the Model structure.

Model
Id (int)
Title (nvarchar(50))
Description (nvarchar(1000))
IsCompleted (bit)


used 
- SqLite.
- AutoMapper for converting Entity objects into (DOT) Data Transfer Objects.
- SimpleInjector IOC container.
- Repository Pattern.
- Unit of Work.
- Data Transfer Objects (DTO).
- Database Factory.
- Entity Framework fluent api for configuring and mapping the model to the database.
