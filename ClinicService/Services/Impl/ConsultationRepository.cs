﻿using ClinicService.Models;
using Microsoft.Data.Sqlite;

namespace ClinicService.Services.Impl
{
    public class ConsultationRepository : IConsultationRepository
    {

        private const string connectionString = "Data Source = clinic.db";

        public int Create(Consultation item)
        {
            using SqliteConnection connection = new SqliteConnection(connectionString);
            connection.ConnectionString = connectionString;
            connection.Open();

            using SqliteCommand command =
                new SqliteCommand("INSERT INTO consultations(ClientId, PetId, ConsultationDate, Description)" +
                " VALUES(@ClientId, @PetId, @ConsultationDate, @Description)", connection);
            command.Parameters.AddWithValue("@ClientId", item.ClientId);
            command.Parameters.AddWithValue("@PetId", item.PetId);
            command.Parameters.AddWithValue("@ConsultationDate", item.ConsultationDate.Ticks);
            command.Parameters.AddWithValue("@Description", item.Description);
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public int Update(Consultation item)
        {
            using SqliteConnection connection = new SqliteConnection(connectionString);
            connection.ConnectionString = connectionString;
            connection.Open();

            using SqliteCommand command =
                new SqliteCommand("UPDATE consultations SET ConsultationId = @ConsultationId, ClietnId = @ClientId, PetId = @PetId," +
                " ConsultationDate = @ConsultationDate, Description = @Description", connection);
            command.Parameters.AddWithValue("@ConsultationId", item.ConsultationId);
            command.Parameters.AddWithValue("@ClientId", item.ClientId);
            command.Parameters.AddWithValue("@PetId", item.PetId);
            command.Parameters.AddWithValue("@ConsultationDate", item.ConsultationDate.Ticks);
            command.Parameters.AddWithValue("@Description", item.Description);
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public int Delete(int id)
        {
            using SqliteConnection connection = new SqliteConnection(connectionString);
            connection.ConnectionString = connectionString;
            connection.Open();

            using SqliteCommand command =
                new SqliteCommand("DELETE FROM consultations WHERE ConsultationId = @ConsultationId", connection);
            command.Parameters.AddWithValue("@ConsultationId", id); ;
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public IList<Consultation> GetAll()
        {
            List<Consultation> list = new List<Consultation>();

            using SqliteConnection connection = new SqliteConnection(connectionString);
            connection.ConnectionString = connectionString;
            connection.Open();

            SqliteCommand command =
                new SqliteCommand("SELECT * FROM consultations", connection);
            command.Prepare();
            using SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Consultation consultation = new Consultation();

                consultation.ConsultationId = reader.GetInt32(0);
                consultation.ClientId = reader.GetInt32(1);
                consultation.PetId = reader.GetInt32(2);
                consultation.ConsultationDate = new DateTime(reader.GetInt64(3));
                consultation.Description = reader.GetString(4);

                list.Add(consultation);
            }

            return list;
        }

        public Consultation GetById(int id)
        {
            using SqliteConnection connection = new SqliteConnection(connectionString);
            connection.ConnectionString = connectionString;
            connection.Open();

            using SqliteCommand command =
                new SqliteCommand("SELECT * FROM consultations WHERE ConsultationId = @ConsultationId", connection);
            command.Parameters.AddWithValue("@ConsultationId", id);
            command.Prepare();

            using SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Consultation consultation = new Consultation();

                consultation.ConsultationId = reader.GetInt32(0);
                consultation.ClientId = reader.GetInt32(1);
                consultation.PetId = reader.GetInt32(2);
                consultation.ConsultationDate = new DateTime(reader.GetInt64(3));
                consultation.Description = reader.GetString(4);

                return consultation;
            }

            return null;
        }

        public IList<Consultation> GetAllClientConsultations(int id)
        {
            List<Consultation> consultations = new List<Consultation>();

            using SqliteConnection connection = new SqliteConnection(connectionString);
            connection.ConnectionString = connectionString;
            connection.Open();

            SqliteCommand command =
               new SqliteCommand("SELECT * FROM consultations WHERE ClientId=@ClientId", connection);
            command.Parameters.AddWithValue("@ClientId", id);
            command.Prepare();
            using SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Consultation consultation = new Consultation();

                consultation.ConsultationId = reader.GetInt32(0);
                consultation.ClientId = reader.GetInt32(1);
                consultation.PetId = reader.GetInt32(2);
                consultation.ConsultationDate = new DateTime(reader.GetInt64(3));
                consultation.Description = reader.GetString(4);

                consultations.Add(consultation);
            }

            if (consultations.Count == 0)
            {
                throw new Exception($"У данного клиента с id {id} нет консультаций");
            }

            return consultations;
        }
    }
}
