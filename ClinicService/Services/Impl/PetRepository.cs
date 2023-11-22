using ClinicService.Models;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.Data.Sqlite;

namespace ClinicService.Services.Impl
{
    public class PetRepository : IPetRepository
    {

        private const string connectionString = "Data Source = clinic.db";

        public int Create(Pet item)
        {
            using SqliteConnection connection = new SqliteConnection(connectionString);
            connection.ConnectionString = connectionString;
            connection.Open();

            using SqliteCommand command =
                new SqliteCommand("INSERT INTO pets(ClientId, Name, BirthDay) VALUES(@ClientId, @Name, @BirthDay)", connection);
            //command.Parameters.AddWithValue("@PetId", item.PetId);
            command.Parameters.AddWithValue("@ClientId", item.ClientId);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@BirthDay", item.BirthDay.Ticks);
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public int Update(Pet item)
        {
            using SqliteConnection connection = new SqliteConnection(connectionString);
            connection.ConnectionString = connectionString;
            connection.Open();

            using SqliteCommand command =
                new SqliteCommand("UPDATE pets SET PetId = @PetId, ClietnId = @ClientId, Name= @Name, BirthDay = @BirthDay WHERE PetId = @PetId", connection);
            command.Parameters.AddWithValue("@PetId", item.PetId);
            command.Parameters.AddWithValue("@ClietnId", item.ClientId);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@BirthDay", item.BirthDay.Ticks);
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public int Delete(int id)
        {
            using SqliteConnection connection = new SqliteConnection(connectionString);
            connection.ConnectionString = connectionString;
            connection.Open();

            using SqliteCommand command =
                new SqliteCommand("DELETE FROM pets WHERE PetId = @PetId", connection);
            command.Parameters.AddWithValue("@PetId", id);
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public IList<Pet> GetAll()
        {
            List<Pet> pets = new List<Pet>();

            using SqliteConnection connection = new SqliteConnection(connectionString);
            connection.ConnectionString = connectionString;
            connection.Open();

            SqliteCommand command =
                new SqliteCommand("SELECT * FROM pets", connection);
            command.Prepare();
            using SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Pet pet = new Pet();
                pet.PetId = reader.GetInt32(0);
                pet.ClientId = reader.GetInt32(1);
                pet.Name = reader.GetString(2);
                pet.BirthDay = new DateTime(reader.GetInt64(3));

                pets.Add(pet);
            }

            return pets;
        }

        public Pet GetById(int id)
        {
            using SqliteConnection connection = new SqliteConnection(connectionString);
            connection.ConnectionString = connectionString;
            connection.Open();

            SqliteCommand command =
                new SqliteCommand("SELECT * FROM pets WHERE PetId=@PetId", connection);
            command.Parameters.AddWithValue("@PetId", id);
            command.Prepare();
            using SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Pet pet = new Pet();
                pet.PetId = reader.GetInt32(0);
                pet.ClientId = reader.GetInt32(1);
                pet.Name = reader.GetString(2);
                pet.BirthDay = new DateTime(reader.GetInt64(3));

                return pet;
            }

            return null;
        }

        public IList<Pet> GetAllClientPets(int id)
        {
            List<Pet> pets = new List<Pet>();

            using SqliteConnection connection = new SqliteConnection(connectionString);
            connection.ConnectionString = connectionString;
            connection.Open();

            SqliteCommand command =
               new SqliteCommand("SELECT * FROM pets WHERE ClientId=@ClientId", connection);
            command.Parameters.AddWithValue("@ClientId", id);
            command.Prepare();
            using SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Pet pet = new Pet();
                pet.PetId = reader.GetInt32(0);
                pet.ClientId = reader.GetInt32(1);
                pet.Name = reader.GetString(2);
                pet.BirthDay = new DateTime(reader.GetInt64(3));

                pets.Add(pet);
            }

            if (pets.Count == 0)
            {
                throw new Exception($"У данного клиента с id {id} нет животных");
            }

            return pets;
        }
    }
}
