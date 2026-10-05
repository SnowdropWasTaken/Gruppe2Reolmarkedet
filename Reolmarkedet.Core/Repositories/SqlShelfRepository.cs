using Microsoft.Data.SqlClient;
using Reolmarkedet.Core.Interfaces;
using Reolmarkedet.Core.Models;
using System.Collections.Generic;

namespace Reolmarkedet.Core.Repositories
{
    public class SqlShelfRepository : IShelfRepository
    {
        private readonly string _connectionString;

        public SqlShelfRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Shelf? GetById(int shelfID)
        {
            Shelf? shelf = null;
            string query = @"
                SELECT s.ShelfID, s.ShelfName, s.ShelfStatus,
                       st.ShelfTypeID, st.ShelfTypeName, st.ShelfCount, st.HasHangerRod
                FROM Shelf s
                JOIN ShelfType st ON s.ShelfTypeID = st.ShelfTypeID
                WHERE s.ShelfID = @ShelfID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ShelfID", shelfID);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        shelf = MapShelf(reader);
                    }
                }
            }

            return shelf;
        }

        public List<Shelf> GetAll()
        {
            var shelves = new List<Shelf>();
            string query = @"
                SELECT s.ShelfID, s.ShelfName, s.ShelfStatus,
                       st.ShelfTypeID, st.ShelfTypeName, st.ShelfCount, st.HasHangerRod
                FROM Shelf s
                JOIN ShelfType st ON s.ShelfTypeID = st.ShelfTypeID
                ORDER BY s.ShelfName";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        shelves.Add(MapShelf(reader));
                    }
                }
            }

            return shelves;
        }

        public List<Shelf> Search(string searchTerm)
        {
            var shelves = new List<Shelf>();
            string query = @"
                SELECT s.ShelfID, s.ShelfName, s.ShelfStatus,
                       st.ShelfTypeID, st.ShelfTypeName, st.ShelfCount, st.HasHangerRod
                FROM Shelf s
                JOIN ShelfType st ON s.ShelfTypeID = st.ShelfTypeID
                WHERE s.ShelfName LIKE @SearchTerm
                   OR st.ShelfTypeName LIKE @SearchTerm
                ORDER BY s.ShelfName";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        shelves.Add(MapShelf(reader));
                    }
                }
            }

            return shelves;
        }

        public int Insert(Shelf shelf)
        {
            string query = @"
                INSERT INTO Shelf (ShelfName, ShelfTypeID, ShelfStatus)
                OUTPUT INSERTED.ShelfID
                VALUES (@ShelfName, @ShelfTypeID, @ShelfStatus)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ShelfName", shelf.ShelfName);
                command.Parameters.AddWithValue("@ShelfTypeID", shelf.ShelfType.ShelfTypeId);
                command.Parameters.AddWithValue("@ShelfStatus", shelf.Status);
                connection.Open();

                int newId = (int)command.ExecuteScalar();
                shelf.ShelfId = newId;
                return newId;
            }
        }

        public void Update(Shelf shelf)
        {
            string query = @"
                UPDATE Shelf
                SET ShelfName = @ShelfName,
                    ShelfTypeID = @ShelfTypeID,
                    ShelfStatus = @ShelfStatus
                WHERE ShelfID = @ShelfID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ShelfName", shelf.ShelfName);
                command.Parameters.AddWithValue("@ShelfTypeID", shelf.ShelfType.ShelfTypeId);
                command.Parameters.AddWithValue("@ShelfStatus", shelf.Status);
                command.Parameters.AddWithValue("@ShelfID", shelf.ShelfId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int shelfID)
        {
            string query = "DELETE FROM Shelf WHERE ShelfID = @ShelfID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ShelfID", shelfID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Helper method to map a SqlDataReader row to a Shelf object, since this logic is used in multiple methods, we can extract it to a private method.
        private Shelf MapShelf(SqlDataReader reader)
        {
            var shelfType = new ShelfType(
                (string)reader["ShelfTypeName"],
                (int)(byte)reader["ShelfCount"],
                (bool)reader["HasHangerRod"]
            )
            {
                ShelfTypeId = (int)reader["ShelfTypeID"]
            };

            return new Shelf((string)reader["ShelfName"], shelfType)
            {
                ShelfId = (int)reader["ShelfID"],
                Status = (bool)reader["ShelfStatus"]
            };
        }
    }
}